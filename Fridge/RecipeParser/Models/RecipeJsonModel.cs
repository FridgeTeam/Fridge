using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecipeParser.Models
{
    class RecipeJsonModel
    {
        public string Title { get; set; }

        public string Description { get; set; }

        public List<string> Ingredients { get; set; }

        public List<string> Instructions { get; set; }

        public List<string> Tags { get; set; }
    }
}

//"Title": "Chicken Pot Shepherd\u0027s Pie",
//        "Description": "Give this comfort food staple the best of both worlds by topping a rich chicken stew with mashed potatoes and puff pastry.",
//        "Ingredients": [ "3 lb. russet potatoes, peeled and cut into 1-inch pieces", "Kosher salt and freshly ground black pepper", "4 \u003csup\u003e1\u003c/sup\u003e\u0026frasl;\u003csub\u003e2\u003c/sub\u003e cups milk", "14 tbsp. unsalted butter", "2 lb. chicken breast, cut into 1-inch pieces", "10 oz. button mushrooms, quartered", "\u003csup\u003e1\u003c/sup\u003e\u0026frasl;\u003csub\u003e21\u003c/sub\u003e  medium yellow onion, finely chopped", "1  red bell pepper, stemmed, seeded, and finely chopped", "\u003csup\u003e1\u003c/sup\u003e\u0026frasl;\u003csub\u003e2\u003c/sub\u003e cup flour", "1 cup fresh or frozen peas", "2  sheets puff pastry", "1  egg, lightly beaten" ],
//        "Instructions": [ "In a 4-qt. saucepan, cook potatoes in generously salted water until tender, about 20 minutes. Drain and pass in a potato ricer back into the pan. Add 1 cup milk, 6 tablespoons of butter, salt, and pepper and stir to combine. Keep warm.", "Melt 2 tablespoons butter in an 8-qt. saucepan over medium-high. Season chicken with salt and cook, stirring occasionally, 5 to 6 minutes. Using a slotted spoon, transfer chicken to a bowl.", "Melt remaining 6 tablespoons butter in saucepan over medium-high. Add mushrooms, onion, and pepper and cook, stirring, until soft, 3 to 4 minutes. Add flour and cook 2 minutes more. Add remaining 3 \u003csup\u003e1\u003c/sup\u003e\u0026frasl;\u003csub\u003e2\u003c/sub\u003e cups milk and cook, stirring, until thick, 6 to 8 minutes. Stir in reserved chicken and its juices, along with the peas, and cook 2 minutes longer. Season with salt and pepper and divide among 8 8-oz. ramekins or spread evenly into a 9-by-13-inch baking dish. Top evenly with mashed potatoes and set aside.", "Heat oven to 375°. Using a rolling pin, roll puff pastry until 1⁄8\" thick. Using a 4-inch round cutter, cut out eight circles (if baking in a 9-by-13-inch baking dish, cut pastry into a 10-by-14-inch rectangle). Using a pastry brush, brush the rim of each ramekin with egg wash and cover with a pastry circle and press lightly around the edges with a fork to adhere (if using a baking dish, follow the same procedure). Brush pastry with egg wash and place on a baking sheet. Bake until golden brown and filling is warmed through, about 35 minutes. Let cool 10 minutes before serving." ],
//        "Tags": [ "Recipes", "Chicken", "Main Course", "Fall", "Winter", "Potatoes", "Easy" ]