using BusinessLayer.Abstract;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
    public class AppUserManager : IAppUserService
    {
        private readonly UserManager<AppUser> userManager;
public AppUserManager(UserManager<AppUser> userManager)
        {
            this.userManager = userManager;
        }

        public async Task<List<SelectListItem>> GetUserListAsync()
        {
            var users = await userManager.Users.ToListAsync();

            var userList = users.Select(user => new SelectListItem
            {
                Value = user.Id.ToString(),
                Text = user.Name + " " + user.Surname,
            }).ToList();

            return userList;
        }
    }
}
