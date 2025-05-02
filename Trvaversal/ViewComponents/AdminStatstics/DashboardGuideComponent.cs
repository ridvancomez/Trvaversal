using BusinessLayer.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace Trvaversal.ViewComponents.AdminStatstics
{
    public class DashboardGuideComponent : ViewComponent
    {
        private readonly IGuideService _guideService;
        private List<string> _colors;

        public DashboardGuideComponent(IGuideService guideService, List<string> colors)
        {
            _guideService = guideService;
            _colors = colors;
        }

        public IViewComponentResult Invoke()
        {
            ViewBag.colors = _colors;
            var model = _guideService.GetList();
            return View(model);
        }
    }
}
