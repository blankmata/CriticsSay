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
    public class EditReviewModel : PageModel
    {
        public Review ReviewModel { get; set; } = new Review();
        public List<SelectListItem> Ratings { get; set; } = new List<SelectListItem>();

        public void OnGet(int id)
        {
            PopulateReview(id);
        }

        public IActionResult OnPost(int id)
        {
            if (ModelState.IsValid)
            {
                using (SqlConnection conn = new SqlConnection(SecurityHelper.GetDBConnection()))
                {
                    string cmdText = "UPDATE Review SET ReviewContent=@reviewContent, Rating=@rating, DatePosted=@datePosted " +
                        "WHERE ReviewId=@itemId";
                    SqlCommand cmd = new SqlCommand(cmdText, conn);
                    cmd.Parameters.AddWithValue("@reviewContent", ReviewModel.ReviewContent);
                    cmd.Parameters.AddWithValue("@rating", ReviewModel.Rating);
                    cmd.Parameters.AddWithValue("@datePosted", ReviewModel.DatePosted);
                    cmd.Parameters.AddWithValue("@itemId", id);
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

        private void PopulateReview(int id)
        {
            using (SqlConnection conn = new SqlConnection(SecurityHelper.GetDBConnection()))
            {
                string cmdText = "SELECT ReviewId, ReviewContent, Rating, DatePosted FROM Review WHERE ReviewId=@reviewId";
                SqlCommand cmd = new SqlCommand(cmdText, conn);
                cmd.Parameters.AddWithValue("@reviewId", id);
                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.HasRows)
                {
                    reader.Read();
                    ReviewModel.ReviewId = id;
                    ReviewModel.ReviewContent = reader.GetString(1);
                    ReviewModel.Rating = reader.GetInt32(2);
                    ReviewModel.DatePosted = reader.GetDateTime(3);
                }
            }
        }
    }
}
