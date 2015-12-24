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


    };


    return publicRequests;
});