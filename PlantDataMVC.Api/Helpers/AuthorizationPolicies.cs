namespace PlantDataMVC.Api.Helpers
{
    public static class AuthorizationPolicies
    {
        /*
        public const string ReadPolicy = "ReadPolicy";
        public const string WritePolicy = "WritePolicy";
        public const string AdminUserPolicy = "AdminUserPolicy";
        */
        public const string RequireReadUserRole = "RequireReadUserRole";
        public const string RequireWriteUserRole = "RequireWriteUserRole";
        public const string RequireAdminUserRole = "RequireAdminUserRole";
    }
}