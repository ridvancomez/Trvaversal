using Microsoft.AspNetCore.Mvc;

namespace Trvaversal.ViewComponents
{
    public class SliderComponent : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
