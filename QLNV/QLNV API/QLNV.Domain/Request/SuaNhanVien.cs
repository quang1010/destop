using System;
using System.Collections.Generic;
using System.Text;

namespace QLNV.Domain.Request
{
    public class SuaNhanVien
    {
        public int MaNV { get; set; }
        public string Ho { get; set; }
        public string Ten { get; set; }
        public string DiaChi { get; set; }
        public string Dienthoai { get; set; }
        public string Email { get; set; }
        public int PhongBanId { get; set; }
    }
}
