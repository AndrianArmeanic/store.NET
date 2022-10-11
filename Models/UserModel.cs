using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace StoreApplication.Models
{
    [Index (nameof(UserModel.Email), IsUnique = true)]
    public class UserModel : IdentityUser
    {
        [Required, EmailAddress]
        public string Email { get; set; }

        [Required, MinLength (8, ErrorMessage = "Too short password!"), DataType(DataType.Password)]
        public string Password { get; set; }
    }
};
