using Newtonsoft.Json;

namespace Covid19.Models
{
    [JsonObject(ItemNullValueHandling = NullValueHandling.Ignore)]
    public abstract class CovidDTO
    {
    }
}