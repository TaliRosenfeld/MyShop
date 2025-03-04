using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    //public record userDTO( int? UserId, [EmailAddress(ErrorMessage = "כתובת מייל לא תקינה"), Required] string Email, [Required] string Password, string? FirstName, string? LastName);
    public record userRegisterDTO([EmailAddress(ErrorMessage = "כתובת מייל לא תקינה"), Required] string Email,[Required] string Password,  string FirstName, [StringLength(20, ErrorMessage = "Name can be between 2 till 20 letters", MinimumLength = 2), Required] string LastName);
    //public record userRegisterWithOutPasswordDTO([EmailAddress(ErrorMessage = "כתובת מייל לא תקינה"), Required] string Email,  string? FirstName,  string? LastName);
    public record userIdDTO(int? UserId);
    public record userLoginIdDTO([EmailAddress(ErrorMessage = "כתובת מייל לא תקינה"), Required] string Email,[Required] string Password);
}
