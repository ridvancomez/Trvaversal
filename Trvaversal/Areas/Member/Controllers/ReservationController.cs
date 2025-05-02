using BusinessLayer.Abstract;
using DataTransferObjectLayer.Concrete;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Trvaversal.Areas.Member.Controllers
{
    [Area("Member")]
    [Route("Member/[controller]/[action]")]
    public class ReservationController : Controller
    {
        private readonly IReservationService _reservationService;
        private readonly IDestinationService _destinationService;
        private readonly UserManager<AppUser> _userManager;

        public ReservationController(IReservationService reservationService, IDestinationService destinationService, UserManager<AppUser> userManager)
        {
            _reservationService = reservationService;
            _destinationService = destinationService;
            _userManager = userManager;

        }

        public IActionResult Index()
        {
            ViewBag.ActivePage = "Reservation";
            var model = _reservationService.ReservationUserAndDestinationList();

            return View(model);
        }

        [HttpGet]
        public IActionResult AddReservation()
        {
            ViewBag.ActivePage = "Reservation";
            List<SelectListItem> values = _destinationService.GetDestinationList();

            ViewBag.Destinations = values;


            return View();
        }

        [HttpPost]
        public IActionResult AddReservation(ReservationDTO _reservation)
        {
            Reservation reservation = new Reservation
            {
                DestinationId = _reservation.DestinationId,
                CheckIn = _reservation.CheckIn,
                PersonCount = _reservation.PersonCount,
                AppUserId = 4,
                Status = "Pending"
            };

            _reservationService.Add(reservation);
            return RedirectToAction("Index");
        }

        [HttpPost]
        public JsonResult GetReservationByStatus([FromForm] string status)
        {
            if (string.IsNullOrEmpty(status))
            {
                return Json(new { error = true, message = "Status boş!" });
            }
            List<Reservation> reservationList;

            if (status == "Tumu")
                reservationList = _reservationService.ReservationUserAndDestinationList();
            else
                reservationList = _reservationService.ReservationUserAndDestinationListByStatus(status);

            var reservations = reservationList.Select(item => new
            {
                Id = item.Id,
                Name = item.AppUser?.Name + " " + item.AppUser?.Surname,
                City = item.Destination?.City,
                PersonCount = item.PersonCount,
                CheckIn = item.CheckIn.ToString("dd/MMM/yyyy"),
                Status = item.Status
            }).ToList();

            return Json(reservations);
        
        }
    }
}
