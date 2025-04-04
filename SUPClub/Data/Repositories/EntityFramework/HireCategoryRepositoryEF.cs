﻿using AutoMapper;
using Microsoft.EntityFrameworkCore;
using SUPClub.Data.Entities;
using SUPClub.Data.Repositories.Abstract;
using SUPClub.Models;
using SUPClub.Models.DTO.HieCategoryDTO;

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
        public async Task<IEnumerable<HireCategory>> GetAllAsync()
        {
            var entities = await _context.HireCategories
                .AsNoTracking()
                .Where(x => x.IsDeleted == false)
                .Include(x => x.HireSubCategories)
                .Include(e => e.Equipments)
                .ToListAsync();
            return _mapper.Map<IEnumerable<HireCategory>>(entities);
        }

        public async Task<HireCategory?> GetByIdAsync(int? id)
        {
            if (id == null)
            {
                return null;
            }
            var entity = await _context.HireCategories
                .AsNoTracking()
                .Where(x => x.IsDeleted == false)
                .Include(x => x.HireSubCategories)
                .Include(e => e.Equipments)
                .FirstOrDefaultAsync(x => x.Id == id);
            return _mapper.Map<HireCategory>(entity);
        }

        public async Task<IEnumerable<ViewHireCategory>> GetActiveViewInfoAsync()
        {
            List<ViewHireCategory> viewHireCategories = new List<ViewHireCategory> ();
            viewHireCategories = await _context.HireCategories
                .AsNoTracking()
                .Where(x => x.IsDeleted == false)
                .Where(x => x.IsActive == true)
                .Select(x => new ViewHireCategory { Id = x.Id, Name = x.Name, imageUrl = x.ImageUrl})
                .ToListAsync();
            return viewHireCategories;
        }
        public async Task SaveAsync(HireCategory hireCategory)
        {
            var entity = _mapper.Map<HireCategoryEntity>(hireCategory);
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
