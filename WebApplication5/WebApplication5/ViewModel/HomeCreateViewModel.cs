using Castle.MicroKernel.SubSystems.Conversion;
using System;
using System.Collections.Generic;
using System.ComponentModel;
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
        [DisplayName("Tên bánh")]
        public string nameCake { get; set; }
        [DisplayName("Thành phần")]
        public string ThanhPhan { get; set; }
        [Required]
        [DisplayName("Hạn sử dụng")]
        [DataType(DataType.Date)]
        public DateTime Hsd { get; set; }
        [Required]
        [DisplayName("Ngày sản xuất")]
        [DataType(DataType.Date)]

        public DateTime Nsx { get; set; }
        [Required]
        [DisplayName("Giá bán")]
       
        public int GiaBan { get; set; }

        [DisplayName("Đã xóa")]
        public bool DaXoa { get; set; }


        [Required]
        [DisplayName("Loại Bánh ")]
        public int CategoryId { get; set; }
       

    }
}
