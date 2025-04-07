using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using SUPClub.Data.Entities;
using SUPClub.Models.DTO.HieCategoryDTO;
using SUPClub.Services.Abstract;

namespace SUPClub.Controllers.admin
{
    [Authorize(Roles = "admin")]
    public class AdminHireCategoryController : Controller
    {
        private readonly IHireCategoryService _hireCategoryService;
        private readonly UserManager<AppUser> _userManager;
        public AdminHireCategoryController(IHireCategoryService hireCategoryService,
                                            UserManager<AppUser> userManager)
        {
            _hireCategoryService = hireCategoryService;
            _userManager = userManager;
        }
        public async Task<IActionResult> Index()
        {
            return View(await _hireCategoryService.GetAllInfoAsync());
        }
        
        [HttpGet]
        public async Task<IActionResult> EditCategory([FromRoute]int id)
        {
            if (id == default)
            {
                return View(new EditHireCategoryVM());
            }
            var editCategory = await _hireCategoryService.GetEditModelAsync(id);
            if (editCategory == null)
            {
                return NotFound();
            }
            return View(editCategory);
        }
        [HttpPost]
        public async Task<IActionResult> EditCategory(EditHireCategoryVM model, IFormFile? titleImageFile)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            var appUser = await _userManager.GetUserAsync(User);
            var error = await _hireCategoryService.SaveAsync(model, titleImageFile, appUser!.Id);
            if (error != null)
            {
                return NotFound(error);
            }
            return RedirectToAction("Index");
        }
        [HttpGet]
        public async Task<IActionResult> DeleteCategory([FromRoute] int id)
        {
            var editCategory = await _hireCategoryService.GetEditModelAsync(id);
            if (editCategory == null)
            {
                return NotFound();
            }
            return View(editCategory);
        }
        [HttpPost]
        public async Task<IActionResult> DeleteCategory(EditHireCategoryVM model)
        {
            if (!ModelState.IsValid)
            {
                return NotFound();
            }
            var error = await _hireCategoryService.DeleteAsync(model.Id);
            if (error != null)
            {
                ModelState.AddModelError(string.Empty, error);
                return View(model);
            }
            return RedirectToAction("Index");
        }
    }
}
