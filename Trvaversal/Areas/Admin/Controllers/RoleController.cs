using DataTransferObjectLayer.Concrete;
using DocumentFormat.OpenXml.Office.CustomUI;
using DocumentFormat.OpenXml.Office2010.Excel;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Trvaversal.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("Admin/[controller]/[action]")]
    [Route("Admin/[controller]/[action]/{id?}")]
    public class RoleController : Controller
    {
        private readonly RoleManager<AppRole> roleManager;
        private readonly UserManager<AppUser> userManager;
        public RoleController(RoleManager<AppRole> roleManager, UserManager<AppUser> userManager)
        {
            this.roleManager = roleManager;
            this.userManager = userManager;
        }
        public IActionResult Index()
        {
            var values = roleManager.Roles.ToList();
            return View(values);
        }

        [HttpGet]
        public IActionResult AddRole()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> AddRole(RoleDTO formRole)
        {
            var role = new AppRole()
            {
                Name = formRole.RoleName
            };

            var result = await roleManager.CreateAsync(role);
            if (result.Succeeded)
            {
                return RedirectToAction("Index");
            }
            return View();
        }
        [HttpGet]
        public async Task<IActionResult> DeleteRole(int id)
        {
            var value = roleManager.Roles.FirstOrDefault(x => x.Id == id);
            await roleManager.DeleteAsync(value);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult UpdateRole(int id)
        {
            var value = roleManager.Roles.FirstOrDefault(x => x.Id == id);
            var formRole = new RoleEditDTO()
            {
                Id = id,
                RoleName = value.Name
            };

            return View(formRole);
        }

        [HttpPost]
        public async Task<IActionResult> UpdateRole(RoleEditDTO formRole)
        {
            var value = roleManager.Roles.FirstOrDefault(x => x.Id == formRole.Id);
            value.Name = formRole.RoleName;

            var result = await roleManager.UpdateAsync(value);

            if (result.Succeeded)
                return RedirectToAction("Index");
            else
                return View(formRole);
        }

        public IActionResult UserList()
        {
            var users = userManager.Users.ToList();

            return View(users);
        }

        [HttpGet]
        public async Task<IActionResult> AssignRole(int id)
        {
            var user = userManager.Users.FirstOrDefault(x => x.Id == id);
            TempData["UserId"] = user.Id;
            var roleList = roleManager.Roles.ToList();
            var userRole = await userManager.GetRolesAsync(user);

            List<RoleListDTO> roles = new List<RoleListDTO>();

            foreach (var item in roleList)
            {
                var role = new RoleListDTO();
                role.Id = item.Id;
                role.Name = item.Name;
                role.Exist = userRole.Contains(item.Name);
                roles.Add(role);

            }

            return View(roles);
        }

        [HttpPost]
        public async Task<IActionResult> AssignRole(List<RoleListDTO> roles)
        {
            int userId = Convert.ToInt32(TempData["UserId"]);
            var user = userManager.Users.FirstOrDefault(x => x.Id == userId);

            foreach (var role in roles)
            {
                if(role.Exist)
                {
                    await userManager.AddToRoleAsync(user, role.Name);
                }
                else
                {
                    await userManager.RemoveFromRoleAsync(user, role.Name);
                }
            }

            return RedirectToAction("Index");
        }
    }
}
