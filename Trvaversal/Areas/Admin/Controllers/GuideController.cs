using BusinessLayer.Abstract;
using DataTransferObjectLayer.Concrete;
using Elfie.Serialization;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;
using System.Drawing;

namespace Trvaversal.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("Admin/[controller]/[action]")]
    [Route("Admin/[controller]/[action]/{id?}")]
    public class GuideController : Controller
    {
        private readonly IGuideService guideService;

        public GuideController(IGuideService guideService)
        {
            this.guideService = guideService;
        }

        public IActionResult Index()
        {
            var model = guideService.GetList();
            return View(model);
        }

        [HttpGet]
        public IActionResult AddGuide()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddGuide(GuideDTO model)
        {
            if (ModelState.IsValid)
            {

                var guide = new Guide
                {
                    Name = model.Name,
                    Title = model.Title,
                    Description = model.Description,
                    TwitterUrl = model.TwitterUrl,
                    InstagramUrl = model.InstagramUrl,
                    Status = model.Status,
                };

                var resource = Directory.GetCurrentDirectory();
                var extension = Path.GetExtension(model.Image.FileName);
                var fileName = Guid.NewGuid() + extension;
                var saveLocation = resource + Path.Combine("/wwwroot/GuideImages", fileName);

                using (var stream = new FileStream(saveLocation, FileMode.Create))
                {
                    model.Image.CopyTo(stream);
                    stream.Close();
                }
                guide.ImageUrl = fileName;

                guideService.Add(guide);

                return RedirectToAction("Index");

            }
            return View();
        }

        [HttpGet]
        public IActionResult UpdateGuide(int id)
        {
            var guide = guideService.GetById(id);

            var model = new GuideDTO
            {
                
                Name = guide.Name,
                Title = guide.Title,
                Description = guide.Description,
                TwitterUrl = guide.TwitterUrl,
                InstagramUrl = guide.InstagramUrl,
                ImageUrl = guide.ImageUrl,
                Status = guide.Status
            };
            ViewBag.Id = id;
            return View(model);
        }

        [HttpPost]
        public IActionResult UpdateGuide(GuideDTO model, string previousImageName, int id)
        {
            if (ModelState.IsValid)
            {
                var guide = guideService.GetById(id);

                guide.Title = model.Title;
                guide.Description = model.Description;
                guide.TwitterUrl = model.TwitterUrl;
                guide.InstagramUrl = model.InstagramUrl;
                guide.Status = model.Status;

                //yeni resim ekleme
                var resource = Directory.GetCurrentDirectory();
                var fileExtension = Path.GetExtension(model.Image.FileName);
                var fileName = Guid.NewGuid() + fileExtension;
                var saveLocation = resource + Path.Combine("/wwwroot/GuideImages", fileName);

                using (var stream = new FileStream(saveLocation, FileMode.Create))
                {
                    model.Image.CopyTo(stream);
                    stream.Close();
                }
                guide.ImageUrl = fileName;
                //önceki resmi silme
                var previousSaveLocation = resource + Path.Combine("/wwwroot/GuideImages", previousImageName);

                if (System.IO.File.Exists(previousSaveLocation))
                {
                    System.IO.File.Delete(previousSaveLocation);
                }
                guideService.Update(guide);

                return RedirectToAction("Index");
            }
            ViewBag.Id = id;
            return View(model);
        }
        public IActionResult DeleteGuide(int id)
        {
            var model = guideService.GetById(id);
            var previousSaveLocation = Directory.GetCurrentDirectory() + Path.Combine("/wwwroot/GuideImages", model.ImageUrl);

            if (System.IO.File.Exists(previousSaveLocation))
            {
                System.IO.File.Delete(previousSaveLocation);
            }
            guideService.Delete(model);
            return RedirectToAction("Index");
        }
    }

}
