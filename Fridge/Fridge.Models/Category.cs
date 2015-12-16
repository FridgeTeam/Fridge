namespace Fridge.Models
{
    using Fridge.Models.Contracts;
    using System.ComponentModel.DataAnnotations;

    public class Category : IPositionable
    {
        public int Id { get; set; }

        [Required]
        public int Name { get; set; }
       
        public int Position { get; set; }
    }
}
