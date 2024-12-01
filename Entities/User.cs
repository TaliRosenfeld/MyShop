using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Entities;

public partial class User
{
    public int UserId { get; set; }
    [EmailAddress(ErrorMessage = "mail not vailed")]
    
    public string Email { get; set; } = null!;
    [StringLength(20, ErrorMessage = "name can be between 2 till 20 letters", MinimumLength = 2)]
    public string FirstName { get; set; } = null!;
    [StringLength(20, ErrorMessage = "name can be between 2 till 20 letters", MinimumLength = 2)]
    public string LastName { get; set; } = null!;
    [StringLength(20, ErrorMessage = "name can be between 2 till 20 letters", MinimumLength = 2)]
    public string Password { get; set; } = null!;
}
