using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlantDataMVC.Constants
{
    public class PlantDataMvcConstants
    {
        public const string PlantDataApi = "http://localhost:53274/";
        public const string PlantDataClient = "https://localhost:44390/";

        public const string IdSrvIssuerUri = "https://plantdataidsrv3/embedded";

        public const string IdSrv = "https://localhost:44305/identity";
        public const string IdSrvToken = IdSrv + "/connect/token";
        public const string IdSrvAuthorize = IdSrv + "/connect/authorize";
        public const string IdSrvUserInfo = IdSrv + "/connect/userinfo";

    }
}
