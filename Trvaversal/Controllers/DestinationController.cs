using BusinessLayer.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace Trvaversal.Controllers
{
    public class DestinationController : Controller
    {
        private readonly IDestinationService _destinationService;
        private readonly IPictureService _pictureService;
        public DestinationController(IDestinationService destinationService, IPictureService pictureService)
        {
            _destinationService = destinationService;
            _pictureService = pictureService;
        }

        public IActionResult Index()
        {
            var model = _destinationService.GetList().Where(x=> x.Status == true).ToList();
            return View(model);
        }

        public IActionResult DestinationDetail(int id)
        {
            ViewBag.DestinationId = id;
            var model = _destinationService.GetById(id);
            ViewBag.PictureList = _pictureService.GetList().Where(x => x.DestinationId == id).ToList();
            return View(model);
        }
    }
}
