using AutoMapper;
using Microsoft.EntityFrameworkCore;
using SUPClub.Data.Entities;
using SUPClub.Data.Repositories.Abstract;
using SUPClub.Models;

namespace SUPClub.Data.Repositories.EntityFramework
{
    public class EquipmentRepositoryEF : IEquipmentRepository
    {
        private AppDbContext _context;
        private IMapper _mapper;
        public EquipmentRepositoryEF(AppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task<IEnumerable<Equipment>> GetAllAsync()
        {
            var entities = await _context.Equipments
                  .AsNoTracking()
                  .Where(x => x.IsDeleted == false)
                  .ToListAsync();
            return _mapper.Map<IEnumerable<Equipment>>(entities);
        }

        public async Task<Equipment?> GetByIdAsync(int id)
        {
            var entities = await _context.Equipments
                  .AsNoTracking()
                  .Where(x => x.IsDeleted == false)
                  .FirstOrDefaultAsync(x  => x.Id == id);
            return _mapper.Map<Equipment>(entities);
        }

        public async Task<IEnumerable<Equipment>> GetBySubCategoryIdAsync(int subCategoryId)
        {
            var entities = await _context.Equipments
                  .AsNoTracking()
                  .Where(x => x.IsDeleted == false)
                  .Where(s => s.HireSubCategoryId ==  subCategoryId)
                  .ToListAsync();
            return _mapper.Map<IEnumerable<Equipment>>(entities);
        }

        public async Task SaveAsync(Equipment equipment)
        {
            var entity = _mapper.Map<EquipmentEntity>(equipment);
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
            var entity = await _context.Equipments
               .FirstOrDefaultAsync(x => x.Id == id);
            if (entity != null)
            {
                entity.IsDeleted = true;
                await _context.SaveChangesAsync();
            }
        }
    }
}
