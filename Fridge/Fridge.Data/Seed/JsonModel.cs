namespace Fridge.Data.Seed
{
    using System.Collections.Generic;

    class RecipeJsonModel
    {
        public string Title { get; set; }

        public string Description { get; set; }

        public List<string> Ingredients { get; set; }

        public List<string> Instructions { get; set; }

        public List<string> Tags { get; set; }
    }

    class ImageModel
    {
        public string Image { get; set; }
    }
}
