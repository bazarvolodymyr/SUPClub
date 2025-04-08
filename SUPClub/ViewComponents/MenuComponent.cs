using Microsoft.AspNetCore.Mvc;
using SUPClub.Services.Abstract;

namespace SUPClub.ViewComponents
{
    public class MenuComponent : ViewComponent
    {
        private readonly IHireCategoryService _categoryService;
        public MenuComponent(IHireCategoryService categoryService)
        {
            _categoryService = categoryService;
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var categories = await _categoryService.GetActiveCategoriesAsync();
            return await Task.FromResult((IViewComponentResult)View("Default", categories));
        }
    }
}
