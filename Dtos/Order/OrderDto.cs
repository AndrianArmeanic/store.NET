using System;
using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;
using StoreApplication.Dtos.Product;
using StoreApplication.Dtos.User;

namespace StoreApplication.Dtos.Order
{
    public record OrderDto
    {
        [JsonProperty("userId"), Required]
        public Guid UserId { get; set; }

        [JsonProperty("productId"), Required]
        public Guid ProductId { get; set; }
        
        public UserDto? User { get; set; }
        
        public ProductDto? Product { get; set; }
    }
}
