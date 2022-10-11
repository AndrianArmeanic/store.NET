using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;

namespace StoreApplication.Dtos.User
{
    public record RegisterDto: UserNameDto
    {
        [JsonProperty("email"), Required, EmailAddress]
        public string Email { get; set; }

        [JsonProperty("password"), Required, MinLength (8, ErrorMessage = "Too short password!")]
        public string Password { get; set; }
    }
}
