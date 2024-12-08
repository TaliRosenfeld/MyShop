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
        public async Task<List<Product>> GetProducts()
        {
            return await contextDb.Products.ToListAsync();

        }
    }
}
