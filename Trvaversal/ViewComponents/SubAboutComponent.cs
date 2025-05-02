using BusinessLayer.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace Trvaversal.ViewComponents
{
    public class SubAboutComponent : ViewComponent
    {
        private readonly ISubAboutService _testimonialService;

        public SubAboutComponent(ISubAboutService testimonialService)
        {
            _testimonialService = testimonialService;
        }
        public IViewComponentResult Invoke()
        {
            var model = _testimonialService.GetList().First();
            return View(model);
        }
    }
}
