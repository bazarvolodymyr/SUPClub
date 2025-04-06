using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using SUPClub.Data.Entities;
using SUPClub.Models;
using SUPClub.Models.DTO.EquipmentDTO;
using SUPClub.Services.Abstract;

namespace SUPClub.Controllers.admin
{
    [Authorize(Roles = "admin")]
    public class AdminEquipmentController : Controller
    {
        private readonly IEquipmentService _equipmentService;
        private readonly IHireCategoryService _hireCategoryService;
        private readonly IHireSubCategoryService _hireSubCategoryService;
        private readonly UserManager<AppUser> _userManager;
        public AdminEquipmentController(IEquipmentService equipmentService,
                                        IHireCategoryService hireCategoryService,
                                        IHireSubCategoryService hireSubCategoryService,
                                        UserManager<AppUser> userManager)
        {
            _equipmentService = equipmentService;
            _hireCategoryService = hireCategoryService;
            _hireSubCategoryService = hireSubCategoryService;
            _userManager = userManager;
        }
        public async Task<IActionResult> Index()
        {
            return View(await _equipmentService.GetAllInfoAsync());
        }
        [HttpGet]
        public async Task<IActionResult> GetSubCategories(int categoryId)
        {
            var categories = await _equipmentService.CategoriesListAsync();
            var subCategories = categories.FirstOrDefault(c => c.Id == categoryId)?.HireSubCategories;
            return Json(subCategories ?? new List<HireSubCategory>());
        }
        [HttpGet]
        public async Task<IActionResult> EditEquipment(int id)
        {
            ViewBag.Categories = await _equipmentService.CategoriesListAsync();
            if (id == default)
            {
                return View(new EditEquipmentVM());
            }
            var editEquipment = await _equipmentService.GetEditModelAsync(id);
            if (editEquipment == null)
            {
                return NotFound();
            }
            return View(editEquipment);
        }
        [HttpPost]
        public async Task<IActionResult> EditEquipment(EditEquipmentVM model,
                                                        IFormFile? titleImageFile)
        {
            if (!ModelState.IsValid)
            {
                ViewBag.Categories = await _equipmentService.CategoriesListAsync();
                return View(model);
            }
            var appUser = await _userManager.GetUserAsync(User);
            var error = await _equipmentService.SaveAsync(model, appUser!.Id, titleImageFile);
            if (error != null)
            {
                ViewBag.Categories = await _equipmentService.CategoriesListAsync();
                ModelState.AddModelError(string.Empty, error);
                return View(model);
            }
            return RedirectToAction("Index");
        }
    }
}
