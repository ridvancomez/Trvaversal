using BusinessLayer.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace Trvaversal.ViewComponents
{
    public class TestimonialComponent : ViewComponent
    {
        private readonly ITestimonialService _testimonialService;

        public TestimonialComponent(ITestimonialService testimonialService)
        {
            _testimonialService = testimonialService;
        }

        public IViewComponentResult Invoke()
        {
            var model = _testimonialService.GetList();
            return View(model);
        }
    }
}
