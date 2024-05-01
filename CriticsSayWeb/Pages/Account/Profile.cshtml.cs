using CriticSayBusiness;
using CriticsSayWeb.Pages.Model;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Data.SqlClient;
using System;
using System.Security.Claims;

namespace CriticsSayWeb.Pages.Account
{
    [Authorize]
    public class ProfileModel : PageModel
    {
        [BindProperty]
        public UserProfile Profile { get; set; } = new UserProfile();

        public IActionResult OnGet()
        {
            PopulateProfile();
            return Page();
        }

        public IActionResult OnPostUpdateProfile()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            UpdateProfile();
            PopulateProfile(); // Refresh the profile after update
            return RedirectToPage();
        }

        private void PopulateProfile()
        {
            // Query the person table to populate "Profile" object
            string email = HttpContext.User.FindFirstValue(ClaimTypes.Email);
            using (SqlConnection conn = new SqlConnection(SecurityHelper.GetDBConnection()))
            {
                string cmdText = "SELECT FirstName, LastName, Email, LastLoginTime FROM Person WHERE Email=@email";
                SqlCommand cmd = new SqlCommand(cmdText, conn);
                cmd.Parameters.AddWithValue("email", email);
                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.HasRows)
                {
                    reader.Read();
                    Profile.FirstName = reader.GetString(0);
                    Profile.LastName = reader.GetString(1);
                    Profile.Email = reader.GetString(2);
                }
            }
        }

        private void UpdateProfile()
        {
            // Update the person table with new profile information
            string email = HttpContext.User.FindFirstValue(ClaimTypes.Email);
            using (SqlConnection conn = new SqlConnection(SecurityHelper.GetDBConnection()))
            {
                string cmdText = "UPDATE Person SET FirstName=@firstName, LastName=@lastName, Email=@newEmail WHERE Email=@email";
                SqlCommand cmd = new SqlCommand(cmdText, conn);
                cmd.Parameters.AddWithValue("firstName", Profile.FirstName);
                cmd.Parameters.AddWithValue("lastName", Profile.LastName);
                cmd.Parameters.AddWithValue("newEmail", Profile.Email);
                cmd.Parameters.AddWithValue("email", email);
                conn.Open();
                int rowsAffected = cmd.ExecuteNonQuery();
                if (rowsAffected == 0)
                {
                    throw new InvalidOperationException("Failed to update profile.");
                }
            }
        }
    }
}
