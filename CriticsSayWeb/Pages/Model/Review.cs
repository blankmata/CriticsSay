using System.ComponentModel.DataAnnotations;

namespace CriticsSayWeb.Pages.Model
{
    public class Review
    {
        public int ReviewId { get; set; }
        [Display(Name = "My review:")]
        public string ReviewContent { get; set; }
        public int Rating { get; set; }
        [Display(Name = "Watched on....")]
        public DateTime DatePosted { get; set; }
        [Display(Name = "Movie Title:")]
        public int MovieId { get; set; } 

    }
}
