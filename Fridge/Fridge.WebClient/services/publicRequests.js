angular.module('app')

.factory('publicRequests', function (baseUrl, requester) {

    var url = "";
    var data = {};

    var publicRequests = {
        getAllCategories: function () {
            url = baseUrl + 'categories/getall';
            return requester.get(url);
        },
       

    };


    return publicRequests;
});