using Microsoft.AspNetCore.Mvc;
using QLNV.BAL.Interface;
using QLNV.Domain.Request;
using QLNV.Domain.Response;
using System.Collections.Generic;

namespace QLNV_API.Controllers
{
    
    [ApiController]
    public class NhanVienController : ControllerBase
    {
        private readonly INhanVienService _nhanVienService;



        public NhanVienController(INhanVienService nhanVienService)
        {
            _nhanVienService = nhanVienService;
        }


        [HttpGet]
        [Route("/nhanvien/danhsachnhanvientheophongban/{id}")]
        public IEnumerable<NhanVien> DanhSachNhanVienTheoPhongBan(int id)
        {
            return _nhanVienService.DanhSachNhanVienTheoPhongBan(id);
        }




        [HttpGet]
        [Route("/nhanvien/laynhanvien/{id}")]
        public NhanVien LayNhanVienID(int id)
        {
            return _nhanVienService.LayNhanVienTheoID(id);
        }



        [HttpPost]
        [Route("/nhanvien/taonhanvien")]
        public int TaoNhanvien([FromBody] TaoNhanVien request)
        {
            return _nhanVienService.TaoNhanVien(request);
        }


        [HttpPut]
        [Route("/nhanvien/suanhanvien")]
        public int SuaNhanVien([FromBody] SuaNhanVien request)
        {
            return _nhanVienService.SuaNhanVien(request);
        }



        [HttpDelete]
        [Route("/nhanvien/xoanhanvien/{id}")]
        public bool XoaNhanVien(int id)
        {
            return _nhanVienService.XoaNhanVien(id);
        }
    }
}