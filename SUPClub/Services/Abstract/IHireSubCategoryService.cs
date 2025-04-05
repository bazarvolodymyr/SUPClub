using SUPClub.Models.DTO.HieCategoryDTO;
using SUPClub.Models.DTO.HireSubCategoryDTO;

namespace SUPClub.Services.Abstract
{
    public interface IHireSubCategoryService
    {
        Task<IEnumerable<HireSubCategoryInfoVM>> GetAllInfoAsync();
        Task<EditHireSubCategoryVM?> GetEditModelAsync(int id);
        Task<string?> SaveAsync(EditHireSubCategoryVM editHireCategoryVM,string? userId);
        Task<string?> DeleteAsync(int id);
    }
}
