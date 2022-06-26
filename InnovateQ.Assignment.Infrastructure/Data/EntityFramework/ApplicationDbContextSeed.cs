using InnovateQ.Assignment.Infrastructure.Data.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InnovateQ.Assignment.Infrastructure.Data.EntityFramework
{
    public static class ApplicationDbContextSeed
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            var serviceScope = serviceProvider.CreateScope();
            var context = serviceProvider.GetService<InnovateqContext>();

            string[] roles = new string[] { "Owner", "Administrator", "Manager" };

            foreach (string role in roles)
            {
                var roleStore = new RoleStore<IdentityRole>(context);

                if (!context.Roles.Any(r => r.Name == role))
                {
                    roleStore.CreateAsync(new IdentityRole(role));
                    context.SaveChangesAsync();
                }
            }


            var user = new AppUser
            {
                FirstName = "Admin",
                LastName = "User",
                Email = "admin@localhost",
                NormalizedEmail = "ADMIN@LOCALHOST",
                UserName = "Admin",
                NormalizedUserName = "ADMIN",
                PhoneNumber = "+111111111111",
                EmailConfirmed = true,
                PhoneNumberConfirmed = true,
                SecurityStamp = Guid.NewGuid().ToString("D")
            };


            if (!context.Users.Any(u => u.UserName == user.UserName))
            {
                var password = new PasswordHasher<AppUser>();
                var hashed = password.HashPassword(user, "Admin@1");
                user.PasswordHash = hashed;

                var userStore = new UserStore<AppUser>(context);
                var result = userStore.CreateAsync(user);

            }

            AssignRoles(serviceProvider, user.Email, roles);

            context.SaveChangesAsync();
        }

        public static async Task<IdentityResult> AssignRoles(IServiceProvider services, string email, string[] roles)
        {
            UserManager<AppUser> _userManager = services.GetService<UserManager<AppUser>>();
            AppUser user = await _userManager.FindByEmailAsync(email);
            var result = await _userManager.AddToRolesAsync(user, roles);

            return result;
        }
    }
}
