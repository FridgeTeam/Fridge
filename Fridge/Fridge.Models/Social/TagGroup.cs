using System.Collections.Generic;

namespace Fridge.Models.Social
{
    public class TagGroup
    {        
        private ICollection<Tag> tags;

        public TagGroup()
        {
            this.tags = new HashSet<Tag>(); 
        }

        public int Id { get; set; }

        public string Name { get; set; }

        public virtual ICollection<Tag> Tags
        {
            get { return this.tags; }
            set { this.tags = value; }
        }
    }
}
