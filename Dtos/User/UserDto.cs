using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;

namespace StoreApplication.Dtos.User
{
    public record UserDto: UserNameDto
    {
        [JsonProperty("email"), Required, EmailAddress]
        public string Email { get; set; }
    }
}
