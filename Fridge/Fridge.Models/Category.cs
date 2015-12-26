namespace Fridge.Models
{
    using Fridge.Models.Contracts;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class Category : IPositionable
    {
        private ICollection<Recipe> recipes;

        public Category()
        {
            this.recipes = new HashSet<Recipe>();
        }

        public int Id { get; set; }

        [Required]
        public string Name { get; set; }
       
        public int Position { get; set; }

        public virtual ICollection<Recipe> Recipes
        {
            get { return this.recipes; }
            set { this.recipes = value; }
        }
    }
}
