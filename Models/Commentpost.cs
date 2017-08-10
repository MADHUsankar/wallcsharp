using System.ComponentModel.DataAnnotations;
using System;
namespace login.Models
{
    public class Commentpost : BaseEntity
    {
       [Required]
         
        public string Commentscontent { get; set; }
        public int Messages_idMessages{get;set;}
        public DateTime createdAt { get; set; }

        public DateTime updatedAt { get; set; }

        public Commentpost()
        {
            createdAt = DateTime.Now;
            updatedAt = DateTime.Now;
            
        }
    }
}