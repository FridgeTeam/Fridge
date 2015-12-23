namespace Fridge.Models
{
    using Fridge.Models.Contracts;
    using System.ComponentModel.DataAnnotations;

    public class IngredientRecipe : IPositionable
    {
        public int Id { get; set; }

        public int? IngredientId { get; set; }

        public Ingredient Ingredient { get; set; }

        public int? UnitId { get; set; }

        public Unit Unit { get; set; }
       
        public double? Quantity { get; set; }

        public string Text { get; set; }

        public int Position { get; set; }

        public int RecipeId { get; set; }

        public Recipe Recipe { get; set; }
    }
}