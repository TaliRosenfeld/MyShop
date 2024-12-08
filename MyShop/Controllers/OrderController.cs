using Entities;
using Microsoft.AspNetCore.Mvc;
using Services;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MyShop.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly IOrderServise _OrderServise;
        public OrderController(IOrderServise OrderServise)
        {
            _OrderServise = OrderServise;
        }

        // GET api/<OrderController>/5
        [HttpGet("{id}")]
        public Task<Order> Get(int id)
        {
            return _OrderServise.GetOrderById(id);
        }

        // POST api/<OrderController>
        [HttpPost]
        public async Task<Order> Post([FromBody] Order order)
        {
           Order newOrder= await _OrderServise.CreateOrder(order);
            return newOrder;
        }
    }
}
