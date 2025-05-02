using BusinessLayer.Abstract;
using DataTransferObjectLayer.Concrete;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace Trvaversal.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("Admin/[controller]/[action]")]
    [Route("Admin/[controller]/[action]/{id?}")]
    public class DestinationImageController : Controller
    {
        private readonly IPictureService destinationImageService;
        private readonly IDestinationService destinationService;
        public DestinationImageController(IPictureService destinationImageService, IDestinationService destinationService)
        {
            this.destinationImageService = destinationImageService;
            this.destinationService = destinationService;
        }

        public IActionResult Index()
        {
            var model = destinationImageService.GetPictureWithDestinationList();
            return View(model);
        }

        [HttpGet]
        public IActionResult AddDestinationImage()
        {
            var destionationListItem = destinationService.GetDestinationList();
            ViewBag.DestinationListItem = destionationListItem;

            return View();
        }

        [HttpPost]
        public IActionResult AddDestinationImage(DestinationDetailImageDTO model)
        {
            if (ModelState.IsValid)
            {
                var resource = Directory.GetCurrentDirectory();
                var extension = Path.GetExtension(model.Image.FileName);
                var imageName = Guid.NewGuid() + extension;
                var saveLocation = resource + Path.Combine("/wwwroot/DestinationDetailImages", imageName);

                using (var stream = new FileStream(saveLocation, FileMode.Create))
                {
                    model.Image.CopyTo(stream);
                    stream.Close();
                }

                var destinationDetailImage = new Picture
                {
                    DestinationId = model.DestinationId,
                    ImagePath = imageName
                };

                destinationImageService.Add(destinationDetailImage);

                return RedirectToAction("Index");
            }

            var destionationListItem = destinationService.GetDestinationList();
            ViewBag.DestinationListItem = destionationListItem;
            return View();
        }

        [HttpGet]
        public IActionResult UpdateDestinationImage(int id)
        {
            var model = destinationImageService.GetById(id);
            var destionationImageDTO = new DestinationDetailImageDTO
            {
                DestinationId = model.DestinationId,
                ImagePath = model.ImagePath,
            };
            var destionationListItem = destinationService.GetDestinationList();
            ViewBag.DestinationListItem = destionationListItem;
            ViewBag.Id = id;
            return View(destionationImageDTO);
        }

        [HttpPost]
        public IActionResult UpdateDestinationImage(DestinationDetailImageDTO model, int id, string previousImageUrl)
        {
            if (ModelState.IsValid)
            {
                //Yeni Resim Ekleme işlemi
                var resource = Directory.GetCurrentDirectory();
                var extension = Path.GetExtension(model.Image.FileName);
                var fileName = Guid.NewGuid() + extension;
                var saveLocation = resource + Path.Combine("/wwwroot/DestinationDetailImages", fileName);

                using (var stream = new FileStream(saveLocation, FileMode.Create))
                {
                    model.Image.CopyTo(stream);
                    stream.Close();
                }

                //Eski Resmi Silme İşlemi
                var oldFilePath = resource + Path.Combine("/wwwroot/DestinationDetailImages", previousImageUrl);
                if (System.IO.File.Exists(oldFilePath))
                {
                    System.IO.File.Delete(oldFilePath);
                }

                var destinationImage = destinationImageService.GetById(id);

                destinationImage.DestinationId = model.DestinationId;
                destinationImage.ImagePath = fileName;

                destinationImageService.Update(destinationImage);

                return RedirectToAction("Index");
            }


            var destionationListItem = destinationService.GetDestinationList();
            ViewBag.DestinationListItem = destionationListItem;
            ViewBag.Id = id;
            return View(model);
        }

        [HttpGet]
        public IActionResult DeleteDestinationImage(int id)
        {
            var model = destinationImageService.GetById(id);
            var imagePath = Directory.GetCurrentDirectory() + Path.Combine("/wwwroot/DestinationDetailImages", model.ImagePath);
            if (System.IO.File.Exists(imagePath))
            {
                System.IO.File.Delete(imagePath);
            }
            destinationImageService.Delete(model);
            return RedirectToAction("Index");
        }
    }
}
