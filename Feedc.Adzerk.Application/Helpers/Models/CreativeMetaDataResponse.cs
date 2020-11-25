using Newtonsoft.Json;

namespace Feedc.Adzerk.Application.Helpers.Models
{
    public class CreativeMetaDataResponse
    {
        [JsonProperty(PropertyName = "id")]
        public string Id { get; set; }
    }
}
