using Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories
{
    public class OrderRepository : IOrderRepository
    {
        _326774742WebApiContext contextDb;

        public OrderRepository(_326774742WebApiContext contextDb)
        {
            this.contextDb = contextDb;

        }
        public async Task<Order> CreateOrder(Order order)
        {
            var newOrder=await contextDb.Orders.AddAsync(order);
            await contextDb.SaveChangesAsync();
            order.OrderId = newOrder.Entity.OrderId;
            order.UserId= newOrder.Entity.UserId;
            return order;
        }
        public async Task<Order> GetOrderById(int id)
        {
            return await contextDb.Orders.Include(o=>o.User).FirstOrDefaultAsync(order => order.OrderId == id);
             
        }


    }
}
