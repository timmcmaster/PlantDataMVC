namespace PlantDataMVC.Constants
{
    public static class PlantDataMvcConstants
    {
        public const string PlantDataApi = "https://localhost:6101/";
        public const string PlantDataClient = "https://localhost:44390/";

        public const string IdSrvIssuerUri = "https://plantdataidsrv3/embedded";

        public const string IdSrv = "https://localhost:5001";
        public const string IdSrvToken = IdSrv + "/connect/token";
        public const string IdSrvAuthorize = IdSrv + "/connect/authorize";
        public const string IdSrvUserInfo = IdSrv + "/connect/userinfo";

    }
    //TODO:  Move to a more appropriate/correct location
    public static class AuthorizationRole
    {
        public const string WebReadUser = "WebReadUser";
        public const string WebWriteUser = "WebWriteUser";
        public const string WebAdminUser = "WebAdminUser";
    }
}
