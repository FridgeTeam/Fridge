using System.Collections.Generic;

namespace Fridge.Models.Social
{
    public class Tag
    {
        private ICollection<Recipe> recipes;

        public Tag()
        {
            this.recipes = new HashSet<Recipe>();
        }

        public int Id { get; set; }

        public string Name { get; set; }

        public int? TagGroupId { get; set; }

        public TagGroup TagGroup { get; set; }

        public virtual ICollection<Recipe> Recipes
        {
            get { return this.recipes; }
            set { this.recipes = value; }
        }
    }
}
