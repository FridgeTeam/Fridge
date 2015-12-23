angular.module('app')

.controller('RecepieController', function ($scope, $rootScope, $location, $routeParams, userRequests, userSession, notyService) {

    $scope.relativeRecepies = [
        { title: 'Chef John\'s Perfect Prime Rib', chef: 'Chef John', description: 'this delicious chicken dish is exquisite and easy to prepare. the light and luscious lemon sauce really pops without being too acidic; it is simply divine. serve it with herb-roasted potatoes or lemon-rice pilaf.', image: 'http://images.media-allrecipes.com/userphotos/250x250/1876731.jpg' },
        { title: 'Absolutely Ultimate Potato Soup', chef: 'Karena', description: 'I have made this for many whom have given it the title. This takes a bit of effort but is well worth it. Please note: for those who do not wish to use bacon, substitute 1/4 cup melted butter for the bacon grease and continue with the recipe. (I generally serve this soup as a special treat as it is not recommended for people counting calories.)', image: 'http://images.media-allrecipes.com/userphotos/250x250/168555.jpg' },
    ];

    // $routeParams.title
    // todo: fetch recepie from DB and bind it

    $scope.recepie = {
        "Title": "Sugared Rosewater Marzipan Balls (Kaber Ellouz)",
        "Description": "A simple almond dough is scented with rose water and dyed before being braided, cut, and rolled for these whimsical holiday treats",
        "Ingredients": [
            "1 cup (7 oz.) sugar, plus more",
            "\u003csup\u003e1\u003c/sup\u003e\u0026frasl;\u003csub\u003e4\u003c/sub\u003e tsp. kosher salt",
            "1 tbsp. rose water, preferably \u003ca href=\"http://www.saveur.com/our-favorite-rose-water\"\u003eCarlo\u003c/a\u003e",
            "1 tsp. vanilla extract",
            "2 cups (8 oz.) almond flour",
            "4 drops red food coloring",
            "4 drops green food coloring"
        ],
        "Instructions": [
            "In a small saucepan, combine the sugar with the salt and 6 tablespoons water and bring to a boil. Reduce the heat to medium-low and cook until slightly reduced, about 10 minutes. Remove from the heat and stir in the rose water and vanilla.",
            "Meanwhile, place the almond flour in a food processor and, with the motor running, slowly drizzle in the hot syrup until the dough gathers into a ball around the blade. Transfer the marzipan to a work surface and cut into 3 equal pieces.",
            "Place 2 pieces into 2 separate bowls and color one with the red food coloring and the other with the green food coloring. Knead each marzipan ball in the bowl until the food colorings are evenly incorporated.",
            "On a clean work surface, roll the plain dough into a 32-inch-long rope, about \u003csup\u003e1\u003c/sup\u003e\u0026frasl;\u003csub\u003e2\u003c/sub\u003e-inch thick, and repeat with the red and green doughs. Braid the three doughs together, cut the braid into about thirty \u003csup\u003e3\u003c/sup\u003e\u0026frasl;\u003csub\u003e4\u003c/sub\u003e-inch pieces, and roll each into a ball. Transfer to a serving platter or plate and toss the balls with enough sugar to coat."
        ],
        "Tags": ["Cookies", "Desserts", "Candies", "African", "North African", "almonds", "vegan", "Easy", "Christmas", "Winter", "Spring", "Gluten-Free", "issue 179", "Recipes"],
        "Chef": {
            "Name": "Chef John",
            "Image": "http://images.media-allrecipes.com/userphotos/50x50/2267470.jpg"
        },
        "Image": "http://images.media-allrecipes.com/userphotos/250x250/1876731.jpg"
    };

    $scope.reviews = [
        {
            "chef": {
                "name": "Haiku",
                "image": "http://www.coachcalorie.com/wp-content/uploads/2013/03/Your-Plan-of-Attack-For-Easy-Healthy-Cooking.jpg"
            },
            "content": "This is a fool proof method for making the best medium rare prime rib. Your seasonings can be changed according to your preference, but what's listed works perfectly.",
            "stars": 5
        },
        {
            "chef": {
                "name": "Denise",
                "image": "http://cdn.sheknows.com/articles/2013/05/woman-cooking-pasta.jpg"
            },
            "content": "Disable your smoke detectors if you prepare your roast this way! My oven cooled down much faster than two hours I feel because we had to open the windows.",
            "stars": 3
        },
        {
            "chef": {
                "name": "Claudia",
                "image": "http://www.thatitgirl.com/wp-content/uploads/2010/04/woman-cooking-860.jpg"
            },
            "content": "Absolutely, the easiest way to make perfect prime rib every time. But do not be tempted to open up the oven door until time is up.",
            "stars": 5
        },
        {
            "chef": {
                "name": "Annie",
                "image": "http://cdn.sheknows.com/articles/2012/02/chefmom-woman-cooking-pasta.jpg"
            },
            "content": "I know this is a culinary no-no, but we don't link pink meat, so while I partially use this method, I didn't do it exactly as Chef John suggests. ",
            "stars": 1
        },
        {
            "chef": {
                "name": "Karen",
                "image": "http://cdn.sheknows.com/articles/2012/03/woman-cooking-with-skillet.jpg"
            },
            "content": "Prime rib was perfect, juicy and perfectly pink. Followed the recipe exactly with a 4 lb prime rib. Loved it! Love the video to really get a good sense of how to apply the butter and herbs.",
            "stars": 4
        },
        {
            "chef": {
                "name": "Jane",
                "image": "http://cdn.sheknows.com/articles/2010/03/woman-cooking-with-pot.jpg"
            },
            "content": "OMG .. I have never been able to do Prime Rib correctly and I finally cracked it using this recipe. Thank you thank you thank you! The only alteration I made was to do the math.",
            "stars": 5
        }
    ];

    $scope.repeater = function (n) {
        var x = new Array(); for (var i = 0; i < n; i++) { x.push(i + 1); } return x;
    }
});