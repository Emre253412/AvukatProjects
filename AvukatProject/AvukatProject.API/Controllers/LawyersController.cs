using AutoMapper;
using AvukatProjectCore.DTOs;
using AvukatProjectCore.Model;
using AvukatProjectCore.Services;
using AvukatProjectRepository;
using AvukatProjectService.Services;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;

namespace AvukatProject.API.Controllers
{
    
    public class LawyersController : CustomBaseController
    {
        private readonly IMapper _mapper;
        private readonly IService<Lawyers> _lawyers;
        private readonly ILawyersService lawyersService;
        private readonly AppDbContext _context;

        public LawyersController(IMapper mapper, IService<Lawyers> lawyers, ILawyersService lawyersService, AppDbContext context)
        {
            _mapper = mapper;
            _lawyers = lawyers;
            this.lawyersService = lawyersService;
            _context = context;
        }
        [Authorize]
        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> Index(Lawyers lawyers)
        {

            var datavalue = _context.Lawyers.FirstOrDefault(x => x.Name == lawyers.Name && x.Password == lawyers.Password);
            if (datavalue != null)
            {
                var claims = new List<Claim>
                {
                    new Claim(ClaimTypes.Name,lawyers.Name)
                };
                var useridentity = new ClaimsIdentity(claims, "a");
                ClaimsPrincipal user = new ClaimsPrincipal(useridentity);
                await HttpContext.SignInAsync(user);
                return RedirectToAction("Index");//yolu ver girceğin
            }
            else
            {
                return View();
            }

        }

        private IActionResult View()
        {
            throw new NotImplementedException();
        }
        [HttpGet]
        public async Task<IActionResult> All()
        {

            var lawyer = await _lawyers.GetAllAsync();
            var lawyerDtos = _mapper.Map<List<LawyersDto>>(lawyer.ToList());
            return CreateActionResult(CustomResponseDto<List<LawyersDto>>.Success(200, lawyerDtos));
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<LawyersDto>> GetLawyerById(int id)
        {
            var lawyer = await _context.Lawyers.FindAsync(id);

            if (lawyer == null)
            {
                return NotFound();
            }

            var lawyerDto = new LawyersDto
            {
                Id = lawyer.Id,
                Name = lawyer.Name,
                Mail = lawyer.Mail,
                About = lawyer.About,
                Photograph = lawyer.Photograph,
                Password = lawyer.Password,
                CategoryId = lawyer.CategoryId
            };

            return Ok(lawyerDto);
        }

        [HttpPost]
        public async Task<IActionResult> Save(LawyersDto lawyersDto)
        {
            var lawyer = await _lawyers.AddAsync(_mapper.Map<Lawyers>(lawyersDto));
            var lawyerDtos = _mapper.Map<LawyersDto>(lawyer);
            return CreateActionResult(CustomResponseDto<LawyersDto>.Success(201, lawyerDtos));
        }
        [HttpPut]
        public async Task<IActionResult> Update(LawyersDto lawyersDto)
        {

            await _lawyers.UpdateAsync(_mapper.Map<Lawyers>(lawyersDto));
            return CreateActionResult(CustomResponseDto<LawyersDto>.Success(204));
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> Remove(int id)
        {

            var lawyer = await _lawyers.GetByIdAsync(id);
            await _lawyers.RemoveAsync(lawyer);
            return CreateActionResult(CustomResponseDto<LawyersDto>.Success(204));
        }

        [HttpGet("{id}/categories")]
        public async Task<ActionResult<IEnumerable<CategoryDto>>> GetCategoriesByLawyerId(int id)
        {
            var lawyer = await _context.Lawyers.FindAsync(id);

            if (lawyer == null)
            {
                return NotFound();
            }

            var categories = await _context.Categories
                .Where(c => c.Lawyers.Any(l => l.Id == id))
                .Select(c => new CategoryDto
                {
                    Id = c.Id,
                    Name = c.Name
                })
                .ToListAsync();

            if (!categories.Any())
            {
                return NoContent();
            }

            return Ok(categories);
        }
    }
}
