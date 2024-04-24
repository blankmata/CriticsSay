using CriticSayBusiness;
using CriticsSayWeb.Pages.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Data.SqlClient;

namespace CriticsSayWeb.Pages.Movies
{
    [BindProperties]
    public class EditMovieModel : PageModel
    {
        public MovieModel MovieModel { get; set; } = new MovieModel();
        public List<SelectListItem> Genres { get; set; } = new List<SelectListItem>();

        public void OnGet(int id)
        {
            PopulateMovie(id);
            PopulateGenreDDL();
        }

        public IActionResult OnPost(int id)
        {
            if (ModelState.IsValid)
            {
                using (SqlConnection conn = new SqlConnection(SecurityHelper.GetDBConnection()))
                {
                    string cmdText = "UPDATE Movie SET MovieTitle=@movieTitle, MovieDescription=@movieDescription, ReleaseDate=@releaseDate, MoviePoster=@moviePoster, GenreId=@genreId " +
                        "WHERE MovieId=@itemId";
                    SqlCommand cmd = new SqlCommand(cmdText, conn);
                    cmd.Parameters.AddWithValue("@movieTitle", MovieModel.MovieTitle);
                    cmd.Parameters.AddWithValue("@movieDescription", MovieModel.MovieDescription);
                    cmd.Parameters.AddWithValue("@releaseDate", MovieModel.ReleaseDate);
                    cmd.Parameters.AddWithValue("@moviePoster", MovieModel.MoviePoster);
                    cmd.Parameters.AddWithValue("@genreId", MovieModel.GenreId);
                    cmd.Parameters.AddWithValue("@itemId", id);
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


        private void PopulateGenreDDL()
        {
            using (SqlConnection conn = new SqlConnection(SecurityHelper.GetDBConnection()))
            {
                string cmdText = "SELECT GenreId, GenreName FROM Genre ORDER BY GenreName";
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
                        if (genre.Value == MovieModel.GenreId.ToString())
                        {
                            genre.Selected = true;
                        }
                        Genres.Add(genre);
                    }
                }
                reader.Close(); // Close the reader


        }
    }

        private void PopulateMovie(int id)
        {
            using(SqlConnection conn = new SqlConnection(SecurityHelper.GetDBConnection()))
            {
                string cmdText = "SELECT MovieId, MovieTitle, MovieDescription, ReleaseDate, MoviePoster, GenreId FROM Movie WHERE MovieId=@movieId";
                SqlCommand cmd = new SqlCommand(cmdText, conn);
                cmd.Parameters.AddWithValue("@movieId", id);
                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.HasRows)
                {
                    reader.Read();
                    MovieModel.MovieId = id;
                    MovieModel.MovieTitle = reader.GetString(1);
                    MovieModel.MovieDescription = reader.GetString(2);
                    MovieModel.ReleaseDate = reader.GetDateTime(3);
                    MovieModel.MoviePoster = reader.GetString(4); // Assuming MoviePoster is the URL
                    MovieModel.GenreId = reader.GetInt32(5);
                    
                }
              
            }
        }
    }
}
