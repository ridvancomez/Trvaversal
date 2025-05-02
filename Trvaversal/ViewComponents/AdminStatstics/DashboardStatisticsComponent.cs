using BusinessLayer.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace Trvaversal.ViewComponents.AdminStatstics
{
    public class DashboardStatisticsComponent : ViewComponent
    {
        private readonly IReservationService reservationService;
        private readonly IDestinationService destinationService;
        private readonly IGuideService guideService;
        private readonly ITestimonialService testimonialService;
        private readonly List<string> colors;

        public DashboardStatisticsComponent(IReservationService reservationService, IDestinationService destinationService, IGuideService guideService, ITestimonialService testimonialService, List<string> colors)
        {
            this.reservationService = reservationService;
            this.destinationService = destinationService;
            this.guideService = guideService;
            this.testimonialService = testimonialService;
            this.colors = colors;
        }

        public IViewComponentResult Invoke()
        {
            ViewBag.TotalPersonCount = reservationService.GetTotalPersonCount();
            ViewBag.TotalDestinationCount = destinationService.GetList().Count;
            ViewBag.TotalGuideCount = guideService.GetList().Count;
            ViewBag.TotalTestimonialCount = testimonialService.GetList().Count;
            ViewBag.Colors = colors;
            return View();
        }
    }
}
