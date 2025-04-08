using SUPClub.Models;
using SUPClub.Models.DTO.EquipmentDTO;

namespace SUPClub.Data.Repositories.Abstract
{
    public interface IEquipmentRepository
    {
        Task<IEnumerable<Equipment>> GetAllAsync();
        Task<IEnumerable<EquipmentView>> GetViewBySubCategoryIdAsync(int subCategoryId);
        Task<EquipmentView?> GetViewByIdAsync(int id);
        Task<Equipment?> GetByIdAsync(int id);
        Task SaveAsync(Equipment equipment);
        Task DeleteAsync(int id);
    }
}
