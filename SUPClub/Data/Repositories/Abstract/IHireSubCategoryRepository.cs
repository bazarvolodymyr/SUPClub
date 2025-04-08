using SUPClub.Models;
using SUPClub.Models.DTO.HireSubCategoryDTO;

namespace SUPClub.Data.Repositories.Abstract
{
    public interface IHireSubCategoryRepository
    {
        Task<IEnumerable<HireSubCategory>> GetAllAsync();
        Task<IEnumerable<SubCategoryView>> GetActiveViewByCategoryIdAsync(int categoryId);
        Task<HireSubCategory?> GetByIdAsync(int? id);
        Task SaveAsync(HireSubCategory hireCategory);
        Task DeleteAsync(int id);
    }
}
