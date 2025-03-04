using Entities;
using Microsoft.AspNetCore.Mvc;
using Services;
using DTO;
using AutoMapper;
using Microsoft.Extensions.Caching.Memory;


// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MyShop.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly ICategoryService _CategoryService;
        private readonly IMemoryCache _memoryCache;
        public CategoryController(ICategoryService CategoryService, IMapper Mapper, IMemoryCache memoryCache)
        {
            _mapper = Mapper;
            _CategoryService = CategoryService;
            _memoryCache = memoryCache;
        }
        // GET: api/<CategoryController>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<categoryDTO>>> Get()
        {
            if (!_memoryCache.TryGetValue("categories", out IEnumerable<Category> categories))
            {
                categories = await _CategoryService.GetCategories();
                _memoryCache.Set("categories", categories, TimeSpan.FromMinutes(15));
            }
            
            IEnumerable<categoryDTO> categoryDTO = _mapper.Map<IEnumerable<Category>, IEnumerable<categoryDTO>>(categories);
            return categoryDTO != null ? Ok(categoryDTO) : BadRequest();
        }
         
    }
}
