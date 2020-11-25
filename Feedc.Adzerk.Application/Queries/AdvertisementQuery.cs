using System;
using Newtonsoft.Json;
using System.Net.Http;
using System.Threading.Tasks;
using System.Net.Http.Headers;
using System.Collections.Generic;
using Feedc.Adzerk.Application.Helpers;
using Feedc.Adzerk.Application.Helpers.Models;
using Feedc.Adzerk.Application.Infrastructure;

namespace Feedc.Adzerk.Application.Queries
{
    public class Placement
    {
        [JsonProperty(PropertyName = "siteId")]
        public int SiteId { get; set; }

        [JsonProperty(PropertyName = "adTypes")]
        public int[] AdTypes { get; set; }

        [JsonProperty(PropertyName = "networkId")]
        public int NetworkId { get; set; }

        [JsonProperty(PropertyName = "divName")]
        public string DivName { get; set; }

        [JsonProperty(PropertyName = "zoneIds")]
        public string[] ZoneIds { get; set; }

        [JsonProperty(PropertyName = "properties")]
        public Properties Properties { get; set; }

        [JsonProperty(PropertyName = "count")]
        public int Count { get; set; }
    }

    public class Properties
    {
        [JsonProperty(PropertyName = "Top")]
        public string Top { get; set; } = "Some value";
    }

    public class GeoTargeting
    {
        public string CountryCode { get; set; }

        public string Region { get; set; }

        public bool IsExclude { get; set; }

        public int MetroCode { get; set; }
    }

    public class AdvertisementQuery : Query<IEnumerable<AdvertisementQueryResult>>
    {
        [JsonProperty(PropertyName = "keywords")]
        public string[] Keywords { get; set; }

        [JsonProperty(PropertyName = "placements")]
        public IEnumerable<Placement> Placements { get; set; }

        public GeoTargeting GeoTargeting { get; set; }

        public async override Task<QueryExecutionResult<IEnumerable<AdvertisementQueryResult>>> ExecuteAsync()
        {
            try
            {
                using (var httpClient = new HttpClient())
                {
                    var decisionApiResponse = new DecisionApiResponse();
                    var result = new List<AdvertisementQueryResult>();


                    using (var request = new HttpRequestMessage(new HttpMethod("POST"), _config.DecisionApiRoute))
                    {
                        var jsonRequest = JsonConvert.SerializeObject(this);
                        request.Content = new StringContent(jsonRequest);
                        request.Content.Headers.ContentType = MediaTypeHeaderValue.Parse("application/json");

                        var response = await httpClient.SendAsync(request);

                        var content = await response.Content.ReadAsStringAsync();

                        if (!string.IsNullOrWhiteSpace(content))
                            decisionApiResponse = content.SerializeResponse<DecisionApiResponse>();
                    }

                    if (decisionApiResponse != null)
                        foreach (var decision in decisionApiResponse.Decisions.DivName)
                        {
                            using (var request = new HttpRequestMessage(new HttpMethod("GET"), _config.CreativeApiRoute + decision.CreativeId))
                            {
                                request.Headers.TryAddWithoutValidation("X-Adzerk-ApiKey", _config.ApiKey);

                                var response = await httpClient.SendAsync(request);

                                var content = await response.Content.ReadAsStringAsync();

                                if (!string.IsNullOrWhiteSpace(content))
                                {
                                    var creativeApiResponse = content.SerializeResponse<CreativeApiResponse>();
                                    var metaData = creativeApiResponse.Metadata.SerializeResponse<CreativeMetaDataResponse>();

                                    if (metaData != null)
                                    {
                                        result.Add(new AdvertisementQueryResult(metaData.Id,
                                                   decision.ClickUrl,
                                                   decision.ImpressionUrl));
                                    }
                                }
                            }
                        }

                    return await OkAsync(result);
                }
            }
            catch (Exception)
            {
                return await FailAsync();
            }
        }
    }

    public class AdvertisementQueryResult
    {
        public string PostId { get; private set; }

        public Uri ClickUrl { get; private set; }

        public Uri ImpressionUrl { get; private set; }

        public AdvertisementQueryResult(string postId,
                                        Uri clickUrl,
                                        Uri impressionUrl)
        {
            PostId = postId;
            ClickUrl = clickUrl;
            ImpressionUrl = impressionUrl;
        }
    }
}