using CriticSayBusiness;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Data.SqlClient;

namespace CriticsSayWeb.Pages.Movies
{
    public class DeleteMovieModel : PageModel
    {
        public IActionResult OnGet(int id)
        {
            using(SqlConnection conn = new SqlConnection(SecurityHelper.GetDBConnection()))
            {
                string cmdText = "DELETE FROM Movie WHERE MovieId=@itemId";
                SqlCommand cmd = new SqlCommand(cmdText, conn);
                cmd.Parameters.AddWithValue("itemId", id);
                conn.Open();
                cmd.ExecuteNonQuery();
                return RedirectToPage("ViewMovies");
            }
        }
    }
}
