namespace Fridge.Models
{
    using Social;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class Recipe
    {
        private ICollection<Ingredient> ingredients;
        private ICollection<PreparationStep> preparationSteps;
        private ICollection<User> preparedBy;
        private ICollection<Rating> ratings;
        private ICollection<Comment> comments;

        public Recipe()
        {
            this.ingredients = new HashSet<Ingredient>();
            this.preparationSteps = new HashSet<PreparationStep>();
            this.preparedBy = new HashSet<User>();
            this.ratings = new HashSet<Rating>();
            this.comments = new HashSet<Comment>();
        }

        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        public string Description { get; set; }       

        public string Image { get; set; }

        public TimeSpan PreparationTime { get; set; }

        public TimeSpan CookingTime { get; set; }

        public TimeSpan TotalTime { get; set; }

        public int Servings { get; set; }

        public string UserId { get; set; }

        public User PostedBy { get; set; }

        public virtual ICollection<Ingredient> Ingredients
        {
            get { return this.ingredients; }
            set { this.ingredients = value; }
        }

        public virtual ICollection<PreparationStep> PreparationSteps
        {
            get { return this.preparationSteps; }
            set { this.preparationSteps = value; }
        }

        public virtual ICollection<User> PreparedBy
        {
            get { return this.preparedBy; }
            set { this.preparedBy = value; }
        }

        public virtual ICollection<Rating> Ratings
        {
            get { return this.ratings; }
            set { this.ratings = value; }
        }

        public virtual ICollection<Comment> Comments
        {
            get { return this.comments; }
            set { this.comments = value; }
        }
    }
}
