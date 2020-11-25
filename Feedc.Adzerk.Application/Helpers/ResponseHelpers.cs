using Newtonsoft.Json;

namespace Feedc.Adzerk.Application.Helpers
{
    public static class ResponseHelpers
    {
        public static TResponse SerializeResponse<TResponse>(this string content) =>
            JsonConvert.DeserializeObject<TResponse>(content);
    }
}
