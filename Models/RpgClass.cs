using System.Text.Json.Serialization;

namespace net.core.api.Models
{
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum RpgClass
    {
        Jedi = 0,
        Sith = 1,
    }
}