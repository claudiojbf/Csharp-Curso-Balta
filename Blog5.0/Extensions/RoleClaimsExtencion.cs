using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using BlogApi.Models;

namespace BlogApi.Extensions
{
    public static class RoleClaimsExtencion
    {
        public static IEnumerable<Claim> GetClaims(this User user)
        {
            var result = new List<Claim>
            {
                new (ClaimTypes.Name, user.Email)
            };

            result.AddRange(
                user.Roles.Select(role => new Claim(ClaimTypes.Role, role.Slug))
            );

            return result;
        }
        
    }
}