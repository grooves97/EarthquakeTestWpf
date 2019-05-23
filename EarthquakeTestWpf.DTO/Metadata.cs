using Newtonsoft.Json;

namespace EarthquakeTestWpf.DTO
{
    public class Metadata
    {
        [JsonProperty("title")]
        public string Title { get; set; }

        [JsonProperty("count")]
        public int Count { get; set; }
    }
}