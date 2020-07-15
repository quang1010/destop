using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using QLNV.BAL;
using QLNV.BAL.Interface;
using QLNV.Domain.Request;
using QLNV.Domain.Response;

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















        //private static readonly string[] Summaries = new[]
        //{
        //    "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        //};

        //private readonly ILogger<PhongBanController> _logger;

        //public PhongBanController(ILogger<PhongBanController> logger)
        //{
        //    _logger = logger;
        //}

        //[HttpGet]
        //public IEnumerable<WeatherForecast> Get()
        //{
        //    var rng = new Random();
        //    return Enumerable.Range(1, 5).Select(index => new WeatherForecast
        //    {
        //        Date = DateTime.Now.AddDays(index),
        //        TemperatureC = rng.Next(-20, 55),
        //        Summary = Summaries[rng.Next(Summaries.Length)]
        //    })
        //    .ToArray();
        //}
    }
}
