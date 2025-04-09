using SUPClub.Data.Repositories.Abstract;
using SUPClub.Infrastructure;
using SUPClub.Models;
using SUPClub.Services.Abstract;

namespace SUPClub.Services
{
    public class ContactService : IContactService
    {
        private readonly IContactRepository _contactRepository;
        private readonly ImageHandler _imageHandler;
        public ContactService(IContactRepository contactRepository, ImageHandler imageHandler)
        {
            _contactRepository = contactRepository;
            _imageHandler = imageHandler;
        }

        public async Task<IEnumerable<Contact>> GetAllAsync()
        {
            return await _contactRepository.GetAllAsync();
        }

        public async Task<Contact?> GetByIdAsync(int id)
        {
            return await _contactRepository.GetByIdAsync(id);
        }

        public async Task SaveAsync(Contact contact, IFormFile? titleImageFile)
        {
            if (titleImageFile != null)
            {
                contact.IconUrl = titleImageFile.FileName;
                await _imageHandler.SaveImg(titleImageFile);
            }
            await _contactRepository.SaveAsync(contact);
        }
        public async Task DeleteAsync(int id)
        {
            await _contactRepository.DeleteAsync(id);
        }
    }
}
