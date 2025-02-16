using AutoMapper;
using DTO;
using Entities;
using Microsoft.AspNetCore.Mvc;
using Services;
using System.Collections.Generic;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MyShop.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _ProductService;
        private readonly IMapper _mapper;
        public ProductController(IProductService ProductService, IMapper mapper)
        {
            _ProductService=ProductService;
            _mapper = mapper;
        }
        // GET: api/<ProductController>
        [HttpGet]
        public async Task<IEnumerable<productDTO>> Get([FromQuery] int? position, [FromQuery] int? skip, [FromQuery] string? desc, [FromQuery] int? minPrice, [FromQuery] int? maxPrice, [FromQuery] int?[] categoryIds)
        {
            IEnumerable < Product > product= await _ProductService.GetProducts(position,skip, desc, minPrice,maxPrice,categoryIds);
            IEnumerable <productDTO> productDTO = _mapper.Map<IEnumerable<Product>, IEnumerable<productDTO>>(product);
            return productDTO;

        }
        public async Task<IEnumerable<productDTO>> Get([FromQuery] int position, [FromQuery] int skip, [FromQuery] string? desc, [FromQuery] int? minPrice, [FromQuery] int? maxPrice, [FromQuery] int?[] categoryIds)
        {
            IEnumerable<Product> product = await _ProductService.GetProducts(position, skip, desc, minPrice, maxPrice, categoryIds);
            IEnumerable<productDTO> productDTO = _mapper.Map<IEnumerable<Product>, IEnumerable<productDTO>>(product);
            return productDTO;

        }
        [HttpGet("{id}")]
        public async Task<productDTO> Get(int id)
        {
            Product product = await _ProductService.getProductById(id);
            productDTO productDTO = _mapper.Map<Product,productDTO > (product);
            return productDTO;
        }
    }
}

    

