using CriticSayBusiness;
using CriticsSayWeb.Pages.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Data.SqlClient;

namespace CriticsSayWeb.Pages.Movies
{
    [BindProperties]
    public class AddMovieModel : PageModel
    {

        public MovieModel newMovieModel { get; set; } = new MovieModel();
        public List<SelectListItem> Genres { get; set; } = new List<SelectListItem>();
        public void OnGet()
        {
            PopulateGenresDDL();
        }

        public IActionResult OnPost()
        {
            if (ModelState.IsValid) { 
                using(SqlConnection conn = new SqlConnection(SecurityHelper.GetDBConnection()))
                {
                    string cmdText = "INSERT INTO Movie( MovieTitle, MovieDescription, ReleaseDate, MoviePoster, GenreId)" +
                        "VALUES (@movieTitle, @movieDescription, @releaseDate, @moviePoster, @genreId)";
                    SqlCommand cmd = new SqlCommand(cmdText, conn);
                    cmd.Parameters.AddWithValue("@movieTitle", newMovieModel.MovieTitle);
                    cmd.Parameters.AddWithValue("@movieDescription", newMovieModel.MovieDescription);
                    cmd.Parameters.AddWithValue("@releaseDate", newMovieModel.ReleaseDate);
                    cmd.Parameters.AddWithValue("@moviePoster", newMovieModel.MoviePoster);
                    cmd.Parameters.AddWithValue("@genreId", newMovieModel.GenreId);
                    conn.Open();
                    cmd.ExecuteNonQuery();
                }
                return RedirectToPage("ViewMovies");
            }
            else
            {
                return Page();
            }
        }


        private void PopulateGenresDDL()
        {
            using (SqlConnection conn = new SqlConnection(SecurityHelper.GetDBConnection()))
            {
                string cmdText = "SELECT GenreId, GenreName FROM Genre";
                SqlCommand cmd = new SqlCommand(cmdText, conn);
                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read()) // Loop through each row
                    {
                        var genre = new SelectListItem();
                        genre.Value = reader.GetInt32(0).ToString();
                        genre.Text = reader.GetString(1);
                        Genres.Add(genre);
                    }
                }
            }
        }
    }
    
}
