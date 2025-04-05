using Microsoft.AspNetCore.Identity;
using SUPClub.Data.Entities;
using SUPClub.Data.Repositories.Abstract;
using SUPClub.Models;
using SUPClub.Models.DTO.HireSubCategoryDTO;
using SUPClub.Services.Abstract;

namespace SUPClub.Services
{
    public class HireSubCategoryService : IHireSubCategoryService
    {
        private readonly IHireSubCategoryRepository _hireSubCategoryRepository;
        private readonly IHireCategoryRepository _hireCategoryRepository;
        private readonly UserManager<AppUser> _userManager;
        public HireSubCategoryService(IHireSubCategoryRepository hireSubCategoryRepository,
                                      IHireCategoryRepository hireCategoryRepository,
                                      UserManager<AppUser> userManager)
        {
            _hireCategoryRepository = hireCategoryRepository;
            _hireSubCategoryRepository = hireSubCategoryRepository;
            _userManager = userManager;
        }
        public async Task<IEnumerable<HireSubCategoryInfoVM>> GetAllInfoAsync()
        {
            var categoriesInfo = new List<HireSubCategoryInfoVM>();
            var subCategories = await _hireSubCategoryRepository.GetAllAsync();
            if (subCategories == null)
            {
                return categoriesInfo;
            }

            foreach (var subCategory in subCategories)
            {
                string categoryName = "";
                string userName = "";
                var category = await _hireCategoryRepository.GetByIdAsync(subCategory.HireCategoryId);
                if (category != null)
                {
                    categoryName = category.Name!;
                }
                if (subCategory.CreateById != null)
                {
                    var user = await _userManager.FindByIdAsync(subCategory.CreateById);
                    userName = user!.UserName ?? "";
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
            return categoriesInfo;
        }

        public async Task<EditHireSubCategoryVM?> GetEditModelAsync(int id)
        {
            var sudCategory = await _hireSubCategoryRepository.GetByIdAsync(id);
            if (sudCategory == null)
            {
                return null;
            }
            return new EditHireSubCategoryVM()
            {
                Id = sudCategory.Id,
                Name = sudCategory.Name,
                HireCategoryId = sudCategory.HireCategoryId,
                IsActive = sudCategory.IsActive
            };
        }

        public async Task<string?> SaveAsync(EditHireSubCategoryVM editModel, string? userId)
        {
            HireSubCategory? subCategory;
            if (editModel.Id == default)
            {
                subCategory = HireSubCategory.Create(editModel.Name, editModel.HireCategoryId,
                                            editModel.IsActive, userId);
            }
            else
            {
                subCategory = await _hireSubCategoryRepository.GetByIdAsync(editModel.Id);
                if (subCategory == null)
                {
                    return "Підкатегорію не знайддено";
                }
                subCategory.Update(editModel.Name, editModel.HireCategoryId, editModel.IsActive);
            }
            await _hireSubCategoryRepository.SaveAsync(subCategory);
            return null;
        }
        public async Task<string?> DeleteAsync(int id)
        {
            var subCategory = await _hireSubCategoryRepository.GetByIdAsync(id);
            if (subCategory == null)
            {
                return "Підкатегорію не знайддено";
            }
            if (subCategory.Equipments.Any())
            {
                return "Підкатегорія містить продукти!";
            }
            await _hireSubCategoryRepository.DeleteAsync(id);
            return null;
        }
    }
}
