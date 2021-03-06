﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication8.Models;
using WebApplication8.ViewModels;

namespace WebApplication8.Controllers
{
    //public class UserController : Controller
    //{
    //    private readonly UserManager<ApplicationUser> userManager;
    //    private readonly SignInManager<ApplicationUser> signInManager;
    //    private readonly RoleManager<IdentityRole> roleManager;

    //    public UserController(UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager, RoleManager<IdentityRole> roleManager)
    //    {
    //        this.userManager = userManager;
    //        this.signInManager = signInManager;
    //        this.roleManager = roleManager;
    //    }

    //    public IActionResult Index()
    //    {

    //        var users = userManager.Users;
    //        if(users!=null&& users.Any())
    //        {
    //            var model = new List<UserViewModel>();
    //            model = users.Select(u => new UserViewModel()
    //            {
    //                UserId = u.Id,
    //                Address = u.Address,
    //                City = u.City,
    //                Email = u.Email,
    //                RolesName = u.Email

    //            }).ToList();

    //            foreach (var pb in model)
    //            {
    //                pb.RolesName = GetRoLet(pb.UserId);
    //            }
    //            return View(model);
    //        }

    //        return View();


    //    }
    //    public string GetRoLet(string id)
    //    {
    //        var user = Task.Run(async () => await userManager.FindByIdAsync(id)).Result;
    //        var role = Task.Run(async () => await userManager.GetRolesAsync(user)).Result;
    //        return role != null ? string.Join("", role) : string.Empty;
    //    }

    //    [HttpGet]
    //    public IActionResult Create()
    //    {
    //        ViewBag.Roles = roleManager.Roles;
    //        return View();
    //    }
    //    [HttpPost]
    //    public async Task<IActionResult> Create(UserCreateViewModel model)
    //    {
    //        if (ModelState.IsValid)
    //        {
    //            var user = new ApplicationUser()
    //            {
    //                Email = model.Email,
    //                UserName = model.Email,
    //                City = model.City,
    //                Address = model.Address
    //            };
    //            var result = await userManager.CreateAsync(user, model.Password);
    //            if (result.Succeeded)
    //            {


    //                return RedirectToAction("Index", "User");
    //            }

    //            else
    //            {
    //                foreach (var error in result.Errors)
    //                {
    //                    ModelState.AddModelError("", error.Description);
    //                }
    //            }

    //        }
    //        return View(model);
    //    }


    //    [HttpGet]
    //    public async Task<IActionResult> Edit(string id)
    //    {
    //        var user = await userManager.FindByIdAsync(id);

    //        if(user!=null)
    //        {
    //            var model = new EditUserViewModel()
    //            {
    //                Address = user.Address,
    //                City = user.City,
    //                Email = user.Email,
    //                UserId = user.Id

    //            };
    //            var role = await userManager.GetRolesAsync(user);
    //            model.RoleId=role.FirstOrDefault(r)
    //            return View(model);


    //        }
    //        ViewBag.Roles = roleManager.Roles;
    //        return View();
    //    }
    //    [HttpPost]
    //    public async Task<IActionResult>Edit(EditUserViewModel model)
    //    {
    //        if(ModelState.IsValid)
    //        {
    //            var user = await userManager.FindByIdAsync(model.UserId);
    //            if(user!=null)
    //            {
    //                user.Email = model.Email;
    //                user.UserName = model.Email;
    //                user.Id = model.UserId;
    //                user.City = model.City;
    //                user.Address = model.Address;



    //                var result = await userManager.UpdateAsync(user);

    //                if (result.Succeeded)
    //                {
    //                    return RedirectToAction("Index", "User");
    //                }
    //                foreach (var error in result.Errors)
    //                {
    //                    ModelState.AddModelError("", error.Description);
    //                }
    //            }

    //        }
    //        return View(model);
    //    }
    //}








        [Authorize(Roles ="System Admin")]
    public class UserController : Controller
    {
        private readonly UserManager<ApplicationUser> userManager;
        private readonly SignInManager<ApplicationUser> signInManager;
        private readonly RoleManager<IdentityRole> roleManager;

        public UserController(UserManager<ApplicationUser> userManager,
                                SignInManager<ApplicationUser> signInManager,
                                RoleManager<IdentityRole> roleManager)
        {
            this.userManager = userManager;
            this.signInManager = signInManager;
            this.roleManager = roleManager;
        }

        public IActionResult Index()
        {

            var users = userManager.Users;
            if (users != null && users.Any())
            {
                var model = new List<UserViewModel>();
                model = users.Select(u => new UserViewModel()
                {
                    UserId = u.Id,
                    Address = u.Address,
                    City = u.City,
                    Email = u.Email

                }).ToList();
                foreach (var user in model)
                {
                    user.RolesName = GetRolesName(user.UserId);
                }
                return View(model);
            }
            return View();

        }
        public string GetRolesName(string userId)
        {
            var user = Task.Run(async () => await userManager.FindByIdAsync(userId)).Result;
            var roles = Task.Run(async () => await userManager.GetRolesAsync(user)).Result;
            return roles != null ? string.Join(",", roles) : string.Empty;
        }
        [HttpGet]

        public IActionResult Create()
        {
            ViewBag.Roles = roleManager.Roles;
            return View();
        }
        [HttpPost]

        public async Task<IActionResult> Create(UserCreateViewModel model)
        {
            if (ModelState.IsValid)
            {
                var user = new ApplicationUser()
                {
                    Email = model.Email,
                    UserName = model.Email,
                    City = model.City,
                    Address = model.Address
                };
                var result = await userManager.CreateAsync(user, model.Password);
                if (result.Succeeded)
                {
                    if (!string.IsNullOrEmpty(model.RoleId))
                    {
                        var role = await roleManager.FindByIdAsync(model.RoleId);
                        var addRoleResult = await userManager.AddToRoleAsync(user, role.Name);
                        if (addRoleResult.Succeeded)
                        {
                            return RedirectToAction("Index", "User");
                        }
                        foreach (var error in result.Errors)
                        {
                            ModelState.AddModelError("", error.Description);
                        }
                    }


                }
                else
                {
                    foreach (var error in result.Errors)
                    {
                        ModelState.AddModelError("", error.Description);
                    }
                }

            }
            return View(model);
        }
        [HttpGet]

        public async Task<IActionResult> Edit(string id)
        {
            var user = await userManager.FindByIdAsync(id);

            if (user != null)
            {
                var model = new EditUserViewModel()
                {
                    Address = user.Address,
                    City = user.City,
                    Email = user.Email,
                    UserId = user.Id
                };
                var rolesName = await userManager.GetRolesAsync(user);
                if (rolesName != null && rolesName.Any())
                {
                    var role = await roleManager.FindByNameAsync(rolesName.FirstOrDefault());
                    model.RoleId = role.Id;
                }
                ViewBag.Roles = roleManager.Roles;
                return View(model);
            }
            ViewBag.Roles = roleManager.Roles;
            return View();
        }
        [HttpPost]

        public async Task<IActionResult> Edit(EditUserViewModel model)
        {
            if (ModelState.IsValid)
            {
                var user = await userManager.FindByIdAsync(model.UserId);
                if (user != null)
                {
                    user.Email = model.Email;
                    user.UserName = model.Email;
                    user.Id = model.UserId;
                    user.City = model.City;
                    user.Address = model.Address;
                    var result = await userManager.UpdateAsync(user);

                    if (result.Succeeded)
                    {
                        var rolesName = await userManager.GetRolesAsync(user);
                        var delRole = await userManager.RemoveFromRolesAsync(user, rolesName);
                        if (!string.IsNullOrEmpty(model.RoleId))
                        {
                            var role = await roleManager.FindByIdAsync(model.RoleId);
                            var addRoleResult = await userManager.AddToRoleAsync(user, role.Name);
                            if (addRoleResult.Succeeded)
                            {
                                return RedirectToAction("Index", "User");
                            }
                            foreach (var error in result.Errors)
                            {
                                ModelState.AddModelError("", error.Description);
                            }
                        }
                        return RedirectToAction("Index", "User");
                    }
                    foreach (var error in result.Errors)
                    {
                        ModelState.AddModelError("", error.Description);
                    }
                }

            }
            return View(model);
        }
        [HttpGet]

        public async Task<IActionResult> Delete(string id)
        {
            var user = await userManager.FindByIdAsync(id);
            if (user != null)
            {
                var model = new DeleteUserViewModel()
                {
                    RoleId = user.UserName,
                    UserId = user.Id,
                    Email = user.Email,
                    City = user.City,
                    Address = user.Address,
                };
                var rolesName = await userManager.GetRolesAsync(user);
                if (rolesName != null && rolesName.Any())
                {
                    var role = await roleManager.FindByNameAsync(rolesName.FirstOrDefault());
                    model.RoleId = role.Id;
                }
                ViewBag.Roles = roleManager.Roles;
                return View(model);
            }
            else
            {
                return View("~/Views/Error/RoleNotFound.cshtml", id);
            }
        }
        [HttpPost]

        public async Task<IActionResult> Delete(DeleteUserViewModel model)
        {
            var delUser = await userManager.FindByIdAsync(model.UserId);
            if (delUser != null)
            {
                var result = await userManager.DeleteAsync(delUser);
                if (result.Succeeded)
                {
                    return RedirectToAction("Index", "User");
                }
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError("", error.Description);
                }
            }
            return View();

        }
    }
}
