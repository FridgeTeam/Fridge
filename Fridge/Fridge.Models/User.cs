namespace Fridge.Models
{
    using Social;
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Security.Claims;
    using System.Threading.Tasks;

    // You can add profile data for the user by adding more properties to your ApplicationUser class, please visit http://go.microsoft.com/fwlink/?LinkID=317594 to learn more.
    public class User : IdentityUser
    {
        private ICollection<Recipe> preparedRecipes;
        private ICollection<Comment> comments;
        private ICollection<Rating> ratings;

        public User()
        {
            this.preparedRecipes = new HashSet<Recipe>();
            this.comments = new HashSet<Comment>();
            this.ratings = new HashSet<Rating>();
        }

        [Required]
        public string Name { get; set; }

        public bool IsActive { get; set; }

        public string FullName { get; set; }

        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<User> manager, string authenticationType)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, authenticationType);
            // Add custom user claims here
            return userIdentity;
        }

        public virtual ICollection<Recipe> PreparedRecipes
        {
            get { return this.preparedRecipes; }
            set { this.preparedRecipes = value; }
        }

        public virtual ICollection<Comment> Comments
        {
            get { return this.comments; }
            set { this.comments = value; }
        }

        public virtual ICollection<Rating> Ratings
        {
            get { return this.ratings; }
            set { this.ratings = value; }
        }
    }
}
