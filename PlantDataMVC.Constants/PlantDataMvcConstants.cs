namespace PlantDataMVC.Constants
{
    // TODO: Make this part of app config for relevant apps
    public static class PlantDataMvcConstants
    {
        public const string PlantDataApi = "https://localhost:6001";
        public const string PlantDataApi_IIS = "https://localhost:6101";

        public const string PlantDataClient = "https://localhost:7001";

        public const string IdSrvIssuerUri = "https://plantdataidsrv3/embedded";

        public const string IdSrvBase = "https://localhost:5001";
        public const string IdSrvToken = IdSrvBase + "/connect/token";
        public const string IdSrvAuthorize = IdSrvBase + "/connect/authorize";
        public const string IdSrvUserInfo = IdSrvBase + "/connect/userinfo";

        public const bool UseBasicMvcViews = true;
    }

    //TODO:  Move to a more appropriate/correct location
    public static class AuthorizationRole
    {
        public const string WebReadUser = "WebReadUser";
        public const string WebWriteUser = "WebWriteUser";
        public const string WebAdminUser = "WebAdminUser";
    }
}
