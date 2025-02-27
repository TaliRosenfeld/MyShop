using Entities;
using Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class OrderServise : IOrderServise
    {
        IOrderRepository _OrderRepository;
        IProductRepository _productRepository;

        public OrderServise(IOrderRepository OrderRepository, IProductRepository productRepository)
        {
            _OrderRepository = OrderRepository;
            _productRepository = productRepository;
        }

        public async Task<Order> CreateOrder(Order order)
        {
            order.OrderSum = await GetOrdeSum(order);
            return await _OrderRepository.CreateOrder(order);
            
        }
        public async Task<Order> GetOrderById(int id)
        {
            return await _OrderRepository.GetOrderById(id);
        }
        
        private async Task<double> GetOrdeSum(Order order)
        {
            double sum = 0;
            foreach (var o in order.OrderItems)
            {
                Product p = await _productRepository.getProductById(Convert.ToInt32(o.ProductId));
                sum += Convert.ToDouble(p.Price) * Convert.ToInt32(o.Quantity);
            }
            return sum;
        }

    }
}
