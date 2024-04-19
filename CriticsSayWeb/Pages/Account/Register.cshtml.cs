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
                // Insert Data into Database
                // 1. Create a datbase connection string
                //string connString = "Server=(localdb)\\MSSQLLocalDB;Database=CriticSay;Trusted_Connection=true;";  
                SqlConnection conn = new SqlConnection(SecurityHelper.GetDBConnection());
                // 2. Create an insert command
                string cmdtext = "INSERT INTO Person(FirstName, LastName, Email, Password, LastLoginTime, RoleId)" +
                    "VALUES(@firstName, @lastName, @email, @password, @lastLoginTime, 2)";
                SqlCommand cmd = new SqlCommand(cmdtext, conn);
                cmd.Parameters.AddWithValue("@firstName", NewPerson.FirstName);
                cmd.Parameters.AddWithValue("@lastName", NewPerson.LastName);
                cmd.Parameters.AddWithValue("@email", NewPerson.Email);
                cmd.Parameters.AddWithValue("@password", SecurityHelper.GeneratePasswordHash(NewPerson.Password));
                cmd.Parameters.AddWithValue("@lastLoginTime", DateTime.Now.ToString());
                // 3. Open the database
                conn.Open();
                // 4. Execute the command
                cmd.ExecuteNonQuery();
                // 5. Close the database
                conn.Close();
                return RedirectToPage("Login");
            }
            else
            {
                return Page();
            }
        }
    }
}
