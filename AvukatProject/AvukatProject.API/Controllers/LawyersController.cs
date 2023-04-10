using AutoMapper;
using AvukatProjectCore.DTOs;
using AvukatProjectCore.Model;
using AvukatProjectCore.Services;
using AvukatProjectRepository;
using AvukatProjectService.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

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

        [HttpGet("[action]")]
        public async Task<IActionResult> GetLawyersWithCategory()
        {
            return CreateActionResult(await lawyersService.GetLawyersWithCategory());
        }
        [HttpGet]
        public async Task<IActionResult> All()
        {

            var lawyer = await _lawyers.GetAllAsync();
            var lawyerDtos = _mapper.Map<List<LawyersDto>>(lawyer.ToList());
            return CreateActionResult(CustomResponseDto<List<LawyersDto>>.Success(200, lawyerDtos));
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {

            var lawyer = await _lawyers.GetByIdAsync(id);
            var lawyerDtos = _mapper.Map<List<LawyersDto>>(lawyer);
            return CreateActionResult(CustomResponseDto<List<LawyersDto>>.Success(200, lawyerDtos));
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
       
    }
}
