namespace Fridge.Models
{
    using Fridge.Models.Contracts;
    using System.ComponentModel.DataAnnotations;

    public class Ingredient : IPositionable
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public Unit Unit { get; set; }

        [Required]
        public double Quantity { get; set; }

        public int Position { get; set; }

        public int RecipeId { get; set; }

        public Recipe Recipe { get; set; }
    }
}