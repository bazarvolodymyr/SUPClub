using SUPClub.Models;

namespace SUPClub.Services.Abstract
{
    public interface IContactService
    {
        Task<IEnumerable<Contact>> GetAllAsync();
        Task<Contact?> GetByIdAsync(int id);
        Task SaveAsync(Contact contact, IFormFile? titleImageFile);
        Task DeleteAsync(int id);
    }
}
