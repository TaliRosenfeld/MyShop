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

        public async Task<Order> CreateOrder(Order order)
        {
            return await _OrderRepository.CreateOrder(order);
        }
        public async Task<Order> GetOrderById(int id)
        {
            return await _OrderRepository.GetOrderById(id);
        }
    }
}
