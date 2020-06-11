using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Core.Entities.Identity;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace API.Extensions
{
    public static class UserManagerExtensions
    {
        public static async Task<AppUser> FindByUserByClaimsPrincipleWithAddressAsync(this UserManager<AppUser> Input, ClaimsPrincipal user)
        {
             var email = user?.Claims?.FirstOrDefault(x => x.Type == ClaimTypes.Email)?.Value;

             return await Input.Users.Include(x => x.Address).SingleOrDefaultAsync(x => x.Email == email);
        }

        public static async Task<AppUser> FindByEmailWithClaimsPrincipal(this UserManager<AppUser> Input, ClaimsPrincipal user)
        {
            var email = user?.Claims?.FirstOrDefault(x => x.Type == ClaimTypes.Email)?.Value;
            return await Input.Users.SingleOrDefaultAsync(x => x.Email == email);
        }
    }
}