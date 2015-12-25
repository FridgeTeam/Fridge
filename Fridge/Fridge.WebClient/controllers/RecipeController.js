angular.module('app')

.controller('RecipeController', function ($scope, $rootScope, $location, $routeParams, publicRequests, userSession, notyService) {   

    var recipeName = $routeParams.name;
    $scope.recipe = {};
    $scope.relativeRecipes = [];

    publicRequests.getRecipeByName(recipeName)
        .success(function (data) {
            $scope.recipe = data;
        })
        .error(function (error) {
            console.log(error);
        });

   publicRequests.getRandomRecipes(3)
        .success(function (data) {
            $scope.relativeRecipes = data;
        })
        .error(function (error) {
            console.log(error);
        });
   





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