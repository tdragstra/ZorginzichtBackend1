using BC = BCrypt.Net.BCrypt;

namespace WebApplication3.Helpers
{

    public static class LoginHelper
    {
        public static string HashPassword(string plaintextPassword)
        {
            string passwordHash = BC.HashPassword(plaintextPassword);
            
            return passwordHash;
        }

        public static bool MatchPassword (string plaintextPassword, string hashed)
        {
            bool matched = BC.Verify(plaintextPassword, hashed);

            return matched;
        }
    }
}
