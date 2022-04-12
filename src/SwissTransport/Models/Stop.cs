namespace SwissTransport.Models
{
    using System;
    using Newtonsoft.Json;

    public class Stop
    {
        [JsonProperty("departure")]
        public DateTime Departure { get; set; }

        [JsonProperty("arrival")]
        public DateTime? Arrival { get; set; }

        [JsonProperty("delay")]
        public string? Delay { get; set; }

        [JsonProperty("platform")]
        public string? Platform { get; set; }
    }
}