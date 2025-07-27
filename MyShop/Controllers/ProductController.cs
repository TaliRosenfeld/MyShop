using AutoMapper;
using DTO;
using Entities;
using Microsoft.AspNetCore.Mvc;
using Services;
using System.Collections.Generic;
using Microsoft.AspNetCore.Authorization;
using System.Text.Json;
using Microsoft.Extensions.Caching.Distributed;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MyShop.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    //[Authorize]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _ProductService;
        private readonly IMapper _mapper;
        private readonly IDistributedCache _cache;
        public ProductController(IProductService ProductService, IMapper mapper, IDistributedCache cache)
        {
            _ProductService=ProductService;
            _mapper = mapper;
            _cache = cache;
        }
        // GET: api/<ProductController>
        [HttpGet]
        public async Task<IEnumerable<productDTO>> Get([FromQuery] int? position, [FromQuery] int? skip, [FromQuery] string? desc, [FromQuery] int? minPrice, [FromQuery] int? maxPrice, [FromQuery] int?[] categoryIds)
        {
            string cacheKey = $"products:{position}:{skip}:{desc}:{minPrice}:{maxPrice}:{string.Join(",", categoryIds ?? new int?[0])}";
            var cachedProducts = await _cache.GetStringAsync(cacheKey);
            if (!string.IsNullOrEmpty(cachedProducts))
            {
                return JsonSerializer.Deserialize<IEnumerable<productDTO>>(cachedProducts);
            }
            IEnumerable<Product> product = await _ProductService.GetProducts(position,skip, desc, minPrice,maxPrice,categoryIds);
            IEnumerable<productDTO> productDTO = _mapper.Map<IEnumerable<Product>, IEnumerable<productDTO>>(product);
            var serialized = JsonSerializer.Serialize(productDTO);
            await _cache.SetStringAsync(cacheKey, serialized, new DistributedCacheEntryOptions { AbsoluteExpirationRelativeToNow = TimeSpan.FromMinutes(5) });
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



