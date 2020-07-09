using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using WebApplication8.Models;

namespace WebApplication8.ViewModels
{
    public class HomeCreateViewModel
    {
        [Required]
        [MaxLength(20, ErrorMessage = "Can not exceed 20 characters")]
        public string Name { get; set; }
        
     
        [RegularExpression(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$",
            ErrorMessage = "Invalid email format")]
        public string Email { get; set; }
        [Required]
        public Dept? TypeF { get; set; }
        public IFormFile Avatar { get; set; }
    }
}
