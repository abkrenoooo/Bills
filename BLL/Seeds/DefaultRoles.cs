
using BLL.Contants;
using Microsoft.AspNetCore.Identity;
using System.Linq;
using System.Threading.Tasks;

namespace BLL.Seeds
{
    public static class DefaultRoles
    {
        public static async Task SeedAsync(RoleManager<IdentityRole> roleManger)
        {
            if (!roleManger.Roles.Any())
            {
                await roleManger.CreateAsync(new IdentityRole(Roles.Server.ToString()));
                await roleManger.CreateAsync(new IdentityRole(Roles.Admin.ToString()));
            }
        }
    }
}