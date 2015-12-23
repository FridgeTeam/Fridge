namespace Fridge.Data.Migrations
{
    using Common;
    using Seed;
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;
    using Models;
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using System.IO;
    using Newtonsoft.Json;
    using Models.Social;
    using System.Reflection;
    using System.Web;
    using System.Web.Hosting;

    public sealed class Configuration : DbMigrationsConfiguration<FridgeDbContext>
    {
        private Random random = new Random();
        private string  imagesFilePath = @"E:\11.WepAPI\Fridge\Fridge\Fridge.Data\Seed\Images.json";
        private string recipesFilePath = @"E:\11.WepAPI\Fridge\Fridge\Fridge.Data\Seed\recipes.json";

        public Configuration()
        {
            this.AutomaticMigrationsEnabled = true;
            this.AutomaticMigrationDataLossAllowed = true;
        }

        protected override void Seed(FridgeDbContext context)
        {
            if (context.Categories.Any())
            {
                return;
            }

            List<Category> categories = this.SeedCategories(context);
            List<Unit> units = this.SeedUnits(context);
            List<Ingredient> ingredient = this.SeedIngredients(context);
            List<User> users = this.SeedUsers(context);
            this.SeedRecipes(context);
        }

        private void SeedRecipes(FridgeDbContext context)
        {
          
            string imagesStr = File.ReadAllText(imagesFilePath);
            string recipesStr = File.ReadAllText(recipesFilePath);
            List<ImageModel> images = JsonConvert.DeserializeObject<List<ImageModel>>(imagesStr);
            List<RecipeJsonModel> recipes = JsonConvert.DeserializeObject<List<RecipeJsonModel>>(recipesStr);


            foreach (var recipeObj in recipes)
            {
                Recipe recipe = new Recipe()
                {
                    Name = recipeObj.Title,
                    Image = images[random.Next(0, images.Count)].Image,
                    Description = recipeObj.Description
                };

                int ingredientPosition = 1;
                foreach (var ingredient in recipeObj.Ingredients)
                {
                    IngredientRecipe ingredientRecipe = new IngredientRecipe() { Text = ingredient, Position = ingredientPosition++ };
                    recipe.IngredientRecipes.Add(ingredientRecipe);
                }

                int preparationStep = 1;
                foreach (var instuction in recipeObj.Instructions)
                {
                    PreparationStep step = new PreparationStep() { Text = instuction, Position = preparationStep++ };
                    recipe.PreparationSteps.Add(step);
                }

                foreach (var tagObj in recipeObj.Tags)
                {
                    Tag tag = context.Tags.FirstOrDefault(x => x.Name == tagObj);
                    if (tag == null)
                    {
                        tag = new Tag();
                        tag.Name = tagObj;
                        context.Tags.Add(tag);
                        context.SaveChanges();
                    }

                    recipe.Tags.Add(tag);

                }

                context.Recipes.Add(recipe);
                context.SaveChanges();
            }
        }

        private List<User> SeedUsers(FridgeDbContext context)
        {
            var usernames = new string[] { "admin", "andrei", "joro", "peter", "ceco", "ivan" };

            var users = new List<User>();
            var userStore = new UserStore<User>(context);
            var userManager = new UserManager<User>(userStore);
            userManager.PasswordValidator = new PasswordValidator
            {
                RequiredLength = 2,
                RequireNonLetterOrDigit = false,
                RequireDigit = false,
                RequireLowercase = false,
                RequireUppercase = false,
            };

            foreach (var username in usernames)
            {
                var name = username[0].ToString().ToUpper() + username.Substring(1);

                var user = new User
                {
                    UserName = username,
                    FullName = name,
                    Name = name,
                    Email = username + "@gmail.com",
                    IsActive = true,
                };

                var password = username;
                var userCreateResult = userManager.Create(user, password);
                if (userCreateResult.Succeeded)
                {
                    users.Add(user);
                }
                else
                {
                    throw new Exception(string.Join("; ", userCreateResult.Errors));
                }
            }

            // Create "Administrator" role
            var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(context));
            var roleCreateResult = roleManager.Create(new IdentityRole(GlobalConstants.AdminRole));
            if (!roleCreateResult.Succeeded)
            {
                throw new Exception(string.Join("; ", roleCreateResult.Errors));
            }

            // Add "admin" user to "Administrator" role
            var adminUser = users.First(user => user.UserName == "admin");
            var addAdminRoleResult = userManager.AddToRole(adminUser.Id, GlobalConstants.AdminRole);
            if (!addAdminRoleResult.Succeeded)
            {
                throw new Exception(string.Join("; ", addAdminRoleResult.Errors));
            }

            context.SaveChanges();

            return users;
        }

        private List<Ingredient> SeedIngredients(FridgeDbContext context)
        {
            List<Ingredient> ingredients = new List<Ingredient>();
            List<string> ingredientNames = new List<string>()
            { "tomato", "potato", "onion", "pork", "chicken",
               "milk", "pepper", "butter", "mushrooms", "oil",
               "lime", "garlic", "lemongrass", "galangal", "egg",
               "bread", "ham", "cheese", "sugar", "cream", "carrots",
               "salt", "paper", "eel", "lemon", "orange", "blackberry"
            };

            foreach (var name in ingredientNames)
            {
                Ingredient unit = new Ingredient();
                unit.Name = name;
                ingredients.Add(unit);
                context.Ingredients.Add(unit);
            }

            context.SaveChanges();
            return ingredients;
        }

        private List<Unit> SeedUnits(FridgeDbContext context)
        {
            List<Unit> units = new List<Unit>();
            List<string> unitNames = new List<string>() { "kg", "g", "ml", "l", "cup" };

            foreach (var name in unitNames)
            {
                Unit unit = new Unit();
                unit.Name = name;
                units.Add(unit);
                context.Units.Add(unit);
            }

            context.SaveChanges();
            return units;
        }

        private List<Category> SeedCategories(FridgeDbContext context)
        {

            List<Category> categories = new List<Category>();
            List<string> categoryNames = new List<string>() { "Chicken", "Main Dish", "Salad", "Quick", "Desert", "Healthy" };

            int position = categoryNames.Count;
            foreach (var name in categoryNames)
            {
                Category category = new Category();
                category.Name = name;
                category.Position = position--;
                categories.Add(category);
                context.Categories.Add(category);
            }

            context.SaveChanges();
            return categories;
        }  
    }
}
