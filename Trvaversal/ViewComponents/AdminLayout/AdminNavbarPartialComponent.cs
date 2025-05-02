using EntityLayer.Concrete;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Trvaversal.ViewComponents.AdminLayout
{
    public class AdminNavbarPartialComponent : ViewComponent
    {
        private readonly UserManager<AppUser> _userManager;

        public AdminNavbarPartialComponent(UserManager<AppUser> userManager)
        {
            _userManager = userManager;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var user = await _userManager.FindByNameAsync(User.Identity.Name);

            ViewBag.UserImageUrl = user.ImageUrl;
            ViewBag.Name = user.Name + " " + user.Surname;
            return View();
        }
    }
}
