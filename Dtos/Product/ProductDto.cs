using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;

namespace StoreApplication.Dtos.Product
{
    public record ProductDto
    {
        [JsonProperty("name"), Required]
        public string Name { get; set; } = default!;

        [JsonProperty("description")]
        public string? Description { get; set; }

        [JsonProperty("price"), Required]
        public decimal Price { get; set; }
    }
}
