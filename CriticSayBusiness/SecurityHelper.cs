using BCrypt.Net;
namespace CriticSayBusiness
{
    public class SecurityHelper
    {
        public static string GeneratePasswordHash(string password)
        {
            return BCrypt.Net.BCrypt.EnhancedHashPassword(password, 13);    
        }

        public static bool VerifyPasswordHash(string password, string passwordHash)
        {
            return BCrypt.Net.BCrypt.EnhancedVerify(password, passwordHash);
        }

        public static string GetDBConnection()
        {
            string connString = "Server=(localdb)\\MSSQLLocalDB;Database=CriticSay;Trusted_Connection=true;";
            return connString;
        }   
    }
}
