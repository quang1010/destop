using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using WebApplication8.Models;
using WebApplication8.ViewModels;

namespace WebApplication8.Controllers
{
    public class HomeController : Controller
    {
        private IFlowerRepository flowerRepository;
        private readonly IWebHostEnvironment webHostEnvironment;

       public HomeController(IFlowerRepository flowerRepository,
                            IWebHostEnvironment webHostEnvironment)
        {
            this.flowerRepository = flowerRepository;
            this.webHostEnvironment = webHostEnvironment;
        }

        
        public ViewResult Index()
        {

            var flowers = flowerRepository.Gets();
            return View(flowers);
        }
        public ViewResult Index1()
        {

            var flowers = flowerRepository.Gets();
            return View(flowers);
        }


        public ViewResult Details(int? id)
        {
            try
            {
                int.Parse(id.Value.ToString());
                var flower =flowerRepository.Get(id.Value);
                if (flower == null)
                {
                    //ViewBag.Id = id.Value;
                    return View("~/Views/Error/FlowerNotFound.cshtml", id.Value);
                }
                var detailViewModel = new HomeDetailViewModel()
                {
                   Flower = flowerRepository.Get(id ?? 1),
                    TitleName = "Employee Detail"
                };
                return View(detailViewModel);
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        [HttpGet]
        public ViewResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(HomeCreateViewModel model)
        {
            if (ModelState.IsValid)
            {
                var flower = new Flower()
                {
                    Name = model.Name,
                   
                    TypeF = model.TypeF
                };
                var fileName = string.Empty;
                if (model.Avatar != null)
                {
                    string uploadFolder = Path.Combine(webHostEnvironment.WebRootPath, "images");
                    fileName = $"{Guid.NewGuid()}_{model.Avatar.FileName}";
                    var filePath = Path.Combine(uploadFolder, fileName);
                    using (var fs = new FileStream(filePath, FileMode.Create))
                    {
                        model.Avatar.CopyTo(fs);
                    }
                }
                flower.AvatarPath = fileName;
                var newEmp = flowerRepository.Create(flower);
                return RedirectToAction("Details", new { id = newEmp.Id });
            }
            return View();
        }

        public ViewResult Edit(int id)
        {
            var flower = flowerRepository.Get(id);
            if (flower == null)
            {
                return View("~/Views/Error/FlowerNotFound.cshtml", id);
            }
            var empEdit = new HomeEditViewModel()
            {
                AvatarPath = flower.AvatarPath,
                Name = flower.Name,
             
                TypeF = flower.TypeF,
                Id = flower.Id
            };
            return View(empEdit);
        }

        [HttpPost]
        public IActionResult Edit(HomeEditViewModel model)
        {
            if (ModelState.IsValid)
            {
                var flower = new Flower()
                {
                    Name = model.Name,
                    
                    TypeF = model.TypeF,
                    Id = model.Id,
                    AvatarPath = model.AvatarPath
                };
                var fileName = string.Empty;
                if (model.Avatar != null)
                {
                    string uploadFolder = Path.Combine(webHostEnvironment.WebRootPath, "images");
                    fileName = $"{Guid.NewGuid()}_{model.Avatar.FileName}";
                    var filePath = Path.Combine(uploadFolder, fileName);
                    using (var fs = new FileStream(filePath, FileMode.Create))
                    {
                        model.Avatar.CopyTo(fs);
                    }
                    flower.AvatarPath = fileName;
                    if (!string.IsNullOrEmpty(model.AvatarPath))
                    {
                        string delFile = Path.Combine(webHostEnvironment.WebRootPath,
                                            "images", model.AvatarPath);
                        System.IO.File.Delete(delFile);
                    }
                }

                var editEmp = flowerRepository.Edit(flower);
                if (editEmp != null)
                {
                    return RedirectToAction("Details", new { id = flower.Id });
                }
            }

            return View();
        }

        public IActionResult Delete(int id)
        {
            if (flowerRepository.Delete(id))
            {
                return RedirectToAction("Index");
            }
            return View();
        }















        public ViewResult Index2()
        {

           
            return View();
        }
        
    }
}
