angular.module('app')

.factory('publicRequests', function (baseUrl, requester) {

    var url = "";
    var data = {};

    var publicRequests = {
        getAllCategories: function () {
            url = baseUrl + 'categories';
            return requester.get(url);
        },

        /*Recipes*/
        getRecipesWithPaging: function (pageNumber) {
            url = baseUrl + 'recipes?StartPage=' + pageNumber;
            return requester.get(url);
        },

        getRandomRecipes: function (count) {
            url = baseUrl + 'recipes/random?count=' + count;
            return requester.get(url);
        },

        getRecipeByName: function (recipeName) {
            url = baseUrl + 'recipes?recipeName=' + recipeName;
            return requester.get(url);
        },

        getRecepiesByCategoryName: function (categoryName) {
            url = baseUrl + 'recipes?categoryName=' + categoryName;
            return requester.get(url);
        },

        getCommentsByCategoryName: function (recipeName, pageNumber, pageSize) {
            url = baseUrl + 'comments?recipeName=' + recipeName + "&startPage=" + pageNumber + "&pageSize=" + pageSize;
            return requester.get(url);
        }

    };

    return publicRequests;
});