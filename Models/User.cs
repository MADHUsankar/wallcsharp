using System.ComponentModel.DataAnnotations;
using System;
namespace login.Models
{
    public class User : BaseEntity
    {
         [Required]
         [MinLength(3)]
        public string FirstName { get; set; }
        [Required]
         [MinLength(3)]
        public string LastName { get; set; }
        [Required]
        [Range(0,99)]
         
        public int Age { get; set; }

                [Required]
        [EmailAddress]
        public string EmailAddress { get; set; }
 
        [Required]
         [MinLength(8)]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Required]
        [DataType(DataType.Password)]
         [MinLength(8)]
       [Compare("Password", ErrorMessage = "Your passwords don't match!")]
        public string Confirmpassword { get; set; }
        
        public DateTime createdAt { get; set; }

        public DateTime updatedAt { get; set; }

        public User()
        {
            createdAt = DateTime.Now;
            updatedAt = DateTime.Now;
            
        }
    }
}