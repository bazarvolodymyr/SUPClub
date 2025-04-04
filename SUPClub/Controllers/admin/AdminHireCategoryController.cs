using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using SUPClub.Data.Entities;
using SUPClub.Data.Repositories.Abstract;
using SUPClub.Infrastructure;
using SUPClub.Models;
using SUPClub.Models.DTO.HieCategoryDTO;

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
        public async Task<IActionResult> Index()
        {
            var categories = await _hireCategoryRepository.GetHireCategoriesAsync();
            if (categories == null)
            {
                ViewBag.HireCategories = new List<HireCategoryInfoVM>();
                return View();
            }
            var categoriesInfo = new List<HireCategoryInfoVM>();
            foreach (var category in categories)
            {
                string userName = "";
                if (category.CreateById != null)
                {
                    var user = await _userManager.FindByIdAsync(category.CreateById);
                    userName = user!.UserName ?? "";
                }
                
                categoriesInfo.Add(new HireCategoryInfoVM()
                {
                    Id = category.Id,
                    Name = category.Name,
                    ImageUrl = category.ImageUrl,
                    IsActive = category.IsActive,
                    CreateAt = userName,
                    CreateDate = category.CreateDate,
                    UpdateDate = category.UpdateDate
                });
            }
            ViewBag.HireCategories = categoriesInfo;
            return View();
        }
            [HttpGet]
        public IActionResult AddCategory(string? returnUrl)
        {
            ViewBag.returnUrl = returnUrl;
            return View(new CreateHireCategoryVM());
        }
        [HttpPost]
        public async Task<IActionResult> AddCategory(CreateHireCategoryVM model, IFormFile? titleImageFile)
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
        [HttpGet]
        public async Task<IActionResult> EditCategory([FromRoute]int id)
        {
            var category = await _hireCategoryRepository.GetHireCategoryByIdAsync(id);
            if (category == null)
            {
                return NotFound();
            }
            var editCategory = new EditHireCategoryVM()
            {
                Id = category.Id,
                Name = category.Name,
                ImageUrl = category.ImageUrl,
                IsActive = category.IsActive
            };
            return View(editCategory);
        }
        [HttpPost]
        public async Task<IActionResult> EditCategory(EditHireCategoryVM model, IFormFile? titleImageFile)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            var category = await _hireCategoryRepository.GetHireCategoryByIdAsync(model.Id);
            if (category == null)
            {
                return NotFound();
            }
            if (titleImageFile != null)
            {
                model.ImageUrl = titleImageFile.FileName;
                await _imageHandler.SaveImg(titleImageFile);
            }
            category.Update(model.Name, model.ImageUrl, model.IsActive);
            await _hireCategoryRepository.SaveHireCategoryAsync(category);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public async Task<IActionResult> DeleteCategory([FromRoute] int id)
        {
            var category = await _hireCategoryRepository.GetHireCategoryByIdAsync(id);
            if (category == null)
            {
                return NotFound();
            }
            var editCategory = new EditHireCategoryVM()
            {
                Id = category.Id,
                Name = category.Name,
                ImageUrl = category.ImageUrl,
                IsActive = category.IsActive
            };
            return View(editCategory);
        }
        [HttpPost]
        public async Task<IActionResult> DeleteCategory(EditHireCategoryVM model)
        {
            if (!ModelState.IsValid)
            {
                return NotFound();
            }
            var category = await _hireCategoryRepository.GetHireCategoryByIdAsync(model.Id);
            if (category == null)
            {
                return NotFound();
            }
            if (category.HireSubCategories.Any() || category.Equipments.Any())
            {
                ModelState.AddModelError(string.Empty, "Категорія містить підкатегорії чи продукти!");
                return View(model);
            }
            await _hireCategoryRepository.DeleteHireCategoryAsync(model.Id);
            return RedirectToAction("Index");
        }
    }
}
