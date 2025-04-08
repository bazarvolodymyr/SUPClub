using Microsoft.AspNetCore.Identity;
using SUPClub.Data.Entities;
using SUPClub.Data.Repositories.Abstract;
using SUPClub.Infrastructure;
using SUPClub.Models;
using SUPClub.Models.DTO.HieCategoryDTO;
using SUPClub.Services.Abstract;

namespace SUPClub.Services
{
    public class HireCategoryService : IHireCategoryService
    {
        private readonly IHireCategoryRepository _hireCategoryRepository;
        private readonly UserManager<AppUser> _userManager;
        private readonly ImageHandler _imageHandler;
        public HireCategoryService(IHireCategoryRepository hireCategoryRepository,
                                    UserManager<AppUser> userManager,
                                    ImageHandler imageHandler)
        {
            _hireCategoryRepository = hireCategoryRepository;
            _userManager = userManager;
            _imageHandler = imageHandler;
        }

        public async Task<IEnumerable<HireCategoryInfoVM>> GetAllInfoAsync()
        {
            var categoriesInfo = new List<HireCategoryInfoVM>();
            var categories = await _hireCategoryRepository.GetAllAsync();
            if (categories == null)
            {
                return categoriesInfo;
            }
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
            return categoriesInfo;
        }
        public async Task<List<CategoryView>> CategoriesListAsync()
        {
            var categories = await _hireCategoryRepository.GetListCategories();
            return categories.ToList();
        }
        public async Task<List<CategoryView>> GetActiveCategoriesAsync()
        {
            var categoriesView = await _hireCategoryRepository.GetActiveCategoriesAsync();
            return categoriesView.ToList();
        }
        public async Task<EditHireCategoryVM?> GetEditModelAsync(int id)
        {
            var category = await _hireCategoryRepository.GetByIdAsync(id);
            if (category == null)
            {
                return null;
            }
            return new EditHireCategoryVM()
            {
                Id = category.Id,
                Name = category.Name,
                ImageUrl = category.ImageUrl,
                IsActive = category.IsActive
            };
        }

        public async Task<string?> SaveAsync(EditHireCategoryVM editModel, 
                                    IFormFile? titleImageFile, string? userId)
        {
            HireCategory? category;
            if (titleImageFile != null)
            {
                editModel.ImageUrl = titleImageFile.FileName;
                await _imageHandler.SaveImg(titleImageFile);
            }
            if (editModel.Id == default)
            {
                category = HireCategory.Create(editModel.Name, editModel.ImageUrl,
                    userId, editModel.IsActive);
            }
            else
            {
                category = await _hireCategoryRepository.GetByIdAsync(editModel.Id);
                if (category == null)
                {
                    return "Категорію не знайддено";
                }
                category.Update(editModel.Name, editModel.ImageUrl, editModel.IsActive);
            }
            await _hireCategoryRepository.SaveAsync(category);
            return null;
        }
        public async Task<string?> DeleteAsync(int id)
        {
            var category = await _hireCategoryRepository.GetByIdAsync(id);
            if (category == null)
            {
                return "Категорію не знайддено";
            }
            if (category.HireSubCategories.Any() || category.Equipments.Any())
            {
                return "Категорія містить підкатегорії чи продукти!"; 
            }
            await _hireCategoryRepository.DeleteAsync(id);
            return null;
        }

    }
}
