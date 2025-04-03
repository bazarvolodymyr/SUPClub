using SUPClub.Models;

namespace SUPClub.Data.Repositories.Abstract
{
    public interface IHireSubCategoryRepository
    {
        Task<IEnumerable<HireSubCategory>> GetHireSubCategoriesAsync();
        Task<IEnumerable<HireSubCategory>> GetHireSubCategoriesByCategoryIdAsync(int categoryId);
        Task<HireSubCategory?> GetHireSubCategoryByIdAsync(int id);
        Task SaveHireCategoryAsync(HireSubCategory hireCategory);
        Task DeleteHireSubCategoryAsync(int id);
    }
}
