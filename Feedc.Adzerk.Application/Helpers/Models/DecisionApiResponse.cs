using System;
using Newtonsoft.Json;

namespace Feedc.Adzerk.Application.Helpers.Models
{
    public class DecisionApiResponse
    {
        [JsonProperty("user")]
        public User User { get; set; }

        [JsonProperty("decisions")]
        public Decisions Decisions { get; set; }
    }

    public partial class Decisions
    {
        [JsonProperty("divName")]
        public DivName[] DivName { get; set; }
    }

    public partial class DivName
    {
        [JsonProperty("adId")]
        public long AdId { get; set; }

        [JsonProperty("creativeId")]
        public long CreativeId { get; set; }

        [JsonProperty("flightId")]
        public long FlightId { get; set; }

        [JsonProperty("campaignId")]
        public long CampaignId { get; set; }

        [JsonProperty("priorityId")]
        public long PriorityId { get; set; }

        [JsonProperty("clickUrl")]
        public Uri ClickUrl { get; set; }

        [JsonProperty("impressionUrl")]
        public Uri ImpressionUrl { get; set; }

        [JsonProperty("contents")]
        public Content[] Contents { get; set; }

        [JsonProperty("height")]
        public long Height { get; set; }

        [JsonProperty("width")]
        public long Width { get; set; }

        [JsonProperty("events")]
        public object[] Events { get; set; }
    }

    public partial class Content
    {
        [JsonProperty("type")]
        public string Type { get; set; }

        [JsonProperty("data")]
        public Data Data { get; set; }

        [JsonProperty("body")]
        public string Body { get; set; }

        [JsonProperty("template")]
        public string Template { get; set; }
    }

    public partial class Data
    {
        [JsonProperty("height")]
        public long Height { get; set; }

        [JsonProperty("width")]
        public long Width { get; set; }

        [JsonProperty("imageUrl")]
        public Uri ImageUrl { get; set; }

        [JsonProperty("customData")]
        public CustomData CustomData { get; set; }

        [JsonProperty("title")]
        public string Title { get; set; }

        [JsonProperty("externalUrl")]
        public Uri ExternalUrl { get; set; }
    }

    public partial class CustomData
    {
        [JsonProperty("id")]
        public string Id { get; set; }
    }

    public partial class User
    {
        [JsonProperty("key")]
        public string Key { get; set; }
    }
}
