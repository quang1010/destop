using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication5.Models
{
    public class Cake
    {
        
        public int Id { get; set; }
        [Required]
        [StringLength(30, ErrorMessage = "Can not  exceed 30 characters")]
        [DisplayName("Tên bánh")]
        public string nameCake { get; set; }
        [DisplayName("Thành phần")]
        public string ThanhPhan { get; set; }
        [Required]
        [DisplayName("Hạn sử dụng")]
      
        public DateTime Hsd { get; set; }
        [Required]
        [DisplayName("Ngày sản xuất")]
      
        public DateTime Nsx { get; set; }
        [Required]
        [DisplayName("Giá bán")]
        public string GiaBan{ get; set; }

        [DisplayName("Đã xóa")]
        public bool DaXoa { get; set; }


        [Required]
        public int CategoryId { get; set; }
        public Category Category { get; set; }
    }
}
