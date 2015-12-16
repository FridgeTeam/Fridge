namespace Fridge.Models.Social
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class Comment
    {
        private ICollection<Rating> ratings;

        public Comment()
        {
            this.ratings = new HashSet<Rating>();
        }

        public int Id { get; set; }

        [Required]
        public string Text { get; set; }

        [Required]
        public string UserId { get; set; }

        public User User { get; set; }

        [Required]
        public int RecipeId { get; set; }

        public Recipe Recipe { get; set; }

        public virtual ICollection<Rating> Ratings
        {
            get { return this.ratings; }
            set { this.ratings = value; }
        }
    }
}
