using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using WebApplication5.Models;
using WebApplication5.ViewModel;

namespace WebApplication5.Controllers
{
    public class HomeController : Controller
    {
        private readonly ICakeRepository studentRepository;

        private readonly IClassRepository classRepository;

        public HomeController(ICakeRepository studentRepository,

            IClassRepository classRepository)
        {
            this.studentRepository = studentRepository;

            this.classRepository = classRepository;
        }
        public IActionResult Index()
        {

            var indexViewModel = (from cl in classRepository.Gets().ToList()
                                  select new ClassIndexViewModel()
                                  {
                                      CategoryId = cl.CategoryId,
                                      CategoryName = cl.CategoryName
                                  }).ToList();


            return View(indexViewModel);
        }

        [HttpGet]
        public ViewResult Create()
        {
            ViewBag.Classes = GetClasses();
            return View();
        }


        [HttpPost]
        public IActionResult Create(HomeCreateViewModel model)
        {
            if (ModelState.IsValid)
            {
                var student = new Cake()
                {


                    nameCake = model.nameCake,
                    ThanhPhan = model.ThanhPhan,

                    Hsd = model.Hsd,
                    Nsx = model.Nsx,
                    GiaBan = model.GiaBan,
                    DaXoa = model.DaXoa,
                    CategoryId = model.CategoryId


                };

                var newStd = studentRepository.Create(student);
                if (newStd != null)
                {
                    return RedirectToAction("Index", "Home");
                }

            }
            //ViewBag.Classes = GetClasses();
            return View();
        }

        public IActionResult ViewDetail(int id)
        {
            var detailView = (from st in studentRepository.Gets().ToList()
                              join cl in classRepository.Gets().ToList() on st.CategoryId equals cl.CategoryId
                              where cl.CategoryId == id
                              select new DetailViewModel()
                              {
                                  Id = st.Id,
                                  nameCake = st.nameCake,
                                  ThanhPhan = st.ThanhPhan,
                                  Hsd = st.Hsd,
                                  Nsx = st.Nsx,
                                  GiaBan = st.GiaBan,
                                  DaXoa = st.DaXoa,
                                  CategoryId = st.CategoryId,
                                  CategoryName = cl.CategoryName
                              }).ToList();

            return View(detailView);
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {

            var student = studentRepository.Get(id);
            var editStudent = new HomeEditViewModel()
            {
                Id = student.Id,

                nameCake = student.nameCake,
                ThanhPhan = student.ThanhPhan,

                Hsd = student.Hsd,
                Nsx = student.Nsx,
                GiaBan = student.GiaBan,
                DaXoa = student.DaXoa,
                CategoryId = student.CategoryId
            };
            ViewBag.Category = GetClasses();
            return View(editStudent);
        }

        [HttpPost]
        public IActionResult Edit(HomeEditViewModel model)
        {
            if (ModelState.IsValid)
            {
                var editStd = new Cake()
                {
                    Id = model.Id,
                    nameCake = model.nameCake,
                    ThanhPhan = model.ThanhPhan,

                    Hsd = model.Hsd,
                    Nsx = model.Nsx,
                    GiaBan = model.GiaBan,
                    DaXoa = model.DaXoa,
                    CategoryId = model.CategoryId
                };
                studentRepository.Edit(editStd);


                return RedirectToAction("ViewDetail", "Home", new { id = editStd.CategoryId });

            }
            ViewBag.Category = GetClasses();
            return View();

        }
        public IActionResult Delete(int id)
        {
            var student = studentRepository.Get(id);
            studentRepository.Delete(id);

            return RedirectToAction("ViewDetail", "Home", new { id = student.CategoryId });
        }
        public IActionResult Privacy()
        {
            return View();
        }

        public List<Category> GetClasses()
        {
            return classRepository.Gets().ToList();
        }
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }



        public IActionResult Details(int? id)
        {
            var st = studentRepository.Get(id ?? 1);
            var stu = new D()
            {
                Id = st.Id,
                nameCake = st.nameCake,
                ThanhPhan = st.ThanhPhan,

                Hsd = st.Hsd,
                Nsx = st.Nsx,
                GiaBan = st.GiaBan,
                DaXoa = st.DaXoa,
                CategoryName = st.CategoryName


            };
            return View(stu);
        }




    }
}
