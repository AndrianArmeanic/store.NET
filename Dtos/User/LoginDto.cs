using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;

namespace StoreApplication.Dtos.User
{
    public record LoginDto: UserNameDto
    {
        [JsonProperty("password"), Required, MinLength (8, ErrorMessage = "Too short password!")]
        public string Password { get; set; }
    }
}
