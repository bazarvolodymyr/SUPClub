using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using SUPClub.Data.Entities;
using SUPClub.Models.DTO.HireSubCategoryDTO;
using SUPClub.Services.Abstract;

namespace SUPClub.Controllers.admin
{
    [Authorize(Roles = "admin")]
    public class AdminHireSubCategoryController : Controller
    {
        private readonly IHireSubCategoryService _hireSubCategoryService;
        private readonly IHireCategoryService _hireCategoryService;
        private UserManager<AppUser> _userManager;
        public AdminHireSubCategoryController(IHireSubCategoryService hireSubCategoryService,
                                              IHireCategoryService hireCategoryService,
                                              UserManager<AppUser> userManager)
        {
            _hireSubCategoryService = hireSubCategoryService;
            _hireCategoryService = hireCategoryService;
            _userManager = userManager;
        }
        public async Task<IActionResult> Index()
        {
            ViewBag.HireSubCategories = await _hireSubCategoryService.GetAllInfoAsync();
            return View();
        }
        
        [HttpGet]
        public async Task<IActionResult> EditSubCategory([FromRoute] int id)
        {
            ViewBag.ViewCategories = await _hireCategoryService.GetActiveViewInfoAsync();
            if (id == default)
            {
                return View(new EditHireSubCategoryVM());
            }
            var editSubCategory = await _hireSubCategoryService.GetEditModelAsync(id);
            if (editSubCategory == null)
            {
                return NotFound();
            }
            return View(editSubCategory);
        }
        [HttpPost]
        public async Task<IActionResult> EditSubCategory(EditHireSubCategoryVM model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            var appUser = await _userManager.GetUserAsync(User);
            var error = await _hireSubCategoryService.SaveAsync(model, appUser!.Id);
            if (error != null)
            {
                return NotFound(error);
            }
            return RedirectToAction("Index");
        }
        [HttpGet]
        public async Task<IActionResult> DeleteSubCategory([FromRoute] int id)
        {
            var subCategory = await _hireSubCategoryService.GetEditModelAsync(id);
            if (subCategory == null)
            {
                return NotFound();
            }
            return View(subCategory);
        }
        [HttpPost]
        public async Task<IActionResult> DeleteSubCategory(EditHireSubCategoryVM model)
        {
            if (!ModelState.IsValid)
            {
                return NotFound();
            }
            var error = await _hireSubCategoryService.DeleteAsync(model.Id);
            if (error != null)
            {
                ModelState.AddModelError(string.Empty, error);
                return View(model);
            }
            return RedirectToAction("Index");
        }
    }
}
