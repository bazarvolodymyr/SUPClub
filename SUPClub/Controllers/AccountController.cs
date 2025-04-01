using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using SUPClub.Data.Entities;
using SUPClub.Models.DTO;

namespace SUPClub.Controllers
{
    public class AccountController : Controller
    {
        private SignInManager<AppUser> _signInManager;

        public AccountController(SignInManager<AppUser> signInManager)
        {
            _signInManager = signInManager;
        }

        [HttpGet]
        public async Task<IActionResult> Login(string? returnUrl)
        {
            await _signInManager.SignOutAsync();
            ViewBag.ReturnUrl = returnUrl;
            return View(new LoginVM());
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginVM model, string? returnUrl)
        {
            ViewBag.ReturnUrl = returnUrl;
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            var result = await _signInManager
                .PasswordSignInAsync(model.UserName!, model.Password!, model.RememberMe, false);
            if (result.Succeeded)
            {
                return Redirect(returnUrl ?? "/");
            }
            ModelState.AddModelError(string.Empty, "Неправильний логін чи пароль");
            return View(model);
        }
        [HttpPost]
        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction("Index", "Home");
        }
    }
}
