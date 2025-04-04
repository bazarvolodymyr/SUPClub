using SUPClub.Models;

namespace SUPClub.Data.Repositories.Abstract
{
    public interface IEquipmentRepository
    {
        Task<IEnumerable<Equipment>> GetAllEquipmentsAsync();
        Task<IEnumerable<Equipment>> GetEquipmentsBySubCategoryIdAsync(int subCategoryId);
        Task<Equipment?> GeEquipmentByIdAsync(int id);
        Task SaveEquipmentAsync(Equipment equipment);
        Task DeleteEquipmentAsync(int id);
    }
}
