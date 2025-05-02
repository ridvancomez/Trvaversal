using BusinessLayer.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace Trvaversal.ViewComponents.MemberDashboard
{
    public class GuideComponent : ViewComponent
    {
        private readonly IGuideService _guideService;

        public GuideComponent(IGuideService guideService)
        {
            _guideService = guideService;
        }

        public IViewComponentResult Invoke()
        {
            var model = _guideService.GetList();
            return View(model);
        }
    }
}
