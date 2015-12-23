using System.Collections.Generic;

namespace Fridge.Models
{
    public class Ingredient
    {
        private ICollection<IngredientRecipe> ingredientRecipes;

        public Ingredient()
        {
            this.ingredientRecipes = new HashSet<IngredientRecipe>();
        }

        public int Id { get; set; }

        public string Name { get; set; }

        public virtual ICollection<IngredientRecipe> IngredientRecipes
        {
            get { return this.ingredientRecipes; }
            set { this.ingredientRecipes = value; }
        }
    }
}