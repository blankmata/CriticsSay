using CriticSayBusiness;
using CriticsSayWeb.Pages.Model;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Data.SqlClient;
using System.Collections.Generic;

namespace CriticsSayWeb.Pages.Movies
{
    [BindProperties]
    [Authorize]
    public class ViewReviewsModel : PageModel
    {
        public List<SelectListItem> Movies { get; set; } = new List<SelectListItem>();

        public List<Review> Reviews { get; set; } = new List<Review>();

        public int SelectedMovieId { get; set; }

        public void OnGet()
        {
            PopulateMovieDDL();
        }

        public void OnPost()
        {
            PopulateReviews(SelectedMovieId);
            PopulateMovieDDL();
        }

        public IActionResult OnPostDelete(int id)
        {
            using (SqlConnection conn = new SqlConnection(SecurityHelper.GetDBConnection()))
            {
                string cmdText = "DELETE FROM Review WHERE ReviewId=@itemId";
                SqlCommand cmd = new SqlCommand(cmdText, conn);
                cmd.Parameters.AddWithValue("itemId", id);
                conn.Open();
                cmd.ExecuteNonQuery();
                return RedirectToPage("ViewReviews");
            }
        }

        private void PopulateReviews(int movieId)
        {
            using (SqlConnection conn = new SqlConnection(SecurityHelper.GetDBConnection()))
            {
                string cmdText = "SELECT ReviewId, ReviewContent, Rating, DatePosted FROM Review WHERE MovieId=@movieId";
                SqlCommand cmd = new SqlCommand(cmdText, conn);
                cmd.Parameters.AddWithValue("@movieId", movieId);
                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        var review = new Review();
                        review.ReviewId = reader.GetInt32(0);
                        review.ReviewContent = reader.GetString(1);
                        review.Rating = reader.GetInt32(2);
                        review.DatePosted = reader.GetDateTime(3);
                        Reviews.Add(review);
                    }
                }
            }
        }

        private void PopulateMovieDDL()
        {
            using (SqlConnection conn = new SqlConnection(SecurityHelper.GetDBConnection()))
            {
                string cmdText = "SELECT MovieId, MovieTitle FROM Movie ORDER BY MovieTitle";
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
                        if (movie.Value == SelectedMovieId.ToString())
                        {
                            movie.Selected = true;
                        }
                        Movies.Add(movie);
                    }
                }
            }
        }
    }
}
