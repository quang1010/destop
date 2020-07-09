using Microsoft.AspNetCore.Authorization;
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
    public class UserController : Controller
    {
        private readonly UserManager<ApplicationUser> userManager;
        private readonly SignInManager<ApplicationUser> signInManager;
        private readonly RoleManager<IdentityRole> roleManager;

        public UserController(UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager, RoleManager<IdentityRole> roleManager)
        {
            this.userManager = userManager;
            this.signInManager = signInManager;
            this.roleManager = roleManager;
        }
        
        public IActionResult Index()
        {
            
            var users = userManager.Users;
            var model = users.Select(u => new UserViewModel()
            {
                UserId = u.Id,
                Address = u.Address,
                City = u.City,
                Email = u.Email,
                RolesName =u.Email
                
            }).ToList();

          foreach(var pb in model)
            {
                pb.RolesName = GetRoLet(pb.UserId);
            }  
            return View(model);

        } 
        public string GetRoLet(string id)
        {
            var user = Task.Run(async () => await userManager.FindByIdAsync(id)).Result;
            var role = Task.Run(async () => await userManager.GetRolesAsync(user)).Result;
            return role != null ? string.Join("", role) : string.Empty;
        }
    }

}
