using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Project.abznotebook.Entities.Concrete;
using Project.abznotebook.Web.Areas.Member.Models;

namespace Project.abznotebook.Web.Areas.Member.Controllers
{
    [Area("Member")]
    public class SettingsController : Controller
    {

        private readonly UserManager<AppUser> _userManager;

        public SettingsController(UserManager<AppUser> userManager)
        {
            _userManager = userManager;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var user = await _userManager.FindByNameAsync(User.Identity.Name);

            EditUserViewModel model = new EditUserViewModel()
            {
                Name = user.Name,
                Surname = user.Surname,
                Email = user.Email,
                Tel = user.PhoneNumber,
            };

            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Index(EditUserViewModel user)
        {

            AppUser updatedUser = await _userManager.FindByNameAsync(User.Identity.Name);

            

            if (user.OldPassword != null)
            {
                PasswordVerificationResult passwordMatch =
                    _userManager.PasswordHasher.VerifyHashedPassword(updatedUser, updatedUser.PasswordHash,
                        user.OldPassword);

                if (passwordMatch == PasswordVerificationResult.Failed)
                {
                    ModelState.AddModelError("", "Eski Şifreniz Yanlış!");
                    return View(user);
                }
            }

            if (user.NewPassword != null)
            {
                PasswordVerificationResult passwordMatch =
                    _userManager.PasswordHasher.VerifyHashedPassword(updatedUser, updatedUser.PasswordHash, user.NewPassword);

                if (passwordMatch == PasswordVerificationResult.Success)
                {
                    ModelState.AddModelError("", "Yeni Şifreyle Eski Şifre Aynı Olamaz.");
                    return View(user);
                }
            }

            


            if (ModelState.IsValid)
            {
                updatedUser.Email = user.Email;
                updatedUser.Name = user.Name;
                updatedUser.Surname = user.Surname;
                updatedUser.PhoneNumber = user.Tel;

                if (user.NewPassword != null)
                {
                    var passwordToken = await _userManager.GeneratePasswordResetTokenAsync(updatedUser);
                    await _userManager.ResetPasswordAsync(updatedUser, passwordToken, user.NewPassword);
                }

                var result = await _userManager.UpdateAsync(updatedUser);

                if (result.Succeeded)
                {
                    return RedirectToAction("Index", "Home");
                }

            }

            return View(user);
        }
    }
}
