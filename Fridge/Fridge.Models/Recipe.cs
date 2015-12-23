namespace Fridge.Models
{   
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    using Social;

    public class Recipe
    {
        private ICollection<IngredientRecipe> ingredientRecipes;
        private ICollection<PreparationStep> preparationSteps;
        private ICollection<User> preparedBy;
        private ICollection<Rating> ratings;
        private ICollection<Comment> comments;
        private ICollection<Tag> tags;

        public Recipe()
        {
            this.ingredientRecipes = new HashSet<IngredientRecipe>();
            this.preparationSteps = new HashSet<PreparationStep>();
            this.preparedBy = new HashSet<User>();
            this.ratings = new HashSet<Rating>();
            this.comments = new HashSet<Comment>();
            this.tags = new HashSet<Tag>();
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

        public virtual ICollection<IngredientRecipe> IngredientRecipes
        {
            get { return this.ingredientRecipes; }
            set { this.ingredientRecipes = value; }
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

        public virtual ICollection<Tag> Tags
        {
            get { return this.tags; }
            set { this.tags = value; }
        }
    }
}
