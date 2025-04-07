using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using SUPClub.Data.Entities;
using SUPClub.Models.DTO.EquipmentDTO;
using SUPClub.Models.DTO.HieCategoryDTO;
using SUPClub.Services.Abstract;

namespace SUPClub.Controllers.admin
{
    [Authorize(Roles = "admin")]
    public class AdminEquipmentController : Controller
    {
        private readonly IEquipmentService _equipmentService;
        private readonly IHireCategoryService _hireCategoryService;
        private readonly UserManager<AppUser> _userManager;
        public AdminEquipmentController(IEquipmentService equipmentService,
                                        IHireCategoryService hireCategoryService,
                                        UserManager<AppUser> userManager)
        {
            _equipmentService = equipmentService;
            _hireCategoryService = hireCategoryService;
            _userManager = userManager;
        }
        public async Task<IActionResult> Index()
        {
            return View(await _equipmentService.GetAllInfoAsync());
        }
        [HttpGet]
        public async Task<IActionResult> GetSubCategories(int categoryId)
        {
            var categories = await _hireCategoryService.CategoriesListAsync();
            var subCategories = categories.FirstOrDefault(c => c.Id == categoryId)?.subCategory;
            return Json(subCategories ?? new List<SubCategory>());
        }
        [HttpGet]
        public async Task<IActionResult> EditEquipment(int id)
        {
            ViewBag.Categories = await _hireCategoryService.CategoriesListAsync();
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
                ViewBag.Categories = await _hireCategoryService.CategoriesListAsync();
                return View(model);
            }
            var appUser = await _userManager.GetUserAsync(User);
            var error = await _equipmentService.SaveAsync(model, appUser!.Id, titleImageFile);
            if (error != null)
            {
                ViewBag.Categories = await _hireCategoryService.CategoriesListAsync();
                ModelState.AddModelError(string.Empty, error);
                return View(model);
            }
            return RedirectToAction("Index");
        }
        [HttpGet]
        public async Task<IActionResult> DeleteEquipment(int id)
        {
            var equipment = await _equipmentService.GetEditModelAsync(id);
            if (equipment == null)
            {
                return NotFound();
            }
            return View(equipment);
        }
        [HttpPost]
        public async Task<IActionResult> DeleteEquipment(EditEquipmentVM deleteModel)
        {
            if (!ModelState.IsValid)
            {
                return View(deleteModel);
            }
            var error = await _equipmentService.DeleteAsync(deleteModel.Id);
            if (error != null)
            {
                ModelState.AddModelError(string.Empty, error);
                return View(deleteModel);
            }
            return RedirectToAction("Index");
        }
    }
}
