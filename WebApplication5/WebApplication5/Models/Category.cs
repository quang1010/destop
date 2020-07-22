using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication5.Models
{
    public class Category
    {
        [Key]
        public int CategoryId { get; set; }
        [Required]
        [MaxLength(100)]
        [DisplayName("Loại bánh")]
        public string CategoryName { get; set; }
        public ICollection<Cake> categorys { get; set; }
    }
}
