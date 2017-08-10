using System.ComponentModel.DataAnnotations;
using System;
namespace login.Models
{
    public class loginUser : BaseEntity
    {
       [Required]
        [EmailAddress]
        public string EmailAddress { get; set; }
 
        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }
         
        
    }
}