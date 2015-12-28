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

    public sealed class Configuration : DbMigrationsConfiguration<FridgeDbContext>
    {
        private Random random = new Random();
        //private string imagesFilePath = @"C:\Users\ivzb\Desktop\Fridge\Fridge\Fridge.Data\Seed\Images.json";
        //private string recipesFilePath = @"C:\Users\ivzb\Desktop\Fridge\Fridge\Fridge.Data\Seed\recipes.json";
        private string imagesFilePath = @"E:\11.WepAPI\Fridge\Fridge\Fridge.Data\Seed\Images.json";
        private string recipesFilePath = @"E:\11.WepAPI\Fridge\Fridge\Fridge.Data\Seed\recipes.json";
        private string peopleImageFilePath = @"E:\11.WepAPI\Fridge\Fridge\Fridge.Data\Seed\People.json";

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
            List<Comment> comments = this.GetComments(users);
            List<Rating> ratings = this.GetRatings(users);
            this.SeedRecipes(context, ingredient, users, categories, comments, ratings);
        }

        private List<Rating> GetRatings(List<User> users)
        {
            List<Rating> ratings = new List<Rating>();
            for (int i = 0; i < 100; i++)
            {
                Rating rating = new Rating()
                {
                    Stars = random.Next(1, 6),
                    UserId = users[random.Next(users.Count)].Id
                };
                ratings.Add(rating);
            }
            return ratings;
        }

        private List<Comment> GetComments(List<User> users)
        {
            List<string> commentText = new List<string>()
            {
                "This is a fool proof method for making the best medium rare prime rib. Your seasonings can be changed according to your preference, but what's listed works perfectly.",
                "Disable your smoke detectors if you prepare your roast this way! My oven cooled down much faster than two hours I feel because we had to open the windows.",
                "Absolutely, the easiest way to make perfect prime rib every time. But do not be tempted to open up the oven door until time is up.",
                "I know this is a culinary no-no, but we don't link pink meat, so while I partially use this method, I didn't do it exactly as Chef John suggests.",
                "Prime rib was perfect, juicy and perfectly pink. Followed the recipe exactly with a 4 lb prime rib. Loved it! Love the video to really get a good sense of how to apply the butter and herbs.",
                "OMG .. I have never been able to do Prime Rib correctly and I finally cracked it using this recipe. Thank you thank you thank you! The only alteration I made was to do the math."
            };

            List<Comment> comments = new List<Comment>();
            for (int i = 0; i < 100; i++)
            {
                Comment comment = new Comment()
                {
                    Text = commentText[random.Next(commentText.Count)],
                    UserId = users[random.Next(users.Count)].Id,

                };

                comments.Add(comment);
            }
            return comments;
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

        private List<User> SeedUsers(FridgeDbContext context)
        {
            var usernames = new string[] { "admin", "andrei", "joro", "peter", "ceco", "ivan" };
            string userImageStr = File.ReadAllText(peopleImageFilePath);
            List<ImageModel> userImages = JsonConvert.DeserializeObject<List<ImageModel>>(userImageStr);

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
                    Image = userImages[random.Next(userImages.Count)].Image,
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

        private void SeedRecipes(FridgeDbContext context, List<Ingredient> ingredientCollection,
            List<User> users, List<Category> categories, List<Comment> comments, List<Rating> ratings)
        {
            string imagesStr = File.ReadAllText(imagesFilePath);
            string recipesStr = File.ReadAllText(recipesFilePath);
            List<ImageModel> images = JsonConvert.DeserializeObject<List<ImageModel>>(imagesStr);
            List<RecipeJsonModel> recipes = JsonConvert.DeserializeObject<List<RecipeJsonModel>>(recipesStr).Take(30).ToList();

            foreach (var recipeObj in recipes)
            {
                Recipe recipe = new Recipe()
                {
                    Name = recipeObj.Title,
                    Image = images[random.Next(images.Count)].Image,
                    Description = recipeObj.Description,
                    PostedBy = users[random.Next(users.Count)],
                    CookingTime = new TimeSpan(0, random.Next(5, 61), 0),
                    PreparationTime = new TimeSpan(0, random.Next(5, 61), 0),
                    Servings = random.Next(2, 6),
                    TotalTime = new TimeSpan(0, random.Next(5, 61), 0),
                };

                int ingredientPosition = 1;
                foreach (var ingredient in recipeObj.Ingredients)
                {
                    IngredientRecipe ingredientRecipe = new IngredientRecipe() { Text = ingredient, Position = ingredientPosition++ };
                    List<string> ingredientParts = ingredient.Split(' ').ToList();
                    if (ingredientCollection.Any(x => ingredientParts.Contains(x.Name)))
                    {
                        int ingredientId = context.Ingredients.FirstOrDefault(x => ingredientParts.Contains(x.Name)).Id;
                        ingredientRecipe.IngredientId = ingredientId;
                    }

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
                    }

                    recipe.Tags.Add(tag);
                }

                for (int i = 0; i < 20; i++)
                {
                    Rating ratingDemo = ratings[random.Next(ratings.Count)];
                    Rating rating = new Rating()
                    {
                        Stars = ratingDemo.Stars,
                        UserId = ratingDemo.UserId
                    };
                    recipe.Ratings.Add(rating);

                    Comment commentDemo = comments[random.Next(comments.Count)];
                    Comment comment = new Comment()
                    {
                        Text = commentDemo.Text,
                        UserId = commentDemo.UserId,
                        Ratings = new HashSet<Rating>()
                        {
                            new Rating()
                            {
                                Stars = random.Next(1, 6),
                                UserId = users[random.Next(users.Count)].Id
                            },
                            new Rating()
                            {
                                Stars = random.Next(1, 6),
                                UserId = users[random.Next(users.Count)].Id
                            },
                            new Rating()
                            {
                                Stars = random.Next(1, 6),
                                UserId = users[random.Next(users.Count)].Id
                            },
                            new Rating()
                            {
                                Stars = random.Next(1, 6),
                                UserId = users[random.Next(users.Count)].Id
                            },
                            new Rating()
                            {
                                Stars = random.Next(1, 6),
                                UserId = users[random.Next(users.Count)].Id
                            },
                        }

                    };

                    recipe.Comments.Add(comment);
                }

                foreach (var user in users)
                {
                    recipe.PreparedBy.Add(user);
                }

                Random randomGenerator = new Random();
                int categoryIndex = randomGenerator.Next(categories.Count);
                recipe.Category = categories[categoryIndex];

                context.Recipes.Add(recipe);
                context.SaveChanges();
            }
        }
    }
}
