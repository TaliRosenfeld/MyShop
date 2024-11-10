using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    internal class UserLogin
    {
        [StringLength(20, ErrorMessage = "name can be between 2 till 20 letters", MinimumLength = 2)]
        public string Password { get; set; }

        [EmailAddress(ErrorMessage = "mail not vailed")]
        public string Email { get; set; }

    }
}
