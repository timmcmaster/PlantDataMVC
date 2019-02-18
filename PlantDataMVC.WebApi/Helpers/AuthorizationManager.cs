using System.Linq;
using System.Threading.Tasks;
using Thinktecture.IdentityModel.Owin.ResourceAuthorization;

namespace PlantDataMVC.WebApi.Helpers
{
    public class AuthorizationManager: ResourceAuthorizationManager
    {
        public override Task<bool> CheckAccessAsync(ResourceAuthorizationContext context)
        {
            // Check the requested resource
            switch (context.Resource.First().Value)
            {
                case "Genus":
                case "Species":
                case "SeedBatch":
                case "SeedTray":
                case "Site":
                case "PlantStock":
                case "JournalEntries":
                    return AuthorizeStandardEntities(context);
                case "ProductType":
                case "JournalEntryType":
                    return AuthorizeAdminEntities(context);
                default:
                    return Nok();
            }
        }

        // Check the requested actions for given resource
        private Task<bool> AuthorizeStandardEntities(ResourceAuthorizationContext context)
        {
            switch (context.Action.First().Value)
            {
                case "Read":
                    return Eval(context.Principal.HasClaim("role", "WebReadUser"));
                case "Write":
                    return Eval(context.Principal.HasClaim("role", "WebWriteUser"));
                default:
                    return Nok();
            }
        }

        // Check the requested actions for given resource
        private Task<bool> AuthorizeAdminEntities(ResourceAuthorizationContext context)
        {
            switch (context.Action.First().Value)
            {
                case "Read":
                    return Eval(context.Principal.HasClaim("role", "WebReadUser"));
                case "Write":
                    return Eval(context.Principal.HasClaim("role", "WebAdminUser"));
                default:
                    return Nok();
            }
        }
    }
}