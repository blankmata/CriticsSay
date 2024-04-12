using CriticsSayWeb.Pages.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using CriticsSayWeb.Pages.Account;
using Microsoft.Data.SqlClient;
using CriticSayBusiness;

namespace CriticsSayWeb.Pages.Account
{
    public class RegisterModel : PageModel
    {
        [BindProperty]
        public Person NewPerson { get; set; }

        public void OnGet()
        {

        }

        public ActionResult OnPost()
        {

            if (ModelState.IsValid)
            {
                // make sure the email does not exist before registering the user
                if (EmailDNE(NewPerson.Email))  //EmailDNE = email doesn't exist
                {
                    RegisterUser();
                    return RedirectToPage("Login");
                }
                else
                {
                    ModelState.AddModelError("RegisterError", "This email is already taken. Try a different one");
                    return Page();
                }


                // Insert Data into Database
                // 1. Create a datbase connection string
                //string connString = "Server=(localdb)\\MSSQLLocalDB;Database=CriticSay;Trusted_Connection=true;";  
                SqlConnection conn = new SqlConnection(SecurityHelper.GetDBConnection());
                // 2. Create an insert command
      
            }
            else
            {
                return Page();
            }
        }

        private void RegisterUser()
        {
            using (SqlConnection conn = new SqlConnection(SecurityHelper.GetDBConnection()))
            {
                string cmdtext = "INSERT INTO Person(FirstName, LastName, Email, Password, LastLoginTime, RoleId)" +
                    "VALUES(@firstName, @lastName, @email, @password, @lastLoginTime, 2)";
                SqlCommand cmd = new SqlCommand(cmdtext, conn);
                cmd.Parameters.AddWithValue("@firstName", NewPerson.FirstName);
                cmd.Parameters.AddWithValue("@lastName", NewPerson.LastName);
                cmd.Parameters.AddWithValue("@email", NewPerson.Email);
                cmd.Parameters.AddWithValue("@password", SecurityHelper.GeneratePasswordHash(NewPerson.Password));
                cmd.Parameters.AddWithValue("@lastLoginTime", DateTime.Now.ToString());
                //cmd.Parameters.AddWithValue("@roleId", NewPerson.RoleId);
                conn.Open(); 
                cmd.ExecuteNonQuery();
            }
        }

        private bool EmailDNE(string email)
        {
            using(SqlConnection conn = new SqlConnection(SecurityHelper.GetDBConnection()))
            {
                string cmdText = "SELECT * FROM Person WHERE Email=@email";
                SqlCommand cmd = new SqlCommand(cmdText, conn);
                cmd.Parameters.AddWithValue("@email", email);
                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.HasRows)
                {
                    return false;
                }
                else
                {
                    return true;
                }
            }
        }
    }
}
