/// <reference path="E:\11.WepAPI\Fridge\Fridge\Fridge.WebClient\Scripts/_references.js" />
"use strict";

angular.module('app')

.controller('HomeController', function ($scope, $rootScope, publicRequests, pagination) {

    $scope.pagination = pagination;
    $scope.pagination.bigCurrentPage = 1;  //setup for Pagination (ui.bootstrap.pagination)

    $scope.recipes = [];
    

    $scope.getData = function () {
        publicRequests.getRecipesWithPaging($scope.pagination.bigCurrentPage)
        .success(function (data) {
           $scope.recipes = data.Result;          
           $scope.pagination.bigTotalItems = data.NumPages * 10;  //setup for Pagination           
       })
    }

    //start point for controller
    $scope.getData();    
});