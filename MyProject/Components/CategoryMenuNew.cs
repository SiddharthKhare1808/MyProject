using Microsoft.AspNetCore.Mvc;

namespace SiddharthPieShop.Components
{
    public class CategoryMenuNew:ViewComponent
    {


        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
