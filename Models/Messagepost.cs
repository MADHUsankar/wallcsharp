using System.ComponentModel.DataAnnotations;
using System;
namespace login.Models
{
    public class Messagepost : BaseEntity
    {
       [Required]
         
        public string Messagescontent { get; set; }
 
        public DateTime createdAt { get; set; }

        public DateTime updatedAt { get; set; }

        public Messagepost()
        {
            createdAt = DateTime.Now;
            updatedAt = DateTime.Now;
            
        }
    }
}