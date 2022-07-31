using Microsoft.AspNetCore.Mvc;
using SiddharthPieShop.Models;

namespace SiddharthPieShop.Components
{
    public class CategoryMenu:ViewComponent
    {
        private readonly ICategoryRepository categoryRepository;

        public CategoryMenu(ICategoryRepository categoryRepository) => this.categoryRepository = categoryRepository;

        public IViewComponentResult Invoke()
        {
            var categoryItems = categoryRepository.AllCategories;
            return View(categoryItems);
        }

    }
}
