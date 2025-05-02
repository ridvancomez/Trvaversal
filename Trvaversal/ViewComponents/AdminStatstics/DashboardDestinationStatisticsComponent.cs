using BusinessLayer.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace Trvaversal.ViewComponents.AdminStatstics
{
    public class DashboardDestinationStatisticsComponent : ViewComponent
    {
        private readonly IDestinationService _destinationService;
        private readonly IReservationService _reservationService;
        private readonly List<string> colors;

        public DashboardDestinationStatisticsComponent(IDestinationService destinationService, IReservationService reservationService, List<string> colors)
        {
            _destinationService = destinationService;
            _reservationService = reservationService;
            this.colors = colors;
        }

        public IViewComponentResult Invoke()
        {
            var destinationUserCount = _destinationService.GetDestinationUsersCount();
            ViewBag.ReservationCount = _reservationService.GetTotalPersonCount();
            ViewBag.Colors = colors;
            return View(destinationUserCount);
        }
    }
}
