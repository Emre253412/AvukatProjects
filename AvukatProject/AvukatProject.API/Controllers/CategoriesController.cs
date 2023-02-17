using AutoMapper;
using AvukatProjectCore.DTOs;
using AvukatProjectCore.Model;
using AvukatProjectCore.Services;
using AvukatProjectService.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AvukatProject.API.Controllers
{
    
    public class CategoriesController : CustomBaseController
    {

        private readonly IMapper _mapper;
        private readonly IService<Category> _service;
        private readonly ICategoryService categoryService;

        public CategoriesController(IMapper mapper, IService<Category> service, ICategoryService categoryService)
        {
            _mapper = mapper;
            _service = service;
            this.categoryService = categoryService;
        }
        [HttpGet("[action]")]
        public async Task<IActionResult> GetSingleCategoryByIdWithLawyer(int categoryId)
        {
            return CreateActionResult(await categoryService.GetSingleCategoryByIdWithLawyerAsync(categoryId));
        }
        //[HttpGet]
        //public async Task<IActionResult> All()
        //{

        //    var category = await _service.GetAllAsync();
        //    var categoryDtos = _mapper.Map<List<CategoryDto>>(category.ToList());
        //    return CreateActionResult(CustomResponseDto<List<CategoryDto>>.Success(200, categoryDtos));
        //}
        //[HttpGet("{id}")]
        //public async Task<IActionResult> GetById(int id)
        //{

        //    var category = await _service.GetByIdAsync(id);
        //    var categoryDtos = _mapper.Map<List<CategoryDto>>(category);
        //    return CreateActionResult(CustomResponseDto<List<CategoryDto>>.Success(200, categoryDtos));
        //}
        //[HttpPost]
        //public async Task<IActionResult> Save(CategoryDto categoryDto)
        //{
        //    var category = await _service.AddAsync(_mapper.Map<Category>(categoryDto));
        //    var categoryDtos = _mapper.Map<CategoryDto>(category);
        //    return CreateActionResult(CustomResponseDto<CategoryDto>.Success(201, categoryDtos));
        //}
        //[HttpPut]
        //public async Task<IActionResult> Update(CategoryDto categoryDto)
        //{

        //    await _service.UpdateAsync(_mapper.Map<Category>(categoryDto));
        //    return CreateActionResult(CustomResponseDto<CategoryDto>.Success(204));
        //}
        //[HttpDelete("{id}")]
        //public async Task<IActionResult> Remove(int id)
        //{

        //    var category = await _service.GetByIdAsync(id);
        //    await _service.RemoveAsync(category);
        //    return CreateActionResult(CustomResponseDto<CategoryDto>.Success(204));
        //}
    }
}
