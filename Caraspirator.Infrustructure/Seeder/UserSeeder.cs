using Caraspirator.Data.Entities.Identity;
using Microsoft.AspNetCore.Identity;


namespace Caraspirator.Infrustructure.Seeder
{
    public static class UserSeeder
    {
        public static async Task SeedAsync(UserManager<EspkUser> _userManager)
        {
            var usersCount = await _userManager.Users.CountAsync();
            if (usersCount <= 0)
            {
                var defaultuser = new EspkUser()
                {
                    UserName = "admin",
                    Email = "admin@project.com",
                    FullName = "EsparkProject",
                    Country = "Sudan",
                    PhoneNumber = "0123162750",
                    Address = "Sudan , jabra",
                    EmailConfirmed = true,
                    PhoneNumberConfirmed = true,
                };
                await _userManager.CreateAsync(defaultuser, "Moiez*007");
                await _userManager.AddToRoleAsync(defaultuser, "Admin");
            }
        }
    }
}
