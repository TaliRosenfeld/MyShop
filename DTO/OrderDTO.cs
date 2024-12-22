using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace DTO
{
        public record orderDTO(DateTime? OrderDate,double? OrderSum, ICollection<orderItemsDTO> orderItems,string UserFirstName,string UserLastName);
        public record orderPostDTO(int UserId,DateTime? OrderDate, double? OrderSum , ICollection<orderItemsDTO> orderItems);
}
