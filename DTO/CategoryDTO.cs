using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public record categoryDTO(int Id,string? Name);
    public record categoryByNameDTO(string? Name);

}
