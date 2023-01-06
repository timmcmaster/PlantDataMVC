namespace PlantDataMVC.Web.Helpers
{
    public static class AuthorizationPolicies
    {
        public const string RequireReadUserRole = "RequireReadUserRole";
        public const string RequireWriteUserRole = "RequireWriteUserRole";
        public const string RequireAdminUserRole = "RequireAdminUserRole";
    }
}