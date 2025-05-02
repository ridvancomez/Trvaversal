using EntityLayer.Concrete;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Trvaversal.ViewComponents.MemberDashboard
{
    public class ProfileInformationComponent: ViewComponent
    {
        private readonly UserManager<AppUser> _userManager;

        public ProfileInformationComponent(UserManager<AppUser> userManager)
        {
            _userManager = userManager;
        }

        public  async Task<IViewComponentResult> InvokeAsync()
        {
            var user = await _userManager.FindByNameAsync(User.Identity.Name);

            ViewBag.Phone = user.PhoneNumber;
            ViewBag.Email = user.Email;
            return View();
        }
    }
}
