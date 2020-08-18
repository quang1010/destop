using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication1.Models.PhongBan
{
    public class SuaPhongBan
    {
        public int ID { get; set; }
        [ReadOnly(true)]
        public string MaPhongBan { get; set; }
        public string TenPhongBan { get; set; }
    }
}
