using System.ComponentModel.DataAnnotations;


namespace CriticsSayWeb.Pages.Model
{
    public class MovieModel
    {
        public int MovieId { get; set; }
        [Required(ErrorMessage = "Please enter a movie title")]
        [StringLength(100, ErrorMessage = "The movie title must not exceed 100 characters")]
        [Display(Name= "Movie Title")]
        public string MovieTitle { get; set; }
        [Display(Name = "Description")]
        public string MovieDescription { get; set;}
        [DataType(DataType.Date)]
        [Display(Name = "Release Date")] 
        public DateTime ReleaseDate { get; set; }
        [Display(Name = "Movie Poster URL")]
        public string MoviePoster { get; set; }
        [Display(Name = "Genre")]
        public int GenreId { get; set; }
        
    }
}
