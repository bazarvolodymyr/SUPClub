using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using SUPClub.Data.Entities;
using SUPClub.Data.Repositories.Abstract;
using SUPClub.Infrastructure;
using SUPClub.Models;
using SUPClub.Models.DTO.HieCategoryDTO;
using SUPClub.Models.DTO.HireSubCategoryDTO;

namespace SUPClub.Controllers.admin
{
    [Authorize(Roles = "admin")]
    public class AdminHireSubCategoryController : Controller
    {
        private IHireSubCategoryRepository _hireSubCategoryRepository;
        private IHireCategoryRepository _hireCategoryRepository;
        private UserManager<AppUser> _userManager;
        public AdminHireSubCategoryController(IHireSubCategoryRepository hireSubCategoryRepository,
                                              IHireCategoryRepository hireCategoryRepository,
                                              UserManager<AppUser> userManager)
        {
            _hireSubCategoryRepository = hireSubCategoryRepository;
            _hireCategoryRepository = hireCategoryRepository;
            _userManager = userManager;
        }
        public async Task<IActionResult> Index()
        {
            var subCategories = await _hireSubCategoryRepository.GetHireSubCategoriesAsync();
            var categoriesInfo = new List<HireSubCategoryInfoVM>();
            if (subCategories == null)
            {
                ViewBag.HireSubCategories = categoriesInfo;
                return View();
            }
            
            foreach (var subCategory in subCategories)
            {
                string userName = "";
                string categoryName = "";
                var category = await _hireCategoryRepository.GetHireCategoryByIdAsync(subCategory.HireCategoryId);
                if (subCategory.CreateById != null)
                {
                    var user = await _userManager.FindByIdAsync(subCategory.CreateById);
                    userName = user!.UserName ?? "";
                }
                if (category != null)
                {
                    categoryName = category.Name!;
                }
                categoriesInfo.Add(new HireSubCategoryInfoVM()
                {
                    Id = subCategory.Id,
                    Name = subCategory.Name,
                    HireCategoryId = subCategory.HireCategoryId,
                    CategoryName = categoryName,
                    IsActive = subCategory.IsActive,
                    CreateAt = userName,
                    CreatedDate = subCategory.CreateDate,
                    UpdateDate = subCategory.UpdateDate
                });
            }
            ViewBag.HireSubCategories = categoriesInfo;
            return View();
        }
        [HttpGet]
        public async Task<IActionResult> AddSubCategory()
        {
            ViewBag.ViewCategories  = await _hireCategoryRepository.GetActiveViewHireCategoriesAsync();
            return View(new CreateHireSubCategoryVM());
        }
        [HttpPost]
        public async Task<IActionResult> AddSubCategory(CreateHireSubCategoryVM model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            
            var appUser = await _userManager.GetUserAsync(User);
            var subCategory = HireSubCategory.Create(model.Name, model.HireCategoryId, model.IsActive, appUser!.Id);
            await _hireSubCategoryRepository.SaveHireSubCategoryAsync(subCategory);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public async Task<IActionResult> EditSubCategory([FromRoute] int id)
        {
            var sudCategory = await _hireSubCategoryRepository.GetHireSubCategoryByIdAsync(id);
            ViewBag.ViewCategories = await _hireCategoryRepository.GetActiveViewHireCategoriesAsync();
            if (sudCategory == null)
            {
                return NotFound();
            }
            var editSubCategory = new EditHireSubCategoryVM()
            {
                Id = sudCategory.Id,
                Name = sudCategory.Name,
                HireCategoryId = sudCategory.HireCategoryId,
                IsActive = sudCategory.IsActive
            };
            return View(editSubCategory);
        }
        [HttpPost]
        public async Task<IActionResult> EditSubCategory(EditHireSubCategoryVM model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            var subCategory = await _hireSubCategoryRepository.GetHireSubCategoryByIdAsync(model.Id);
            if (subCategory == null)
            {
                return NotFound();
            }

            subCategory.Update(model.Name, model.HireCategoryId, model.IsActive);
            await _hireSubCategoryRepository.SaveHireSubCategoryAsync(subCategory);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public async Task<IActionResult> DeleteSubCategory([FromRoute] int id)
        {
            var subCategory = await _hireSubCategoryRepository.GetHireSubCategoryByIdAsync(id);
            if (subCategory == null)
            {
                return NotFound();
            }
            var editCategory = new EditHireSubCategoryVM()
            {
                Id = subCategory.Id,
                Name = subCategory.Name,
                HireCategoryId = subCategory.HireCategoryId,
                IsActive = subCategory.IsActive
            };
            return View(editCategory);
        }
        [HttpPost]
        public async Task<IActionResult> DeleteSubCategory(EditHireSubCategoryVM model)
        {
            if (!ModelState.IsValid)
            {
                return NotFound();
            }
            var equipment = await _hireSubCategoryRepository.GetHireSubCategoryByIdAsync(model.Id);
            if (equipment == null)
            {
                return NotFound();
            }
            if (equipment.Equipments.Any())
            {
                ModelState.AddModelError(string.Empty, "Підкатегорія містить продукти!");
                return View(model);
            }
            await _hireSubCategoryRepository.DeleteHireSubCategoryAsync(model.Id);
            return RedirectToAction("Index");
        }
    }
}
