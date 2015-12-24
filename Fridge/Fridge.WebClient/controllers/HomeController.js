/// <reference path="E:\11.WepAPI\Fridge\Fridge\Fridge.WebClient\Scripts/_references.js" />
"use strict";

angular.module('app')

.controller('HomeController', function ($scope, $rootScope, publicRequests, pagination) {

    $scope.pagination = pagination;
    $scope.pagination.bigCurrentPage = 1;  //setup for Pagination (ui.bootstrap.pagination)

    $scope.recepies = [];

    $scope.numPages = 0;
    $scope.numItems = 0;

  

    $scope.getData = function () {
        publicRequests.getRecipesWithPaging($scope.pagination.bigCurrentPage)
        .success(function (data) {
           $scope.recepies = data.Result;
           $scope.numPages = data.NumPages;
           $scope.numItems = data.NumItems;
           $scope.pagination.bigTotalItems = $scope.numPages * 10;  //setup for Pagination 
           $scope.fixLayot();
       })
    }   

    
    $scope.fixLayot = function () {
        var id;
        $(function () {
            setTimeout(function () {
                $(".grid").masonry();
            }, 200);

            $(window).resize(function () {
                clearTimeout(id);
                id = setTimeout(function () {
                    $(".grid").masonry();
                    console.log("asd");
                }, 1000);
            });

        })
    }

    //start point for controller
    $scope.getData();    
});