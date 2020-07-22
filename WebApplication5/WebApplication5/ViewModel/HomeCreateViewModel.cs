using Castle.MicroKernel.SubSystems.Conversion;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication5.ViewModel
{
    public class HomeCreateViewModel
    {

       
        [Required]
        [StringLength(30, ErrorMessage = "Can not  exceed 30 characters")]
        public string nameCake { get; set; }
        [Required]
        public string ThanhPhan { get; set; }
        [Required]
        
        [DataType(DataType.Date)]
         public DateTime  Hsd { get; set; }
        [Required]
        [DataType(DataType.Date)]
        public DateTime Nsx { get; set; }
        [Required]
        public int GiaBan { get; set; }
        [Required]
        public bool DaXoa { get; set; }

        [Required]
        public int CategoryId { get; set; }

    }
}
