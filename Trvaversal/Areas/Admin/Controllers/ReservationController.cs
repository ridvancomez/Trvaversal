using BusinessLayer.Abstract;
using DataTransferObjectLayer.Concrete;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace Trvaversal.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("Admin/[controller]/[action]")]
    [Route("Admin/[controller]/[action]/{id?}")]
    public class ReservationController : Controller
    {
        private readonly IReservationService reservationService;
        private readonly IAppUserService appUserService;
        private readonly IDestinationService destinationService;
        public ReservationController(IReservationService reservationService, IAppUserService appUserService, IDestinationService destinationService)
        {
            this.reservationService = reservationService;
            this.appUserService = appUserService;
            this.destinationService = destinationService;
        }

        public IActionResult Index()
        {
            var model = reservationService.ReservationUserAndDestinationList();
            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> AddReservation()
        {
            var userList = await appUserService.GetUserListAsync();
            ViewBag.UsersListItem = userList;
            var destinationList = destinationService.GetDestinationList();
            ViewBag.DestinationListItem = destinationList;


            return View();
        }

        [HttpPost]
        public async Task<IActionResult> AddReservation(AdminReservationDTO model)
        {
            if (ModelState.IsValid)
            {
                Reservation reservation = new Reservation
                {
                    AppUserId = model.AppUserId,
                    DestinationId = model.DestinationId,
                    PersonCount = model.PersonCount,
                    CheckIn = model.CheckIn,
                    Status = model.Status
                };

                reservationService.Add(reservation);
                return RedirectToAction("Index");
            }
            var userList = await appUserService.GetUserListAsync();
            ViewBag.UsersListItem = userList;
            var destinationList = destinationService.GetDestinationList();
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> UpdateReservation(int id)
        {
            var userList = await appUserService.GetUserListAsync();
            ViewBag.UsersListItem = userList;
            var destinationList = destinationService.GetDestinationList();
            ViewBag.DestinationListItem = destinationList;

            var model = reservationService.GetById(id);
            var reservationDTO = new AdminReservationDTO
            {
                AppUserId = model.AppUserId,
                DestinationId = model.DestinationId,
                PersonCount = model.PersonCount,
                CheckIn = model.CheckIn,
                Status = model.Status
            };
            return View(reservationDTO);
        }

        [HttpPost]
        public async Task<IActionResult> UpdateReservation(AdminReservationDTO model)
        {
            if (ModelState.IsValid)
            {
                Reservation reservation = new Reservation
                {
                    AppUserId = model.AppUserId,
                    DestinationId = model.DestinationId,
                    PersonCount = model.PersonCount,
                    CheckIn = model.CheckIn,
                    Status = model.Status
                };

                reservationService.Update(reservation);
                return RedirectToAction("Index");
            }
            var userList = await appUserService.GetUserListAsync();
            ViewBag.UsersListItem = userList;
            var destinationList = destinationService.GetDestinationList();
            ViewBag.DestinationListItem = destinationList;

            return View();
        }

        public IActionResult DeleteReservation(int id)
        {
            var model = reservationService.GetById(id);
            reservationService.Delete(model);
            return RedirectToAction("Index");
        }
    }
}
