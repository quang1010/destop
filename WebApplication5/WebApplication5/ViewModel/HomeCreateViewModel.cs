using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication5.ViewModel
{
    public class HomeCreateViewModel
    {

       
        [Required]
        [StringLength(30, ErrorMessage = "Can not  exceed 30 characters")]
        public string nameCake { get; set; }
        public string ThanhPhan { get; set; }
        [Required]
        public string Hsd { get; set; }
        [Required]
        public string Nsx { get; set; }
        [Required]
        public string GiaBan { get; set; }
        [Required]
        public bool DaXoa { get; set; }


        [Required]
        public int CategoryId { get; set; }

    }
}
