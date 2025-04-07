using SUPClub.Models;
using SUPClub.Models.DTO.EquipmentDTO;
using SUPClub.Models.DTO.HieCategoryDTO;
using SUPClub.Models.DTO.HireSubCategoryDTO;

namespace SUPClub.Services.Abstract
{
    public interface IEquipmentService
    {
        Task<IEnumerable<EquipmentInfoVM>> GetAllInfoAsync();
        Task<EditEquipmentVM?> GetEditModelAsync(int id);
        Task<string?> SaveAsync(EditEquipmentVM editEquipment, string? userId, IFormFile? titleImageFile);
        Task<string?> DeleteAsync(int id);
    }
}
