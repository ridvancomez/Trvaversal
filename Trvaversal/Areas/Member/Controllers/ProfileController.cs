using DataTransferObjectLayer.Concrete;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Trvaversal.Areas.Member.Controllers
{
    [Area("Member")]
    [Route("Member/[controller]/[action]")]
    public class ProfileController : Controller
    {
        private readonly UserManager<AppUser> _userManager;

        public ProfileController(UserManager<AppUser> userManager)
        {
            _userManager = userManager;
        }
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var user = await _userManager.FindByNameAsync(User.Identity.Name);
            UserEditDTO userEditDTO = new UserEditDTO
            {
                Name = user.Name,
                Surname = user.Surname,
                UserName = user.UserName,
                Email = user.Email,
                ImageUrl = user.ImageUrl
            };
            ViewBag.ActivePage = "Profile";
            return View(userEditDTO);
        }

        [HttpPost]
        public async Task<IActionResult> Index(UserEditDTO model)
        {
            if (ModelState.IsValid)
            {
                var user = await _userManager.FindByNameAsync(User.Identity.Name);

                if (model.Image != null)
                {
                    var resource = Directory.GetCurrentDirectory();
                    var extension = Path.GetExtension(model.Image.FileName);
                    var imageName = Guid.NewGuid() + extension;
                    var saveLocation = resource + Path.Combine("/wwwroot/UserImages", imageName);
                    var stream = new FileStream(saveLocation, FileMode.Create);

                    await model.Image.CopyToAsync(stream);
                    user.ImageUrl = imageName;
                }
                user.Name = model.Name;
                user.Surname = model.Surname;
                user.UserName = model.UserName;
                user.Email = model.Email;
                if (model.Password != null)
                {
                    user.PasswordHash = _userManager.PasswordHasher.HashPassword(user, model.Password);
                }
                var result = await _userManager.UpdateAsync(user);

                if (result.Succeeded)
                {
                    return RedirectToAction("Register", "Login");
                }


            }
            return View();
        }
    }
}
