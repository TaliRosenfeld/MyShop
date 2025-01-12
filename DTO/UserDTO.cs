using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public record userRegisterDTO(string? Email,string Password, string? FirstName, string? LastName);
    public record userRegisterWithOutPasswordDTO(string? Email, string? FirstName, string? LastName);
    public record userIdDTO(int? UserId);
    public record userLoginIdDTO(string Email,string Password);
}
