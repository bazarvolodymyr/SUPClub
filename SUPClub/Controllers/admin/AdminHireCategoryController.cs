using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using SUPClub.Data.Entities;
using SUPClub.Data.Repositories.Abstract;
using SUPClub.Infrastructure;
using SUPClub.Models;
using SUPClub.Models.DTO;

namespace SUPClub.Controllers.admin
{
    [Authorize(Roles = "admin")]
    public class AdminHireCategoryController : Controller
    {
        private IHireCategoryRepository _hireCategoryRepository;
        private UserManager<AppUser> _userManager;
        private ImageHandler _imageHandler;
        public AdminHireCategoryController(IHireCategoryRepository hireCategoryRepository,
                                            UserManager<AppUser> userManager,
                                            ImageHandler imageHandler)
        {
            _hireCategoryRepository = hireCategoryRepository;
            _userManager = userManager;
            _imageHandler = imageHandler;
        }
        public IActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public IActionResult AddCategory(string? returnUrl)
        {
            ViewBag.returnUrl = returnUrl;
            return View(new CreateHireCategoryVM());
        }
        [HttpPost]
        public async Task<IActionResult> AddCategory(CreateHireCategoryVM model, IFormFile titleImageFile)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            if (titleImageFile != null)
            {
                model.ImageUrl = titleImageFile.FileName;
                await _imageHandler.SaveImg(titleImageFile);
            }
            var appUser = await _userManager.GetUserAsync(User);
            var category = HireCategory.Create(model.Name, model.ImageUrl,
                appUser!.Id, model.IsActive);
            await _hireCategoryRepository.SaveHireCategoryAsync(category);
            return RedirectToAction("Index"); 
        }
    }
}
