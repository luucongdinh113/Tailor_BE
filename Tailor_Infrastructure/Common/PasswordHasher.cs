using System.Security.Cryptography;

namespace Tailor_Infrastructure.Common
{
    public class PasswordHasher
    {
        public static string HashPassword(string password)
        {
            // Generate a random salt
            byte[] salt;
#pragma warning disable SYSLIB0023 // Type or member is obsolete
            new RNGCryptoServiceProvider().GetBytes(salt = new byte[16]);
#pragma warning restore SYSLIB0023 // Type or member is obsolete

            // Create a password hash
            var pbkdf2 = new Rfc2898DeriveBytes(password, salt, 10000, HashAlgorithmName.SHA256);
            byte[] hash = pbkdf2.GetBytes(20); // 20 is the size of the hash

            // Combine the salt and hash
            byte[] hashBytes = new byte[36];
            Array.Copy(salt, 0, hashBytes, 0, 16);
            Array.Copy(hash, 0, hashBytes, 16, 20);

            // Convert the byte array to a base64-encoded string
            string hashedPassword = Convert.ToBase64String(hashBytes);

            return hashedPassword;
        }

        public static bool VerifyPassword(string savedHashedPassword, string providedPassword)
        {
            // Extract the salt and hash from the saved password
            byte[] hashBytes = Convert.FromBase64String(savedHashedPassword);
            byte[] salt = new byte[16];
            Array.Copy(hashBytes, 0, salt, 0, 16);
            byte[] hash = new byte[20];
            Array.Copy(hashBytes, 16, hash, 0, 20);

            // Compute the hash of the provided password with the saved salt
            var pbkdf2 = new Rfc2898DeriveBytes(providedPassword, salt, 10000, HashAlgorithmName.SHA256);
            byte[] testHash = pbkdf2.GetBytes(20);

            // Compare the computed hash with the saved hash
            for (int i = 0; i < 20; i++)
            {
                if (hash[i] != testHash[i])
                    return false;
            }

            return true;
        }
    }
}
