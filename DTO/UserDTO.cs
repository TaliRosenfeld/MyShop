using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    //public record userDTO( int? UserId, [EmailAddress(ErrorMessage = "כתובת מייל לא תקינה"), Required] string Email, [Required] string Password, string? FirstName, string? LastName);
    public record userRegisterDTO([EmailAddress(ErrorMessage = "כתובת מייל לא תקינה"), Required] string Email,[Required] string Password,  string FirstName, string LastName);
    //public record userRegisterWithOutPasswordDTO([EmailAddress(ErrorMessage = "כתובת מייל לא תקינה"), Required] string Email,  string? FirstName,  string? LastName);
    public record userIdDTO(int? UserId);
    public record userLoginIdDTO([EmailAddress(ErrorMessage = "כתובת מייל לא תקינה"), Required] string Email,[Required] string Password);
}
