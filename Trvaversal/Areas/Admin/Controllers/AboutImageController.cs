using AutoMapper;
using BusinessLayer.Abstract;
using DataTransferObjectLayer.Concrete;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace Trvaversal.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("Admin/[controller]/[action]/{id?}")]
    [Route("Admin/[controller]/[action]")]
    public class AboutImageController : Controller
    {
        private readonly IAboutImageService aboutImageService;
        private readonly IMapper mapper;
        public AboutImageController(IAboutImageService aboutImageService, IMapper mapper)
        {
            this.aboutImageService = aboutImageService;
            this.mapper = mapper;
        }

        public IActionResult Index()
        {

            var model = mapper.Map<List<AboutImageListDTO>>(aboutImageService.GetList());
            return View(model);
        }

        [HttpGet]
        public IActionResult UpdateAboutImage(int id)
        {
            var model = mapper.Map<AboutImageDTO>(aboutImageService.GetById(id));

            return View(model);

        }

        [HttpPost]
        public IActionResult UpdateAboutImage(AboutImageDTO model)
        {
            var aboutImage = mapper.Map<AboutImage>(model);

            if (ModelState.IsValid)
            {
                var resources = Directory.GetCurrentDirectory();
                var extension = Path.GetExtension(model.Image.FileName);
                var fileName = Guid.NewGuid() + extension;
                var saveLocation = Path.Combine(resources, "wwwroot/AboutImages", fileName);

                using (var stream = new FileStream(saveLocation, FileMode.Create))
                {
                    model.Image.CopyTo(stream);
                    stream.Close();
                }

                var previousFileLocation = Path.Combine(resources, "wwwroot/AboutImages", aboutImage.Image);
                if (System.IO.File.Exists(previousFileLocation))
                {
                    System.IO.File.Delete(previousFileLocation);
                }

                aboutImage.Title = model.Title;
                aboutImage.Description = model.Description;
                aboutImage.Image = fileName;

                aboutImageService.Update(aboutImage);

                return RedirectToAction("Index");

            }
            return View();

        }
    }
}
