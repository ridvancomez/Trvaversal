using BusinessLayer.Abstract;
using DataTransferObjectLayer.Concrete;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;
using System.IO;

namespace Trvaversal.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("Admin/[controller]/[action]")]
    [Route("Admin/[controller]/[action]/{id?}")]
    public class DestinationController : Controller
    {
        private readonly IDestinationService _destinationService;

        public DestinationController(IDestinationService destinationService)
        {
            _destinationService = destinationService;
        }

        public IActionResult Index()
        {
            var model = _destinationService.GetList();
            return View(model);
        }

        [HttpGet]
        public IActionResult AddDestination()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> AddDestination(DestinationDTO destination)
        {

            if (ModelState.IsValid)
            {
                if (destination.Image != null)
                {
                    var resource = Directory.GetCurrentDirectory();
                    var extension = Path.GetExtension(destination.Image.FileName);
                    var imageName = Guid.NewGuid() + extension;
                    var saveLocation = resource + Path.Combine("/wwwroot/DestinationImages", imageName);
                    var stream = new FileStream(saveLocation, FileMode.Create);
                    await destination.Image.CopyToAsync(stream);
                    destination.CoverImage = imageName;
                    stream.Close();
                }

                Destination data = new Destination
                {
                    Title = destination.Title,
                    City = destination.City,
                    DayNigth = destination.DayNight,
                    Price = destination.Price,
                    SubTitle = destination.SubTitle,
                    Capacity = destination.Capacity,
                    Status = destination.Status,
                    Popular = destination.Popular,
                    Details = destination.Details,
                    CoverImage = destination.CoverImage
                };


                _destinationService.Add(data);
                return RedirectToAction("Index");
            }
            return View();
        }

        [HttpGet]
        public IActionResult UpdateDestination(int id)
        {
            var data = _destinationService.GetById(id);
            var model = new DestinationDTO
            {
                Title = data.Title,
                City = data.City,
                DayNight = data.DayNigth,
                Price = data.Price,
                SubTitle = data.SubTitle,
                Capacity = data.Capacity,
                Status = data.Status,
                Popular = data.Popular,
                Details = data.Details,
                CoverImage = data.CoverImage
            };
            ViewBag.Id = id;
            return View(model);
        }

        [HttpPost]
        public IActionResult UpdateDestination(DestinationDTO data, string previousImageUrl, int id)
        {
            if (ModelState.IsValid)
            {
                if (data.Image != null)
                {
                    //Önceki resmi sil
                    var previusImageLocation = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "DestinationImages", previousImageUrl);

                    if (System.IO.File.Exists(previusImageLocation))
                    {
                        System.IO.File.Delete(previusImageLocation);
                    }

                    //Yeni resmi ekle

                    var resource = Directory.GetCurrentDirectory();
                    var extension = Path.GetExtension(data.Image.FileName);
                    var imageName = Guid.NewGuid() + extension;
                    var saveLocation = resource + Path.Combine("/wwwroot/DestinationImages", imageName);
                    using (var stream = new FileStream(saveLocation, FileMode.Create))
                    {
                        data.Image.CopyTo(stream);
                    }

                    data.CoverImage = imageName;
                }
                else
                {
                    data.CoverImage = previousImageUrl;
                }

                var destination = _destinationService.GetById(id);


                destination.Title = data.Title;
                destination.City = data.City;
                destination.DayNigth = data.DayNight;
                destination.Price = data.Price;
                destination.SubTitle = data.SubTitle;
                destination.Capacity = data.Capacity;
                destination.Status = data.Status;
                destination.Popular = data.Popular;
                destination.Details = data.Details;
                destination.CoverImage = data.CoverImage;


                _destinationService.Update(destination);

                return RedirectToAction("Index");
            }

            return View(data);
        }

        public IActionResult DeleteDestination(int id)
        {
            var data = _destinationService.GetById(id);
            var imageUrl = data.CoverImage;
            var imageLocation = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "DestinationImages", imageUrl);
            if (System.IO.File.Exists(imageLocation))
            {
                System.IO.File.Delete(imageLocation);
            }
            _destinationService.Delete(data);

            return RedirectToAction("Index");
        }

    }

}
