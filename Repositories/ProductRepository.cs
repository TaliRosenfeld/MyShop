using Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Repositories
{

    public class ProductRepository : IProductRepository
    {
        _326774742WebApiContext contextDb;
        public ProductRepository(_326774742WebApiContext contextDb)
        {
            this.contextDb = contextDb;
        }
        public async Task<List<Product>> GetProducts(int? position, int? skip, string? desc, int? minPrice, int? maxPrice, int?[] categoryIds)
        {
            var query = contextDb.Products.Where(product =>
             (desc == null ? (true) : (product.Description.Contains(desc)))
              && ((minPrice == null) ? (true) : (product.Price >= minPrice))
              && ((maxPrice == null) ? (true) : (product.Price <= maxPrice))
              && ((categoryIds.Length == 0) ? (true) : (categoryIds.Contains(product.CategoryId))))
                  .OrderBy(product => product.Price).Include(a => a.Category);
            return await query.ToListAsync();
        }
        public async Task<Product> getProductById(int id)
        {
            return await contextDb.Products.Include(a => a.Category).FirstOrDefaultAsync(product => product.Id == id);
        }
    }
}

