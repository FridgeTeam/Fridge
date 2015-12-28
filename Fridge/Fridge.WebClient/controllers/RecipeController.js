angular.module('app')

.controller('RecipeController', function ($scope, $rootScope, $location, $routeParams, publicRequests, userSession, notyService) {

    var recipeName = $routeParams.name;
    $scope.recipe = {};
    $scope.relativeRecipes = [];
    $scope.comments = [];

    $scope.commentPageSize = 4;
    $scope.pageNumber = 1;

    //help functions
    $scope.fixRationg = function (starsCountObject) {
        var result = [];
        for (var i = 0; i < 5; i++) {
            var currentStar = i + 1;
            var stars = Enumerable.From(starsCountObject)
                .Where(function (x) { return x.Star == currentStar })
                .Select(function (x) { return x.StarCount })
                .FirstOrDefault();

            if (!stars) {
                stars = 0;
            }

            result.push(stars);
        }

        return result;
    }

    $scope.repeater = function (n) {
        return new Array(n);
    }

    //handlers
    $scope.getComments = function () {
        publicRequests.getCommentsByCategoryName(recipeName, $scope.pageNumber, $scope.commentPageSize)
           .success(function (data) {
               $scope.comments = data;
           })
           .error(function (error) {
               console.log(error);
           });
    }

    $scope.previeousComment = function () {
        $scope.pageNumber = $scope.pageNumber - 1;
        $scope.getComments();       

    }

    $scope.nextComment = function () {
        $scope.pageNumber = $scope.pageNumber + 1;
        $scope.getComments();
    }



    //starts
    publicRequests.getRecipeByName(recipeName)
        .success(function (data) {
            $scope.recipe = data;
            var starsCountObject = data.RatingByStars;
            $scope.recipe.RatingByStars = $scope.fixRationg(starsCountObject);
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

    $scope.getComments();


});