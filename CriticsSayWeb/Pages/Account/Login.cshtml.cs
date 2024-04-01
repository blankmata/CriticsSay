using CriticSayBusiness;
using CriticsSayWeb.Pages.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Data.SqlClient;

namespace CriticsSayWeb.Pages.Account
{
    public class LoginModel : PageModel
    {
        [BindProperty]
        public Login LoginUser { get; set; }
        public void OnGet()
        {
        }

        public ActionResult OnPost()
        {
            if (ModelState.IsValid)
            {
                using (SqlConnection conn = new SqlConnection(SecurityHelper.GetDBConnection()))
                {
                    string cmdText = "SELECT Password FROM Person WHERE Email=@email";
                    using (SqlCommand cmd = new SqlCommand(cmdText, conn))
                    {
                        cmd.Parameters.AddWithValue("@email", LoginUser.Email);
                        conn.Open();
                        SqlDataReader reader = cmd.ExecuteReader();
                        if (reader.HasRows)
                        {
                            reader.Read();
                            if (!reader.IsDBNull(0))
                            {
                                string passwordHash = reader.GetString(0);
                                if (SecurityHelper.VerifyPasswordHash(LoginUser.Password, passwordHash))
                                {
                                    return RedirectToPage("Profile");
                                }
                                else
                                {
                                    ModelState.AddModelError("LoginError", "Invalid Credentials, try again.");
                                    return Page();
                                }
                            }
                            else
                            {
                                return Page();
                            }
                        }
                        else
                        {
                            ModelState.AddModelError("LoginError", "Invalid Credentials, try again.");
                            return Page();
                        }
                    }
                }
            }
            else
            {
                return Page();
            }
        }
    }
}
