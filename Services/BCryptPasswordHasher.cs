using Microsoft.AspNetCore.Identity;
using StoreApplication.Attributes;

namespace StoreApplication.Services
{
    [Service]
    public class BCryptPasswordHasher<TUser> : IPasswordHasher<TUser> where TUser : class
    {
        public string HashPassword (TUser user, string password) => BCrypt.Net.BCrypt.HashPassword (password, 12);

        public PasswordVerificationResult VerifyHashedPassword (
            TUser user,
            string hashedPassword,
            string providedPassword
        )
        {
            bool isValid = BCrypt.Net.BCrypt.Verify (providedPassword, hashedPassword);

            if (isValid && BCrypt.Net.BCrypt.PasswordNeedsRehash (hashedPassword, 12))
            {
                return PasswordVerificationResult.SuccessRehashNeeded;
            }

            return isValid
                ? PasswordVerificationResult.Success
                : PasswordVerificationResult.Failed;
        }
    }
}
