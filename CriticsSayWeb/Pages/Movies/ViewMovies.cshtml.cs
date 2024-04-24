using CriticSayBusiness;
using CriticsSayWeb.Pages.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Data.SqlClient;

namespace CriticsSayWeb.Pages.Movies
{
    [BindProperties]
    public class ViewMoviesModel : PageModel
    {

        public List<SelectListItem> Genres { get; set; } = new List<SelectListItem>();

        public List<MovieModel> MovieModel { get; set; } = new List<MovieModel>();

        public int SelectGenreId { get; set; }

        public void OnGet()
        {
            PopulateGenreDDL();
        }

        public void OnPost()
        {
            PopulateMovie(SelectGenreId);
            PopulateGenreDDL();
        }

        private void PopulateMovie(object id)
        {
            using (SqlConnection conn = new SqlConnection(SecurityHelper.GetDBConnection()))
            {
                string cmdText = "SELECT MovieTitle, MovieDescription, ReleaseDate, MoviePoster, MovieId FROM Movie WHERE GenreId=@genreId";
                SqlCommand cmd = new SqlCommand(cmdText, conn);
                cmd.Parameters.AddWithValue("@genreId", id);
                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.HasRows)
                {
                    while(reader.Read())
                    {
                        var item = new MovieModel();
                        item.MovieTitle = reader.GetString(0);
                        item.MovieDescription = reader.GetString(1);
                        item.ReleaseDate = reader.GetDateTime(2);
                        item.MoviePoster = reader.GetString(3);
                        item.MovieId = reader.GetInt32(4);
                        MovieModel.Add(item);
                    }
                }
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
                        if(genre.Value == SelectGenreId.ToString())
                        {
                            genre.Selected = true;
                        }
                        Genres.Add(genre);
                    }
                }
            }
        }
    }
}
