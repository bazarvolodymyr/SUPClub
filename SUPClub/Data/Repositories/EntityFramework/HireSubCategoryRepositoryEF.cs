using AutoMapper;
using Microsoft.EntityFrameworkCore;
using SUPClub.Data.Entities;
using SUPClub.Data.Repositories.Abstract;
using SUPClub.Models;

namespace SUPClub.Data.Repositories.EntityFramework
{
    public class HireSubCategoryRepositoryEF : IHireSubCategoryRepository
    {
        private AppDbContext _context;
        private IMapper _mapper;
        public HireSubCategoryRepositoryEF(AppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task<IEnumerable<HireSubCategory>> GetAllAsync()
        {
            var entities = await _context.HireSubCategories
                .AsNoTracking()
                .Where(x => x.IsDeleted == false)
                .Include(x => x.Equipments.Where(d => d.IsDeleted == false))
                .ToListAsync();
            return _mapper.Map<IEnumerable<HireSubCategory>>(entities);
        }

        public async Task<HireSubCategory?> GetByIdAsync(int? id)
        {
            var entity = await _context.HireSubCategories
                .AsNoTracking()
                .Where(x => x.IsDeleted == false)
                .Include(e => e.Equipments.Where(d => d.IsDeleted == false))
                .FirstOrDefaultAsync(x => x.Id == id);
            return _mapper.Map<HireSubCategory>(entity);
        }

        public async Task<IEnumerable<HireSubCategory>> GetByCategoryIdAsync(int categoryId)
        {
            var entities = await _context.HireSubCategories
                .AsNoTracking()
                .Where(x => x.IsDeleted == false)
                .Where(c => c.HireCategoryId == categoryId)
                .Include(x => x.Equipments.Where(d => d.IsDeleted == false))
                .ToListAsync();
            return _mapper.Map<IEnumerable<HireSubCategory>>(entities);
        }
        public async Task SaveAsync(HireSubCategory hireCategory)
        {
            var entity = _mapper.Map<HireSubCategoryEntity>(hireCategory);
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
            var entity = await _context.HireSubCategories
               .FirstOrDefaultAsync(x => x.Id == id);
            if (entity != null)
            {
                entity.IsDeleted = true;
                await _context.SaveChangesAsync();
            }
        }
    }
}
