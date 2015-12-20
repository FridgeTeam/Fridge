namespace Fridge.Data.Migrations
{
    using Models;
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    public sealed class Configuration : DbMigrationsConfiguration<FridgeDbContext>
    {
        private Random random = new Random(0);
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
            //List<User> users = this.SeedUsers(context, jobTitles, departments);
            //List<Recipe> recipe = this.SeedRecipes(context);
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
