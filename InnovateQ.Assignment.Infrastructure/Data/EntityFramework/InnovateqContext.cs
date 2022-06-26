using InnovateQ.Assignment.Infrastructure.Data.Entities;
using InnovateQ.Assignment.Infrastructure.Data.EntityFramework.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace InnovateQ.Assignment.Infrastructure.Data.EntityFramework
{
    public class InnovateqContext : IdentityDbContext<AppUser>
    {
        public InnovateqContext(DbContextOptions<InnovateqContext> options) : base(options)
        {

        }

        public override int SaveChanges()
        {
            AddAuitInfo();
            return base.SaveChanges();
        }

        public async Task<int> SaveChangesAsync()
        {
            AddAuitInfo();
            return await base.SaveChangesAsync();
        }

        private void AddAuitInfo()
        {
            var entries = ChangeTracker.Entries().Where(x => x.Entity is BaseEntity && (x.State == EntityState.Added || x.State == EntityState.Modified));
            foreach (var entry in entries)
            {
                if (entry.State == EntityState.Added)
                {
                    ((BaseEntity)entry.Entity).Created = DateTime.UtcNow;
                }
                ((BaseEntity)entry.Entity).Modified = DateTime.UtcNow;
            }
        }

        public static async Task CreateAdminAccount(IServiceProvider
serviceProvider, IConfiguration configuration)
        {
            UserManager<AppUser> userManager =
    serviceProvider.GetRequiredService<UserManager<AppUser>>();
            RoleManager<IdentityRole> roleManager =
    serviceProvider.GetRequiredService<RoleManager<IdentityRole>>();

            string userName = configuration["Data:AdminUser:Name"];
            string email = configuration["Data:AdminUser:Email"];
            string password = configuration["Data:AdminUser:Password"];
            string role = configuration["Data:AdminUser:Role"];

            if (await userManager.FindByNameAsync(userName) == null)
            {
                if (await roleManager.FindByNameAsync(role) == null)
                {
                    await roleManager.CreateAsync(new IdentityRole(role));
                }

                AppUser user = new AppUser
                {
                    Email = email,
                    UserName = userName
                };
                var result = userManager.CreateAsync(user, password);
                if (result.IsCompletedSuccessfully)
                {
                    await userManager.AddToRoleAsync(user, role);
                }
            }
        }

        public DbSet<Core.Entities.User> AppUsers { get; set; }
    }
}
