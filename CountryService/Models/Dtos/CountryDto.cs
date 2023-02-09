using Newtonsoft.Json;

namespace src.CountryService.CountryDemo.Models.Dtos
{
    public class CountryDto
    {


        [JsonProperty("iso3")]
        public string iso3 { get; set; }

        [JsonProperty("continent")]
        public string continent { get; set; }

        [JsonProperty("country")]
        public string country { get; set; }

    }
}