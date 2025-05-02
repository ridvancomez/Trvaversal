using BusinessLayer.Abstract;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace Trvaversal.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("Admin/[controller]/[action]")]
    [Route("Admin/[controller]/[action]/{id?}")]
    public class SubAboutController : Controller
    {
        private readonly ISubAboutService subAboutService;

        public SubAboutController(ISubAboutService subAboutService)
        {
            this.subAboutService = subAboutService;
        }

        [HttpGet]
        public IActionResult Index()
        {
            var model = subAboutService.GetFirst();

            return View(model);
        }

        [HttpPost]
        public IActionResult Index(SubAbout model)
        {
            if (ModelState.IsValid)
            {
                subAboutService.Update(model);
                return View(model);
            }
            var subAbout = subAboutService.GetFirst();

            return View(subAbout);
        }

    }
}
