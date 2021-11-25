namespace marvelApi
{
    using Newtonsoft.Json;
    public class HeroesResponse
    {
        [JsonProperty("data")]
        public Data Data { get; set; }
    }
    public class Data
    {
        [JsonProperty("results")]
        public Results Results { get; set; }
    }
    public class Results
    {
        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("description")]
        public string Description { get; set; }
    }
}
