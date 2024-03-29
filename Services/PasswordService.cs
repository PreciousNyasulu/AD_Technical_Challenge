using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using NaLib.Models;

namespace NaLib.Services
{
    public class PasswordService
    {
        private readonly IPasswordHasher<Users> _passwordHasher;

        public PasswordService()
        { 
            _passwordHasher = new PasswordHasher<Users>(new OptionsWrapper<PasswordHasherOptions>(
                new PasswordHasherOptions
                {
                    CompatibilityMode = PasswordHasherCompatibilityMode.IdentityV3,
                }
            ));
        }

        public string HashPassword(string password)
        {
            // Generate a random salt
            string salt = Guid.NewGuid().ToString();

            // Combine password and salt, then hash
            string hashedPassword = _passwordHasher.HashPassword(null, salt + password);

            // Store both the hashed password and the salt in the database
            string storedPassword = salt + hashedPassword;

            return storedPassword;
        }

        public bool VerifyPassword(string storedPassword, string providedPassword)
        {
            // Extract salt and hashed password from the stored value
            string salt = storedPassword.Substring(0, 36); // Assuming a standard GUID length
            string hashedPassword = storedPassword.Substring(36);

            // Combine provided password and salt, then hash
            var passwordVerificationResult = _passwordHasher.VerifyHashedPassword(null, hashedPassword, salt + providedPassword);

            // Check the result
            return passwordVerificationResult == PasswordVerificationResult.Success;
        }
    }
}
