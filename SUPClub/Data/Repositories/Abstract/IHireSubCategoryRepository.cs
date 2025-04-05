using SUPClub.Models;

namespace SUPClub.Data.Repositories.Abstract
{
    public interface IHireSubCategoryRepository
    {
        Task<IEnumerable<HireSubCategory>> GetAllAsync();
        Task<IEnumerable<HireSubCategory>> GetByCategoryIdAsync(int categoryId);
        Task<HireSubCategory?> GetByIdAsync(int id);
        Task SaveAsync(HireSubCategory hireCategory);
        Task DeleteAsync(int id);
    }
}
