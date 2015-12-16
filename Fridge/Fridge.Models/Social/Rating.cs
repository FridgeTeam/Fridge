namespace Fridge.Models.Social
{
    using System.ComponentModel.DataAnnotations;

    public class Rating
    {
        public int Id { get; set; }

        [Range(1, 5)]
        [Required]
        public int Stars { get; set; }

        [Required]
        public string UserId { get; set; }

        public User User { get; set; }

        public int RecipeId { get; set; }

        public Recipe Recipe { get; set; }

        public int CommentId { get; set; }

        public Comment Comment { get; set; }
    }
}
