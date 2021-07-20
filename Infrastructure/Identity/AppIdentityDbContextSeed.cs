using System.Linq;
using System.Threading.Tasks;
using Core.Entities.Identity;
using Microsoft.AspNetCore.Identity;

namespace Infrastructure.Identity
{
    public class AppIdentityDbContextSeed
    {
        public static async Task SeedUserAsync(UserManager<AppUser> userManager)
        {

            if (!userManager.Users.Any())
            {

                var user = new AppUser
                {
                    DisplayName = "Bob",
                    Email = "Bob@test.com",
                    UserName = "bob",
                    Address = new Address()
                    {
                        FirstName = "Bob",
                        LastName = "Citizen",
                        Street = "1 Street Name",
                        State = "VIC",
                        City = "Melbourne",
                        ZipCode = "3000"
                    }
                };

                await userManager.CreateAsync(user, "Pa$$w0rd");
            }

        }
    }
}