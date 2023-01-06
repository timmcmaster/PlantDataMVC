using Newtonsoft.Json;
using System;
using System.Linq;
using System.Net.Http.Headers;
using System.Text.RegularExpressions;

namespace PlantDataMVC.UICore.Helpers
{
    public static class HeaderParser
    {
        public static ApiPagingInfo FindAndParsePagingInfo(HttpResponseHeaders responseHeaders)
        {
            // read custom pagination header
            if (responseHeaders.Contains("X-Pagination"))
            {
                var xPagHdr = responseHeaders.First(ph => ph.Key == "X-Pagination").Value;
                // parse the value - this is a JSON-string.
                return JsonConvert.DeserializeObject<ApiPagingInfo>(xPagHdr.First());
            }

            return null;
        }

        public static LinkHeader FindAndParseLinkInfo(HttpResponseHeaders responseHeaders)
        {
            if (responseHeaders.Contains("Link"))
            {
                // TODO: Parse as (proposed) RFC8288 https://httpwg.org/specs/rfc8288.html
                // Read comma-separated collection of links in format "<{0}>; rel=\"{1}\""
                // e.g.
                var linkHeaderText = responseHeaders.First(ph => ph.Key == "Link").Value;
                var linkEntries = linkHeaderText.First().Split(',');

                LinkHeader linkHeader = new LinkHeader();

                foreach (var linkEntry in linkEntries)
                {
                    var relMatch = Regex.Match(linkEntry, "(?<=rel=\").+?(?=\")", RegexOptions.IgnoreCase);
                    var linkMatch = Regex.Match(linkEntry, "(?<=<).+?(?=>)", RegexOptions.IgnoreCase);

                    if (relMatch.Success && linkMatch.Success)
                    {
                        string rel = relMatch.Value.ToUpper();
                        string link = linkMatch.Value;

                        switch (rel)
                        {
                            case "FIRST":
                                linkHeader.FirstPageLink = new Uri(link);
                                break;
                            case "PREV":
                                linkHeader.PrevPageLink = new Uri(link);
                                break;
                            case "NEXT":
                                linkHeader.NextPageLink = new Uri(link);
                                break;
                            case "LAST":
                                linkHeader.LastPageLink = new Uri(link);
                                break;
                        }
                    }
                }

                return linkHeader;
            }

            return null;
        }
    }
}