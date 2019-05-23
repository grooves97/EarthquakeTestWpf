using Newtonsoft.Json;

namespace EarthquakeTestWpf.DTO
{
    public class Feature
    {
        [JsonProperty("properties")]
        public Properties Properties { get; set; }
    }
}