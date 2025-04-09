using AutoMapper;
using Microsoft.EntityFrameworkCore;
using SUPClub.Data.Entities;
using SUPClub.Data.Repositories.Abstract;
using SUPClub.Models;

namespace SUPClub.Data.Repositories.EntityFramework
{
    public class ContactRepository : IContactRepository
    {
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;
        public ContactRepository(AppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<IEnumerable<Contact>> GetAllAsync()
        {
            var entities = await _context.Contacts
                  .AsNoTracking()
                  .OrderBy(x => x.Rank)
                  .ToListAsync();
            return _mapper.Map<IEnumerable<Contact>>(entities);
        }

        public async Task<Contact?> GetByIdAsync(int id)
        {
            var entity = await _context.Contacts
                  .AsNoTracking()
                  .Where(x => x.Id == id)
                  .FirstOrDefaultAsync();
            return _mapper.Map<Contact>(entity);
        }

        public async Task SaveAsync(Contact contact)
        {
            var entity = _mapper.Map<ContactEntity>(contact);
            if (entity.Id == default)
            {
                _context.Entry(entity).State = EntityState.Added;
            }
            else
            {
                _context.Entry(entity).State = EntityState.Modified;
            }
            await _context.SaveChangesAsync();
        }
        public async Task DeleteAsync(int id)
        {
            var entity = await _context.Contacts
               .Where(x => x.Id == id)
               .ExecuteDeleteAsync();
            await _context.SaveChangesAsync();
        }
    }
}
