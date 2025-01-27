using Entities;

namespace Repositories
{
    public interface IProductRepository
    {
<<<<<<< HEAD
        Task<Product> getProductById(int id);
        Task<List<Product>> GetProducts(int? position, int? skip, string? desc, int? minPrice, int? maxPrice, int?[] categoryIds);
=======
        Task<List<Product>> GetProducts(int position, int skip, string? desc, int? minPrice, int? maxPrice, int?[] categoryIds);
>>>>>>> 231949438d950bb2ad7ef89e7e7437b00f7a5808
    }
}