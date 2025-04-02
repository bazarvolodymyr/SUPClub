using AutoMapper;
using Microsoft.EntityFrameworkCore;
using SUPClub.Data.Entities;
using SUPClub.Data.Repositories.Abstract;
using SUPClub.Models;

namespace SUPClub.Data.Repositories.EntityFramework
{
    public class HireCategoryRepositoryEF : IHireCategoryRepository
    {
        private AppDbContext _context;
        private IMapper _mapper;
        public HireCategoryRepositoryEF(AppDbContext appDbContext ,IMapper mapper)
        {
            _context = appDbContext;
            _mapper = mapper;
        }
        public async Task<IEnumerable<HireCategory>> GetHireCategoriesAsync()
        {
            var entities = await _context.HireCategories
                .AsNoTracking()
                .Where(x => x.IsDeleted == false)
                .Include(x => x.HireSubCategories)
                .Include(e => e.Equipments)
                .ToListAsync();
            return _mapper.Map<IEnumerable<HireCategory>>(entities);
        }

        public async Task<HireCategory?> GetHireCategoryByIdAsync(int id)
        {
            var entity = await _context.HireCategories
                .AsNoTracking()
                .Where(x => x.IsDeleted == false)
                .Include(x => x.HireSubCategories)
                .Include(e => e.Equipments)
                .FirstOrDefaultAsync(x => x.Id == id);
            return _mapper.Map<HireCategory>(entity);
        }

        public async Task<HireCategory?> SaveHireCategoryAsync(HireCategory hireCategory)
        {
            var entity = _mapper.Map<HireCategoryEntity>(hireCategory);
            if (entity.Id == default)
            {
                _context.Entry(entity).State = EntityState.Added;
            }
            else
            {
                entity.UpdateDate = DateTime.UtcNow;
                _context.Entry(entity).State = EntityState.Modified;
            }
            await _context.SaveChangesAsync();
            return hireCategory;
        }
        public async Task DeleteHireCategoryAsync(int id)
        {
            var entity = await _context.HireCategories
                .FirstOrDefaultAsync(x => x.Id == id);
            if (entity != null)
            {
                entity.IsDeleted = true;
                await _context.SaveChangesAsync();
            }
        }
    }
}
