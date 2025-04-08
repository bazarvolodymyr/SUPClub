using SUPClub.Models;
using SUPClub.Models.DTO.HieCategoryDTO;

namespace SUPClub.Data.Repositories.Abstract
{
    public interface IHireCategoryRepository
    {
        Task<IEnumerable<HireCategory>> GetAllAsync();
        Task<IEnumerable<CategoryView>> GetListCategories();
        Task<IEnumerable<CategoryView>> GetActiveCategoriesAsync();
        Task<HireCategory?> GetByIdAsync(int? id);
        Task SaveAsync(HireCategory hireCategory);
        Task DeleteAsync(int id);
    }
}
