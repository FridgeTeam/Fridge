using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.IO;
using RecipeParser.Models;

namespace RecipeParser
{
    class Parser
    {
        static void Main(string[] args)
        {
            string file = File.ReadAllText("../../recipes.json");
            List<RecipeJsonModel> asd = JsonConvert.DeserializeObject<List<RecipeJsonModel>>(file);

            foreach (var item in asd)
            {
                Console.Write("Title: ");
                Console.WriteLine(item.Title);
                Console.Write("Description: ");
                Console.WriteLine(item.Description);

                Console.Write("Ingredients: ");
                Console.WriteLine(string.Join("\n ", item.Ingredients));
                Console.Write("Instructions: ");
                Console.WriteLine(string.Join("\n ", item.Instructions));
                Console.Write("Tags: ");
                Console.WriteLine(string.Join("\n ", item.Tags));
            }
        }
    }
}
