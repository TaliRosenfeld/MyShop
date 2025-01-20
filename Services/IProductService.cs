using Entities;

namespace Services
{
    public interface IProductService
    {
        Task<Product> getProductById(int id);
        Task<List<Product>> GetProducts(int? position, int? skip, string? desc, int? minPrice, int? maxPrice, int?[] categoryIds);
    }
}