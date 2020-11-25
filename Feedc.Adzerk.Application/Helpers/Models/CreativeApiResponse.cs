using System;
using Newtonsoft.Json;

namespace Feedc.Adzerk.Application.Helpers.Models
{
    public class CreativeApiResponse
    {
        [JsonProperty("Id")]
        public long Id { get; set; }

        [JsonProperty("AdvertiserId")]
        public long AdvertiserId { get; set; }

        [JsonProperty("AdTypeId")]
        public long AdTypeId { get; set; }

        [JsonProperty("Title")]
        public string Title { get; set; }

        [JsonProperty("ImageName")]
        public string ImageName { get; set; }

        [JsonProperty("Url")]
        public Uri Url { get; set; }

        [JsonProperty("Body")]
        public object Body { get; set; }

        [JsonProperty("ScriptBody")]
        public string ScriptBody { get; set; }

        [JsonProperty("Metadata")]
        public string Metadata { get; set; }

        [JsonProperty("ImageLink")]
        public Uri ImageLink { get; set; }

        [JsonProperty("Alt")]
        public string Alt { get; set; }

        [JsonProperty("IsDeleted")]
        public bool IsDeleted { get; set; }

        [JsonProperty("IsSync")]
        public bool IsSync { get; set; }

        [JsonProperty("IsHTMLJS")]
        public bool IsHtmljs { get; set; }

        [JsonProperty("IsActive")]
        public bool IsActive { get; set; }

        [JsonProperty("IsNoTrack")]
        public bool IsNoTrack { get; set; }

        [JsonProperty("IsNetworkAd")]
        public bool IsNetworkAd { get; set; }

        [JsonProperty("SaveEmptyCreative")]
        public object SaveEmptyCreative { get; set; }

        [JsonProperty("TemplateId")]
        public object TemplateId { get; set; }

        [JsonProperty("TemplateValues")]
        public object TemplateValues { get; set; }

        [JsonProperty("IsIdOnly")]
        public bool IsIdOnly { get; set; }
    }
}
