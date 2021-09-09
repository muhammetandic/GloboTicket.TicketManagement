using GloboTicket.TicketManagement.Identity.Models;
using Microsoft.AspNetCore.Identity;
using System.Threading.Tasks;

namespace GloboTicket.TicketManagement.Identity.Seed
{
    public static class UserCreator
    {
        public static async Task SeedAsync(UserManager<ApplicationUser> userManager)
        {
            var applicationUser = new ApplicationUser
            {
                FirstName = "Muhammet",
                LastName = "Andiç",
                UserName = "mandic",
                Email = "m_andic@hotmail.com",
                EmailConfirmed = true
            };
            var user = await userManager.FindByEmailAsync(applicationUser.Email);
            if(user==null)
            {
                await userManager.CreateAsync(applicationUser, "deneme");
            }
        }
    }
}
