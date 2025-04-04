using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using SUPClub.Data.Entities;
using SUPClub.Models.DTO.AccountDTO;

namespace SUPClub.Controllers
{
    public class AccountController : Controller
    {
        private SignInManager<AppUser> _signInManager;
        private UserManager<AppUser> _userManager;

        public AccountController(SignInManager<AppUser> signInManager, UserManager<AppUser> userManager)
        {
            _signInManager = signInManager;
            _userManager = userManager;
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
        [HttpGet]
        public IActionResult Register(string? returnUrl)
        {
            ViewBag.returnUrl = returnUrl;
            return View(new RegisterUserVM());
        }
        [HttpPost]
        public async Task<IActionResult> Register(RegisterUserVM model, string? returnUrl)
        {
            ViewBag.returnUrl = returnUrl;
            if (ModelState.IsValid)
            {
                if (await _userManager.FindByEmailAsync(model.Email!) != null)
                {
                    ModelState.AddModelError(string.Empty, "Такий Email вже зайнято");
                    return View(model);
                }
                if (await _userManager.FindByNameAsync(model.UserName!) != null)
                {
                    ModelState.AddModelError(string.Empty, "Такий логін вже зайнято");
                    return View(model);
                }
                AppUser user = new AppUser { Email = model.Email,
                                            FirsName = model.FirstName,
                                            LastName = model.LastName,
                                            NormalizedEmail = model.Email,
                                            PhoneNumber = model.Phone,
                                            UserName = model.UserName, 
                                            NormalizedUserName = model.UserName!.ToUpper() };
                var result = await _userManager.CreateAsync(user, model.Password!);
                if (result.Succeeded)
                {
                    await _signInManager.SignInAsync(user, false);
                    return Redirect(returnUrl ?? "/");
                }
                else
                {
                    foreach (var error in result.Errors)
                    {
                        ModelState.AddModelError(string.Empty, error.Description);
                    }
                }
            }
            return View(model);
        }
    }
}
