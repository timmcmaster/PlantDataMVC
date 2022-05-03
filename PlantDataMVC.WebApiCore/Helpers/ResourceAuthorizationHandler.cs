using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using PlantDataMVC.Constants;

namespace PlantDataMVC.WebApiCore.Helpers
{
    public class ResourceAuthorizationHandler //: IAuthorizationHandler
    {
        /*
        public Task HandleAsync(AuthorizationHandlerContext context)
        {
            // Check the requested resource
            switch (context.Resource)
            {
                case "Genus":
                case "Species":
                case "SeedBatch":
                case "SeedTray":
                case "Site":
                case "PlantStock":
                case "JournalEntries":
                    AuthorizeStandardEntities(context);
                    break;
                case "ProductType":
                case "JournalEntryType":
                    AuthorizeAdminEntities(context);
                    break;
                default:
                    break;
            }

            return Task.CompletedTask;
        }

        // Check the requested actions for given resource
        private void AuthorizeStandardEntities(AuthorizationHandlerContext context)
        {
            var pendingRequirements = context.PendingRequirements.ToList();

            foreach (var req in pendingRequirements)
            {
                if (req is ReadPermissionRequirement)
                {
                    if (IsReadUser(context.User))
                    {
                        context.Succeed(req);
                    }
                }
                else if (req is WritePermissionRequirement)
                {
                    if (IsWriteUser(context.User))
                    {
                        context.Succeed(req);
                    }
                }
            }
        }

        // Check the requested actions for given resource
        private void AuthorizeAdminEntities(AuthorizationHandlerContext context)
        {
            var pendingRequirements = context.PendingRequirements.ToList();

            foreach (var req in pendingRequirements)
            {
                if (req is ReadPermissionRequirement)
                {
                    if (IsReadUser(context.User))
                    {
                        context.Succeed(req);
                    }
                }
                else if (req is WritePermissionRequirement)
                {
                    // write permission only for admin users
                    if (IsAdminUser(context.User))
                    {
                        context.Succeed(req);
                    }
                }
            }
        }

        private static bool IsReadUser(ClaimsPrincipal user)
        {
            return user.HasClaim("role", AuthorizationRole.WebReadUser);
        }

        private static bool IsWriteUser(ClaimsPrincipal user)
        {
            return user.HasClaim("role", AuthorizationRole.WebWriteUser);
        }

        private static bool IsAdminUser(ClaimsPrincipal user)
        {
            return user.HasClaim("role", AuthorizationRole.WebAdminUser);
        }
        */
    }

    /*
    public class ReadPermissionRequirement : IAuthorizationRequirement { }
    public class WritePermissionRequirement : IAuthorizationRequirement { }
    public class AdminPermissionRequirement : IAuthorizationRequirement { }
*/
}