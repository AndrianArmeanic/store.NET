using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;

namespace StoreApplication.Dtos.User
{
    public record UserNameDto
    {
        [JsonProperty("username"), Required]
        public string Username { get; set; }
    }
}
