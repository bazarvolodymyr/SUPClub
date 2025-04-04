using SUPClub.Models;
using SUPClub.Models.DTO.HieCategoryDTO;

namespace SUPClub.Data.Repositories.Abstract
{
    public interface IHireCategoryRepository
    {
        Task<IEnumerable<HireCategory>> GetHireCategoriesAsync();
        Task<IEnumerable<ViewHireCategory>> GetActiveViewHireCategoriesAsync();
        Task<HireCategory?> GetHireCategoryByIdAsync(int? id);
        Task SaveHireCategoryAsync(HireCategory hireCategory);
        Task DeleteHireCategoryAsync(int id);
    }
}
