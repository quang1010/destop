﻿using Microsoft.AspNetCore.Mvc;
using QLNV.BAL.Interface;
using QLNV.Domain.Request;
using QLNV.Domain.Response;
using System.Collections.Generic;

namespace QLNV_API.Controllers
{
    [ApiController]
   
    public class PhongBanController : ControllerBase
    {
        private readonly IPhongBanService _phongBanService;


        public PhongBanController(IPhongBanService phongBanService)
        {
            _phongBanService = phongBanService;
        }

        [HttpGet]
        [Route("/phongban/danhsachphongban")]
        public IEnumerable<PhongBan> DanhSachPhongBan()
        {
            return _phongBanService.DanhSachPhongBan();
        }

        [HttpGet]
        [Route("/phongban/danhsachphongban/{id}")]
        public PhongBan LayPhongBanID(int id)
        {
            return _phongBanService.LayPhongBanID(id);
        }

        [HttpPost]
        [Route("/phongban/taophongban")]
        public int TaoPhongBan([FromBody] TaoPhongBan request)
        {
            return _phongBanService.TaoPhongBan(request);
        }

        [HttpPut]
        [Route("/phongban/suaphongban")]
        public int SuaPhongBan([FromBody] SuaPhongBan request)
        {
            return _phongBanService.SuaPhongBan(request);
        }

        [HttpDelete]
        [Route("/phongban/xoaphongban/{id}")]
        public bool XoaPhongBan(int id)
        {
            return _phongBanService.XoaPhongBan(id);
        }















    }
}
