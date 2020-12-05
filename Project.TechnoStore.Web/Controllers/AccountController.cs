using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Project.TechnoStore.Entities.Concrete;
using Project.TechnoStore.Web.Models;

namespace Project.TechnoStore.Web.Controllers
{
    public class AccountController : Controller
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly SignInManager<AppUser> _signInManager;
        public AccountController(UserManager<AppUser> userManager, SignInManager<AppUser> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }
        
        
        public IActionResult Login() => View(new UserLoginViewModel());

        [HttpPost]
        public async Task<IActionResult> Login(UserLoginViewModel model)
        {
            if (ModelState.IsValid)
            {
                var user = await _userManager.FindByNameAsync(model.UserName);
                if (user != null)
                {
                    var identityResult =
                        await _signInManager.PasswordSignInAsync(model.UserName, model.Password, false, false);

                    if (identityResult.Succeeded)
                    {
                        var roles = await _userManager.GetRolesAsync(user);

                        if (roles.Contains("Admin"))
                        {
                            return RedirectToAction("Index", "Home", new { area = "Admin" });
                        }

                        return RedirectToAction("Index", "Home");
                    }
                }
                ModelState.AddModelError("", "Bu kullanıcı adı bulunmadı.");
            }
            return View();
        }

        public async Task<IActionResult> LogOut()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction("Login");
        }

        public IActionResult Register()
        {
            return View(new AppUserAddViewModel());
        }

        [HttpPost]
        public async Task<IActionResult> Register(AppUserAddViewModel model)
        {
            if (ModelState.IsValid)
            {
                AppUser user = new AppUser
                {
                    Name = model.Name,
                    Surname = model.Surname,
                    UserName = model.UserName,
                    Email = model.Email
                };
               var result = await _userManager.CreateAsync(user, model.Password);

               if (result.Succeeded)
               {
                   var roleResult = await _userManager.AddToRoleAsync(user, "Member");

                   if (roleResult.Succeeded)
                   {
                       return RedirectToAction("Login");
                   }
                   else
                   {
                       foreach (var item in roleResult.Errors)
                       {
                           ModelState.AddModelError("", item.Description);
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

    }
}
