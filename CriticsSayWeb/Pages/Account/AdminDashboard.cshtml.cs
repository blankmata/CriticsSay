using CriticSayBusiness;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Data.SqlClient;
using System.Collections.Generic;

namespace CriticsSayWeb.Pages.Account
{
    public class AdminDashboardModel : PageModel
    {
        public List<UserModel> Users { get; set; }

        public void OnGet()
        {
            // Fetch users from the database
            Users = FetchUsers();
        }

        private List<UserModel> FetchUsers()
        {
            var users = new List<UserModel>();

            // Fetch users logic similar to how movies are fetched
            using (SqlConnection conn = new SqlConnection(SecurityHelper.GetDBConnection()))
            {
                string cmdText = "SELECT Email, LastLoginTime FROM Person WHERE RoleId != 1"; // Assuming Admin's RoleId is 1
                SqlCommand cmd = new SqlCommand(cmdText, conn);
                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    users.Add(new UserModel
                    {
                        Email = reader.GetString(0),
                        LastLoginTime = reader.GetDateTime(1)
                    });
                }
            }

            return users;
        }
    }

    public class UserModel
    {
        public string Username { get; set; }
        public string Email { get; set; }
        public DateTime LastLoginTime { get; set; }
    }
}
