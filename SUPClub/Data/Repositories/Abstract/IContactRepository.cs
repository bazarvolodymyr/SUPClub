using SUPClub.Models;

namespace SUPClub.Data.Repositories.Abstract
{
    public interface IContactRepository
    {
        Task<IEnumerable<Contact>> GetAllAsync();
        Task<Contact?> GetByIdAsync(int id);
        Task SaveAsync(Contact contact);
        Task DeleteAsync(int id);
    }
}
