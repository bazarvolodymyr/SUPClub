using SUPClub.Models;

namespace SUPClub.Data.Repositories.Abstract
{
    public interface IEquipmentRepository
    {
        Task<IEnumerable<Equipment>> GetAllAsync();
        Task<IEnumerable<Equipment>> GetBySubCategoryIdAsync(int subCategoryId);
        Task<Equipment?> GetByIdAsync(int id);
        Task SaveAsync(Equipment equipment);
        Task DeleteAsync(int id);
    }
}
