namespace Aplicacion.Extension
{
    public static class Hashing
    {
        public static string Hash(this string password)
        {
            return BCrypt.Net.BCrypt.HashPassword(password);
        }

        public static bool VerifyHash(this string password, string passwordHash)
        {
            return BCrypt.Net.BCrypt.Verify(password, passwordHash);
        }
    }
}
