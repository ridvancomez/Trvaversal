using Microsoft.AspNetCore.Mvc;

namespace Trvaversal.ViewComponents
{
    public class StatsComponent : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
