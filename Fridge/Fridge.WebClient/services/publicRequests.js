angular.module('app')

.factory('publicRequests', function (baseUrl, requester) {

    var url = "";
    var data = {};

    var publicRequests = {
        getAllCategories: function () {
            url = baseUrl + 'categories';
            return requester.get(url);
        },

        //int : page
        getRecipesWithPaging: function (page) {
            url = baseUrl + 'recipes?StartPage=' + page;
            return requester.get(url);
        },


    };


    return publicRequests;
});