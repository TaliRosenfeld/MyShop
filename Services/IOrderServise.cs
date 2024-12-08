using Entities;

namespace Services
{
    public interface IOrderServise
    {
        Task<Order> CreateOrder(Order order);
        Task<Order> GetOrderById(int id);
    }
}