﻿using SUPClub.Models;

namespace SUPClub.Data.Repositories.Abstract
{
    public interface IHireCategoryRepository
    {
        Task<IEnumerable<HireCategory>> GetHireCategoriesAsync();
        Task<HireCategory?> GetHireCategoryByIdAsync(int id);
        Task SaveHireCategoryAsync(HireCategory hireCategory);
        Task DeleteHireCategoryAsync(int id);
    }
}
