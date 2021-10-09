namespace Lern.Core.Utils
{
    public static class PasswordUtility
    {
        public static string GetEncryptedPassword(string password)
            => BCrypt.Net.BCrypt.EnhancedHashPassword(password);

        public static bool DecryptPassword(string plainPassword, string hashedPassword)
            => BCrypt.Net.BCrypt.EnhancedVerify(plainPassword, hashedPassword);
    }
}