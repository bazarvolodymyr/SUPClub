using Microsoft.AspNetCore.Mvc;
using SUPClub.Models.DTO.HieCategoryDTO;
using SUPClub.Models.DTO.HireSubCategoryDTO;
using SUPClub.Services.Abstract;

namespace SUPClub.Controllers
{
    public class HireController : Controller
    {
        private readonly IHireCategoryService _hireCategoryService;
        private readonly IHireSubCategoryService _hireSubCategoryService;
        private readonly IEquipmentService _equipmentService;
        public HireController(IHireCategoryService hireCategoryService,
                              IHireSubCategoryService hireSubCategoryService,
                              IEquipmentService equipmentService)
        {
            _hireSubCategoryService = hireSubCategoryService;       
            _hireCategoryService = hireCategoryService;
            _equipmentService = equipmentService;
        }
        public async Task<IActionResult> Index()
        {
            var categories = await _hireCategoryService.GetActiveCategoriesAsync();
            return View(categories);
        }
        public async Task<IActionResult> ShowCategory(int id)
        {
            var listCategories = await _hireCategoryService.GetActiveCategoriesAsync();
            var category = listCategories.Where(x => x.Id == id).FirstOrDefault();
            if (category == null)
            {
                return NotFound();
            }
            return View(category);
        }
        public async Task<IActionResult> ShowSubCategory(int id)
        {
            var categories = await _hireCategoryService.GetActiveCategoriesAsync();
            string? subCategory = "";
            var category = categories.Where(c => c.subCategory.Where(x => x.Id == id).Any())
                .FirstOrDefault();
            if (category != null)
            {
                 subCategory = category.subCategory.Where(x => x.Id == id)
                    .Select(x => x.Name)
                    .FirstOrDefault();
            }
            ViewBag.SubCategory = subCategory;
            var equipments = await _equipmentService.GetViewBySubCategoryIdAsync(id);
            if (equipments == null)
            {
                return NotFound();
            }
            return View(equipments);
        }
    }
}
