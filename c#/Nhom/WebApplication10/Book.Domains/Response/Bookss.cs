using System;
using System.Collections.Generic;
using System.Text;

namespace Book.Domains.Response
{
    class Bookss
    {
        public int Id { get; set; }
        public string BookName { get; set; }
        public string Avatar { get; set; }
        public string Description { get; set; }
        public DateTime Updateday { get; set; }
        public bool IsDeleted { get; set; }
        public int PublishingId { get; set; }
        public int CategoryId { get; set; }
        public int AuthorId { get; set; }
    }
}
