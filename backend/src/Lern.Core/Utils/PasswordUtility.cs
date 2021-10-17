namespace Lern.Core.Utils
{
    public static class PasswordUtility
    {
        public static string GetEncryptedPassword(string password)
        {
            return BCrypt.Net.BCrypt.EnhancedHashPassword(password);
        }

        public static bool VerifyPassword(string plainPassword, string hashedPassword)
        {
            return BCrypt.Net.BCrypt.EnhancedVerify(plainPassword, hashedPassword);
        }
    }
}