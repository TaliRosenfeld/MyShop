﻿using Entities;
using Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class ProductService : IProductService
    {
        IProductRepository _ProductRepository;
        public ProductService(IProductRepository ProductRepository)
        {
            _ProductRepository = ProductRepository;
        }

<<<<<<< HEAD
        public async Task<List<Product>> GetProducts(int? position, int? skip, string? desc, int? minPrice, int? maxPrice, int?[] categoryIds)
        {
            return await _ProductRepository.GetProducts(position, skip, desc, minPrice, maxPrice, categoryIds);
=======
        public async Task<List<Product>> GetProducts(int position, int skip, string? desc, int? minPrice, int? maxPrice, int?[] categoryIds)
        {
            return await _ProductRepository.GetProducts(position, skip, desc,  minPrice,  maxPrice,  categoryIds);
>>>>>>> 231949438d950bb2ad7ef89e7e7437b00f7a5808

        }
        public async Task<Product> getProductById(int id)
        {
            return await _ProductRepository.getProductById(id);
        }

    }

}
