using Microsoft.AspNetCore.Authorization;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;

namespace hasslefreeAPI.Authorization
{
    public class PermissionAuthorizationHandler : AttributeAuthorizationHandler<PermissionAuthorizationRequirement, PermissionAttribute>
    {
        protected override async Task HandleRequirementAsync(AuthorizationHandlerContext context, PermissionAuthorizationRequirement requirement, IEnumerable<PermissionAttribute> attributes)
        {
            foreach (var permissionAttribute in attributes)
            {
                if (!await AuthorizeAsync(context.User, permissionAttribute.UielementCode))
                {
                    return;
                }
            }

            context.Succeed(requirement);
        }

        private Task<bool> AuthorizeAsync(ClaimsPrincipal user, string UielementCode)
        {

            return Task.FromResult(false);
            //Implement your custom user permission logic here
            //return false;
        }
    }
}
