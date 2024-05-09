using CriticSayBusiness;
using CriticsSayWeb.Pages.Model;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Data.SqlClient;
using System.Security.Claims;

namespace CriticsSayWeb.Pages.Account
{
    [Authorize]
    public class ProfileModel : PageModel
    {
        [BindProperty]
        public UserProfile profile { get; set; } = new UserProfile();
        public void OnGet()
        {
            PopulateProfile();
        }

        private void PopulateProfile()
        {
            // query the person table to populate "profile" object
            string email = HttpContext.User.FindFirstValue(ClaimTypes.Email);
            using (SqlConnection conn = new SqlConnection(SecurityHelper.GetDBConnection()))
            {
                string cmdText = "SELECT FirstName, LastName, Email, LastLoginTime FROM Person WHERE Email=@email";
                SqlCommand cmd = new SqlCommand(cmdText, conn);
                cmd.Parameters.AddWithValue("email", email);    
                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                if(reader.HasRows)
                {
                    reader.Read();
                    profile.FirstName = reader.GetString(0);
                    profile.LastName = reader.GetString(1);
                    profile.Email = reader.GetString(2);

                }
            }


        }
        public IActionResult OnPostUpdateProfile()
        {
            if (ModelState.IsValid)
            {
                string email = HttpContext.User.FindFirstValue(ClaimTypes.Email);
                using (SqlConnection conn = new SqlConnection(SecurityHelper.GetDBConnection()))
                {
                    string cmdText = "UPDATE Person SET FirstName=@firstName, LastName=@lastName " +
                        "WHERE Email=@email";
                    SqlCommand cmd = new SqlCommand(cmdText, conn);
                    cmd.Parameters.AddWithValue("@firstName", profile.FirstName);
                    cmd.Parameters.AddWithValue("@lastName", profile.LastName);
                    cmd.Parameters.AddWithValue("@email", email); // Using email from claim directly
                    conn.Open();
                    cmd.ExecuteNonQuery();
                }
                PopulateProfile(); // Refresh profile after update
                return RedirectToPage("Profile");
            }
            else
            {
                // ModelState is not valid, return the page with validation errors
                return Page();
            }
        }


    }
}
