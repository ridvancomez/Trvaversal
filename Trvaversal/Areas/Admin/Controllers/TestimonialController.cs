using BusinessLayer.Abstract;
using DataTransferObjectLayer.Concrete;
using Elfie.Serialization;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Update.Internal;
using System.ComponentModel.Design;
using System.Drawing;

namespace Trvaversal.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("Admin/[controller]/[action]")]
    [Route("Admin/[controller]/[action]/{id?}")]
    public class TestimonialController : Controller
    {
        private readonly ITestimonialService testimonialService;

        public TestimonialController(ITestimonialService testimonialService)
        {
            this.testimonialService = testimonialService;
        }

        public IActionResult Index()
        {
            var model = testimonialService.GetList();
            return View(model);
        }

        [HttpGet]
        public IActionResult AddTestimonial()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddTestimonial(TestimonialDTO model)
        {
            if (ModelState.IsValid)
            {
                var testimonial = new Testimonial
                {
                    Client = model.Client,
                    Comment = model.Comment,
                    Status = model.Status
                };

                //Dosya yükle
                var resource = Directory.GetCurrentDirectory();
                var extension = Path.GetExtension(model.Image.FileName);
                var fileName = Guid.NewGuid() + extension;
                var saveLocation = resource + Path.Combine("/wwwroot/TestimonialImages", fileName);

                using (var stream = new FileStream(saveLocation, FileMode.Create))
                {
                    model.Image.CopyTo(stream);
                    stream.Close();
                }

                testimonial.ClientImage = fileName;

                testimonialService.Add(testimonial);
                return RedirectToAction("Index");
            }
            return View();
        }

        [HttpGet]
        public IActionResult UpdateTestimonial(int id)
        {
            var testimonial = testimonialService.GetById(id);

            var model = new TestimonialDTO
            {
                Id = id,
                Client = testimonial.Client,
                ClientImage = testimonial.ClientImage,
                Status = testimonial.Status,
                Comment = testimonial.Comment
            };

            return View(model);
        }

        [HttpPost]
        public IActionResult UpdateTestimonial(TestimonialDTO model)
        {
            if (ModelState.IsValid)
            {
                var testimonial = testimonialService.GetById(model.Id);

                testimonial.Client = model.Client;
                testimonial.Comment = model.Comment;
                testimonial.Status = model.Status;

                //Dosya yükleme
                var resource = Directory.GetCurrentDirectory();
                var extension = Path.GetExtension(model.Image.FileName);
                var fileName = Guid.NewGuid() + extension;
                var saveLocation = resource + Path.Combine("/wwwroot/TestimonialImages", fileName);

                using (var stream = new FileStream(saveLocation, FileMode.Create))
                {
                    model.Image.CopyTo(stream);
                    stream.Close();
                }

                //Dosya Silme
                var previousImageLocation = resource + Path.Combine("/wwwroot/TestimonialImages", testimonial.ClientImage);

                if (System.IO.File.Exists(previousImageLocation))
                {
                    System.IO.File.Delete(previousImageLocation);
                }

                testimonial.ClientImage = fileName;

                testimonialService.Update(testimonial);

                return RedirectToAction("Index");
            }
            return View();
        }

        public IActionResult DeleteTestimonial(int id)
        {
            var model = testimonialService.GetById(id);

            //Dosya Silme
            var previousImageLocation = Directory.GetCurrentDirectory() + Path.Combine("/wwwroot/TestimonialImages", model.ClientImage);

            if (System.IO.File.Exists(previousImageLocation))
            {
                System.IO.File.Delete(previousImageLocation);
            }

            testimonialService.Delete(model);

            return RedirectToAction("Index");
        }

    }
}
