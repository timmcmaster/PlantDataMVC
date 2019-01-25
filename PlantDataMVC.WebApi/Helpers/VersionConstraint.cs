using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.Http.Routing;

namespace PlantDataMVC.WebApi.Helpers
{
    /// <summary>
    /// 
    /// </summary>
    /// <seealso cref="System.Web.Http.Routing.IHttpRouteConstraint" />
    internal class VersionConstraint: IHttpRouteConstraint
    {
        private const int DefaultVersion = 1;

        public VersionConstraint(int allowedVersion)
        {
            AllowedVersion = allowedVersion;
        }

        public int AllowedVersion
        {
            get;
        }

        public bool Match(HttpRequestMessage request, IHttpRoute route, string parameterName, IDictionary<string, object> values,
            HttpRouteDirection routeDirection)
        {
            // Try custom content type in accept header

            int? version = GetVersionFromCustomContentType(request);


            return ((version ?? DefaultVersion) == AllowedVersion);
        }

        private int? GetVersionFromCustomContentType(HttpRequestMessage request)
        {
            string versionAsString = null;

            // get the accept header.

            var mediaTypes = request.Headers.Accept.Select(h => h.MediaType);
            string matchingMediaType = null;
            // find the one with the version number - match through regex
            Regex regEx = new Regex(@"application\/vnd\.plantdataapi\.v([\d]+)\+json");

            foreach (var mediaType in mediaTypes)
            {
                if (regEx.IsMatch(mediaType))
                {
                    matchingMediaType = mediaType;
                    break;
                }
            }

            if (matchingMediaType == null)
                return null;

            // extract the version number
            Match m = regEx.Match(matchingMediaType);
            versionAsString = m.Groups[1].Value;

            // ... and return
            int version;
            if (versionAsString != null && Int32.TryParse(versionAsString, out version))
            {
                return version;
            }

            return null;
        }
    }
}