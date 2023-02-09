using Newtonsoft.Json;

namespace src.ExchangeService.ExchangeDemo.Models.Dtos
{
    public class ExchangeDto
    {
        [JsonProperty("id")]
        public string? Id { get; set; }

        [JsonProperty("name")]
        public string? Name { get; set; }

        [JsonProperty("year")]
        public int? Year { get; set; }

        [JsonProperty("country")]
        public string? Country { get; set; }

        [JsonProperty("description")]
        public string? Description { get; set; }

        [JsonProperty("url")]
        public string? Url { get; set; }

        [JsonProperty("image")]
        public string? Image { get; set; }
        [JsonProperty("trust_score")]
        public int? Trust_score { get; set; }
        [JsonProperty("trust_score_rank")]
        public int? Trust_score_rank { get; set; }
        [JsonProperty("trade_volume_24h_btc")]
        public decimal? Trade_volume_24h_btc { get; set; }
        [JsonProperty("trade_volume_24h_btc_normalized")]
        public decimal? Trade_volume_24h_btc_normalized { get; set; }


    }
}