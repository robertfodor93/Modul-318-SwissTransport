namespace SwissTransport.Models
{
    using Newtonsoft.Json;

    internal class SearchCHLocations
    {
        [JsonProperty("label")]
        public string Name { get; set; }

        [JsonProperty("dist")]
        public double Distance { get; set; }

        [JsonProperty("lat")]
        public double? XCoordinate { get; set; }

        [JsonProperty("lon")]
        public double? YCoordinate { get; set; }
    }
}
