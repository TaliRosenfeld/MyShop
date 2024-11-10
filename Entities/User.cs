using System.ComponentModel.DataAnnotations;

namespace Entities
{
    public class User
    {
        [StringLength(20,ErrorMessage ="name can be between 2 till 20 letters", MinimumLength =2)] 
        public string FirstName { get; set; }
        [StringLength(20,ErrorMessage = "name can be between 2 till 20 letters", MinimumLength =2)]
        public string LastName { get; set; }
        
        [StringLength(20, ErrorMessage = "name can be between 2 till 20 letters", MinimumLength = 2)]
        public string Password { get; set; }

        [EmailAddress(ErrorMessage ="mail not vailed")]
        public string Email { get; set; }
        
       
        public int UserId { get; set; }

    }
}
