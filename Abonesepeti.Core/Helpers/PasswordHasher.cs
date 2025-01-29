namespace Abonesepeti.Core.Helpers
{
    public static class PasswordHasher
    {
        private const int WorkFactor = 12;

        public static string HashPassword(string password) =>
            BCrypt.Net.BCrypt.HashPassword(password, WorkFactor);

        public static bool VerifyPassword(string password, string hashedPassword) =>
            BCrypt.Net.BCrypt.Verify(password, hashedPassword);
    }
}
