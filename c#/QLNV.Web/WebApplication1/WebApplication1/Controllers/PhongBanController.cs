using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using WebApplication1.Models;
using WebApplication1.Models.PhongBan;

namespace WebApplication1.Controllers
{
    public class PhongBanController : Controller
    {
        private readonly ILogger<PhongBanController> _logger;

        public PhongBanController(ILogger<PhongBanController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            var phongbans = new List<PhongBanView>();
            var url = $"{Common.Common.AplUrl}/phongban/danhsachphongban";
            HttpWebRequest httpWebRequest = (HttpWebRequest)WebRequest.Create(url);
            httpWebRequest.Method = "GET";
            //httpWebRequest.ContentType = "application/json";
            var response = httpWebRequest.GetResponse();
            {
                string responseData;
                Stream responseStream = response.GetResponseStream();
                try
                {
                    StreamReader streamReader = new StreamReader(responseStream);
                    try
                    {
                        responseData = streamReader.ReadToEnd();
                    }
                    finally
                    {
                        ((IDisposable)streamReader).Dispose();
                    }
                }
                finally
                {
                    ((IDisposable)responseStream).Dispose();

                }
                phongbans = JsonConvert.DeserializeObject<List<PhongBanView>>(responseData);
            }
            return View(phongbans);
        }



        public IActionResult Create()
        {
            TempData["thanh cong"] = null;
            return View();
        }

        [HttpPost]
        public IActionResult Create(TaoPhongBan model)
        {
            int ketqua = 0;
            var url = $"{Common.Common.AplUrl}/phongban/taophongban";
            HttpWebRequest httpWebRequest = (HttpWebRequest)WebRequest.Create(url);
            httpWebRequest.Method = "POST";
            httpWebRequest.ContentType = "application/json";
            using (var streamWriter = new StreamWriter(httpWebRequest.GetRequestStream()))
            {
                var json = JsonConvert.SerializeObject(model);
                streamWriter.Write(json);
            }
            var httpResponse = (HttpWebResponse)httpWebRequest.GetResponse();
            using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
            {

                var resKetQua = streamReader.ReadToEnd();
                ketqua = int.Parse(resKetQua);
            }
            if (ketqua > 0)
            {
                TempData["thanh cong"] = "da tao";
            }

            ModelState.Clear();

            return View(new TaoPhongBan() { });
        }


        public IActionResult Edit(int id)
        {
            var phongban = new SuaPhongBan();
            var url = $"{Common.Common.AplUrl}/phongban/danhsachphongban/{id}";
            HttpWebRequest httpWebRequest = (HttpWebRequest)WebRequest.Create(url);
            httpWebRequest.Method = "GET";
            // httpWebRequest.ContentType = "application/json";
            var response = httpWebRequest.GetResponse();
            {
                string responseData;
                Stream responseStream = response.GetResponseStream();
                try
                {
                    StreamReader streamReader = new StreamReader(responseStream);
                    try
                    {
                        responseData = streamReader.ReadToEnd();
                    }
                    finally
                    {
                        ((IDisposable)streamReader).Dispose();
                    }
                }
                finally
                {
                    ((IDisposable)responseStream).Dispose();

                }
                phongban = JsonConvert.DeserializeObject<SuaPhongBan>(responseData);
            }
            return View(phongban);
        }


        [HttpPost]
        public IActionResult Edit(SuaPhongBan model)
        {
            int ketqua = 0;
            var url = $"{Common.Common.AplUrl}/phongban/suaphongban";
            HttpWebRequest httpWebRequest = (HttpWebRequest)WebRequest.Create(url);
            httpWebRequest.Method = "PUT";
            httpWebRequest.ContentType = "application/json";
            using (var streamWriter = new StreamWriter(httpWebRequest.GetRequestStream()))
            {
                var json = JsonConvert.SerializeObject(model);
                streamWriter.Write(json);
            }
            var httpResponse = (HttpWebResponse)httpWebRequest.GetResponse();
            using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
            {

                var resKetQua = streamReader.ReadToEnd();
                ketqua = int.Parse(resKetQua);
            }
            if (ketqua > 0)
            {
                TempData["thanh cong"] = "da sua";
            }

            ModelState.Clear();

            return View(new SuaPhongBan() { });
        }



      
        public IActionResult Delete(int id)
        {
            var kq = false;
            var url = $"{Common.Common.AplUrl}/phongban/xoaphongban/{id}";
            HttpWebRequest httpWebRequest = (HttpWebRequest)WebRequest.Create(url);
            httpWebRequest.Method = "DELETE";
            httpWebRequest.ContentType = "application/json";
            var response = httpWebRequest.GetResponse();
            {
                string responseData;
                Stream responseStream = response.GetResponseStream();
                try
                {
                    StreamReader streamReader = new StreamReader(responseStream);
                    try
                    {
                        responseData = streamReader.ReadToEnd();
                    }
                    finally
                    {
                        ((IDisposable)streamReader).Dispose();
                    }
                }
                finally
                {
                    ((IDisposable)responseStream).Dispose();

                }
                kq = JsonConvert.DeserializeObject<bool>(responseData);
            }
            return RedirectToAction("Index", "PhongBan");
        }

        public IActionResult E(int id)
        {
            var phongban = new SuaPhongBan();
            var url = $"{Common.Common.AplUrl}/phongban/danhsachphongban/{id}";
            HttpWebRequest httpWebRequest = (HttpWebRequest)WebRequest.Create(url);
            httpWebRequest.Method = "GET";
            // httpWebRequest.ContentType = "application/json";
            var response = httpWebRequest.GetResponse();
            {
                string responseData;
                Stream responseStream = response.GetResponseStream();
                try
                {
                    StreamReader streamReader = new StreamReader(responseStream);
                    try
                    {
                        responseData = streamReader.ReadToEnd();
                    }
                    finally
                    {
                        ((IDisposable)streamReader).Dispose();
                    }
                }
                finally
                {
                    ((IDisposable)responseStream).Dispose();

                }
                phongban = JsonConvert.DeserializeObject<SuaPhongBan>(responseData);
            }
            return View(phongban);
        }

    }
}
