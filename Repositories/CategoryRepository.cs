using Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories
{
    public class CategoryRepository : ICategoryRepository
    {
        _326774742WebApiContext contextDb;
        public CategoryRepository(_326774742WebApiContext contextDb)
        {
            this.contextDb = contextDb;
        }
        public async Task<IEnumerable<Category>> GetCategories()
        {
            return await contextDb.Categories.ToListAsync();
        }
    }
}
