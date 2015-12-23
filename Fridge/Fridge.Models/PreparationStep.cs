namespace Fridge.Models
{
    using System.ComponentModel.DataAnnotations;
    using Contracts;

    public class PreparationStep : IPositionable
    {
        public int Id { get; set; }

        [Required]
        public string Text { get; set; }

        public int Position { get; set; }

        public int RecipeId { get; set; }

        public Recipe Recipe { get; set; }
    }
}
