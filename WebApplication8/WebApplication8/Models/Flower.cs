using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication8.Models
{
    public class Flower
    {
        public int Id { get; set; }
        [Required]
        [MaxLength(20, ErrorMessage = "Can not exceed 20 characters")]
        public string Name { get; set; }
       //Required]
       
        [RegularExpression(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$",
            ErrorMessage = "Invalid email format")]
       //ublic string Email { get; set; }
        [Required]
        public Dept? TypeF { get; set; }
        public string AvatarPath { get; set; }


        public override string ToString()
        {
            return $"Id : {Id}, Name: {Name}, " +
                $"Type Flower: {TypeF}, AvatarPath: {AvatarPath}";
        }
    }
}
