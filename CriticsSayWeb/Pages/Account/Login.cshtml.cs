using CriticSayBusiness;
using CriticsSayWeb.Pages.Model;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Data.SqlClient;
using System.Security.Claims;

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
                // Check login credentials
                if (ValidateCredentials())
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

        private bool ValidateCredentials()
        {
            using (SqlConnection conn = new SqlConnection(SecurityHelper.GetDBConnection()))
            {
                string cmdText = "SELECT Password, PersonId, FirstName, Email, RoleName FROM Person " +
                    " INNER JOIN [Role] ON Person.RoleId=[Role].RoleId WHERE Email=@email";
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
                                // Get the PersonId and use it to update the Person record
                                int personId = reader.GetInt32(1);
                                UpdatePersonLoginTime(personId);

                                // Create a principal
                                string name = reader.GetString(2);
                                string RoleName = reader.GetString(4);

                                // create claims
                                Claim emailClaim = new Claim(ClaimTypes.Email, LoginUser.Email);
                                Claim nameClaim = new Claim(ClaimTypes.Name, name);
                                Claim roleClaim = new Claim(ClaimTypes.Role, RoleName);

                                List<Claim> claims = new List<Claim> { emailClaim, nameClaim, roleClaim };

                                // add list of claims to a claimsIdentity
                                ClaimsIdentity identity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);

                                // add the identity to a claimsPrincipal
                                ClaimsPrincipal principal = new ClaimsPrincipal(identity);

                                // call HttpContext.SigninAsync() method to encrypt the principal
                                HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, principal);


                                return true;
                            }
                            else
                            {
                                return false;
                            }
                        }
                        else
                        {
                            return false;
                        }
                    }
                    else
                    {
                        return false;
                    }
                }
            }

        }

        private void UpdatePersonLoginTime(int personId)
        {
            using(SqlConnection conn = new SqlConnection(SecurityHelper.GetDBConnection()))
            {
                string cmdText = "UPDATE Person SET LastLoginTime=@lastLoginTime WHERE PersonId=@personId";
                SqlCommand cmd = new SqlCommand(cmdText, conn);
                cmd.Parameters.AddWithValue("@lastLoginTime", DateTime.Now);
                cmd.Parameters.AddWithValue("@personId", personId);
                conn.Open();
                cmd.ExecuteNonQuery();
            }
        }
    }
}
