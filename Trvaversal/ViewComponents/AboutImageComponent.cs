using BusinessLayer.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace Trvaversal.ViewComponents
{
    public class AboutImageComponent : ViewComponent
    {
        private readonly IAboutImageService _aboutImageService;

        public AboutImageComponent(IAboutImageService aboutImageService)
        {
            _aboutImageService = aboutImageService;
        }
        public IViewComponentResult Invoke()
        {
            var aboutImageList = _aboutImageService.GetList();
            return View(aboutImageList);
        }
    }
}
