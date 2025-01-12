using AutoMapper;
using Entities;
using DTO;
namespace MyShop
{
    public class Mapper:Profile
    {
        public Mapper()
        {
            //product
            CreateMap<Product,productDTO>();
            //category
            CreateMap<Category,categoryDTO>();
            //order
            CreateMap<Order, orderDTO>();
            //CreateMap<OrderItem, orderItemDTO>();
            CreateMap<orderItemsDTO, OrderItem>();
            CreateMap<orderPostDTO, Order>();
            //user
            CreateMap<userRegisterDTO, User>();
            CreateMap<User, userIdDTO>();
            CreateMap<userRegisterWithOutPasswordDTO, userRegisterDTO>();
        }         
    }
}
