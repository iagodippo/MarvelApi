using System.Collections.Generic;
using Newtonsoft.Json;

namespace marvelApi
{
    public class HeroeResponseDto
    {
        [JsonProperty("data")]
        public DataResponseDto Data { get; set; }
    }

    public class DataResponseDto
    {
        [JsonProperty("results")]
        public List<ResultsResponseDto> Results { get; set; }
    }

    public class ResultsResponseDto
    {
        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("description")]
        public string Description { get; set; }
    }
}