using BusinessLayer.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace Trvaversal.ViewComponents
{
    public class PopulerDestinationComponent : ViewComponent
    {
        private readonly IDestinationService _destinationService;
        public PopulerDestinationComponent(IDestinationService destinationService)
        {
            _destinationService = destinationService;
        }
        public IViewComponentResult Invoke()
        {
            var populerDestinations = _destinationService.GetList().Where(x=> x.Status == true && x.Popular == true).ToList();
            return View(populerDestinations);
        }
    }
}
