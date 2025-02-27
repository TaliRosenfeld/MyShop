using Entities;
using Microsoft.AspNetCore.Mvc;
using Services;
using DTO;
using AutoMapper;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MyShop.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly IOrderServise _OrderServise;
        private readonly IMapper _mapper;
        public OrderController(IOrderServise OrderServise, IMapper mapper)
        {
            _mapper = mapper;
            _OrderServise = OrderServise;
        }

        // GET api/<OrderController>/5
        [HttpGet("{id}")]
        public async Task<orderDTO> Get(int id)
        {
            Order order=await _OrderServise.GetOrderById(id);
            orderDTO orderDTO = _mapper.Map<Order, orderDTO>(order);
            return orderDTO;
        }

        // POST api/<OrderController>
        [HttpPost]
        public async Task<ActionResult<Order>> Post([FromBody] orderPostDTO orderPostDTO)
        {   
            Order order = _mapper.Map<orderPostDTO, Order>(orderPostDTO);
            await _OrderServise.CreateOrder(order);
            if (order != null)
            {
                return CreatedAtAction(nameof(Get), new { id = order.OrderId },_mapper.Map<Order,orderNewDTO>(order));
            }
            return BadRequest();
            //Order newOrder = await _OrderServise.
            //return newOrder;
        }
    }
}
