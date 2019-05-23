using Newtonsoft.Json;
using System.Collections.Generic;

namespace EarthquakeTestWpf.DTO
{
    public class FeatureCollection
    {
        [JsonProperty("features")]
        public List<Feature> Features { get; set; }
    }
}