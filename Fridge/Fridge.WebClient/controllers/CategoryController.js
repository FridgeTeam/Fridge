angular.module('app')

.controller('CategoryController', function ($scope, $rootScope, $location, $routeParams, publicRequests, userSession, notyService) {   

    var categoryName = $routeParams.name;
    $scope.categoryName = $routeParams.name;
    $scope.recipes = {};

    publicRequests.getRecepiesByCategoryName(categoryName)
        .success(function (data) {
            $scope.recipes = data;
            console.log($scope.recipes);
        })
        .error(function (error) {
            console.log(error);
        });

});