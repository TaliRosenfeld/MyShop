using Entities;
using Microsoft.Extensions.Logging;
using Repositories;
using System;
using System.Collections.Concurrent;
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
        private readonly ILogger<OrderServise> _logger;
        public OrderServise(IOrderRepository OrderRepository, IProductRepository productRepository, ILogger<OrderServise> logger)
        {
            _OrderRepository = OrderRepository;
            _productRepository = productRepository;
            _logger = logger;
        }

        public async Task<Order> CreateOrder(Order order)
        {
            
            double OrderSum = await GetOrdeSum(order);
            Order orderAfterCreate;
            if (OrderSum != order.OrderSum)
            {
                order.OrderSum = OrderSum;
                orderAfterCreate = await _OrderRepository.CreateOrder(order);
                _logger.LogCritical($"User {order.UserId} try change the OrderSum of order {order.OrderId}");
            }
            else {
                orderAfterCreate = await _OrderRepository.CreateOrder(order);
            }
            return orderAfterCreate;
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
