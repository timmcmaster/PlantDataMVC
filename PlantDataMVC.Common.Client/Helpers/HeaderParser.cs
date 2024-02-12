﻿using Newtonsoft.Json;
using PlantDataMVC.Common.Client.Models;
using System.Net.Http.Headers;
using System.Text.RegularExpressions;

namespace PlantDataMVC.Common.Client.Helpers
{
    public static partial class HeaderParser
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
                var linkHeaderText = responseHeaders.First(ph => ph.Key == "Link").Value;
                var linkEntries = linkHeaderText.First().Split(',');

                LinkHeader linkHeader = new();

                foreach (var linkEntry in linkEntries)
                {
                    var relMatch = RelUriRegex().Match(linkEntry);
                    var linkMatch = LinkUriRegex().Match(linkEntry);

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

        [GeneratedRegex("(?<=rel=\").+?(?=\")", RegexOptions.IgnoreCase, "en-AU")]
        private static partial Regex RelUriRegex();

        [GeneratedRegex("(?<=<).+?(?=>)", RegexOptions.IgnoreCase, "en-AU")]
        private static partial Regex LinkUriRegex();
    }
}