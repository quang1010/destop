using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Threading.Tasks;

namespace Book.data.Entities
{
    public class Book
    {
        public int Id { get; set; }
        public int Price { get; set; }
        public string Avatar { get; set; }
        public int CategoryId { get; set; }
        public DateTime update { get; set; }
    }
}
