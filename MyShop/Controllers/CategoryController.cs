using Entities;
using Microsoft.AspNetCore.Mvc;
using Services;
using DTO;
using AutoMapper;


// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MyShop.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly ICategoryService _CategoryService;
        public CategoryController(ICategoryService CategoryService, IMapper Mapper)
        {
            _mapper = Mapper;
            _CategoryService = CategoryService;
        }
        // GET: api/<CategoryController>
        [HttpGet]
        public async Task<IEnumerable<categoryDTO>> Get()
        {
            IEnumerable<Category> category = await _CategoryService.GetCategories();
            IEnumerable<categoryDTO> categoryDTO = _mapper.Map<IEnumerable<Category>, IEnumerable<categoryDTO>>(category);
            return categoryDTO;
        }
    }
}
