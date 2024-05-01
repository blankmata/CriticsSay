using CriticSayBusiness;
using CriticsSayWeb.Pages.Model;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Data.SqlClient;

namespace CriticsSayWeb.Pages.Reviews
{
    [BindProperties]
    [Authorize]
    public class AddReviewModel : PageModel
    {
        public Review newReviewModel { get; set; } = new Review();
        public List<SelectListItem> Ratings { get; set; } = new List<SelectListItem>();
        public List<SelectListItem> Movies { get; set; } = new List<SelectListItem>();


        public IActionResult OnGet()
        {
            PopulateRatingsDDL();
            PopulateMoviesDDL();

            return Page();
        }

        private void PopulateMoviesDDL()
        {
            using (SqlConnection conn = new SqlConnection(SecurityHelper.GetDBConnection()))
            {
                string cmdText = "SELECT MovieId, MovieTitle FROM Movie";
                SqlCommand cmd = new SqlCommand(cmdText, conn);
                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        var movie = new SelectListItem();
                        movie.Value = reader.GetInt32(0).ToString();
                        movie.Text = reader.GetString(1);
                        Movies.Add(movie);
                    }
                }
            }
        }

        public IActionResult OnPost()
        {
            if (ModelState.IsValid)
            {
                using (SqlConnection conn = new SqlConnection(SecurityHelper.GetDBConnection()))
                {
                    string cmdText = "INSERT INTO Review(ReviewContent, Rating, DatePosted, MovieId) " +
                        "VALUES (@reviewContent, @rating, @datePosted, @movieId)";
                    SqlCommand cmd = new SqlCommand(cmdText, conn);
                    cmd.Parameters.AddWithValue("@reviewContent", newReviewModel.ReviewContent);
                    cmd.Parameters.AddWithValue("@rating", newReviewModel.Rating);
                    cmd.Parameters.AddWithValue("@datePosted", newReviewModel.DatePosted);
                    cmd.Parameters.AddWithValue("@movieId", newReviewModel.MovieId);
                    conn.Open();
                    cmd.ExecuteNonQuery();
                }
                return RedirectToPage("ViewReviews");
            }
            else
            {
                return Page();
            }
        }

        private void PopulateRatingsDDL()
        {
            // Assuming ratings are from 1 to 10
            for (int i = 1; i <= 5; i++)
            {
                Ratings.Add(new SelectListItem { Value = i.ToString(), Text = i.ToString() });
            }
        }
    }
}
