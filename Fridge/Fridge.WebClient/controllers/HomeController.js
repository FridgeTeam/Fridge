/// <reference path="E:\11.WepAPI\Fridge\Fridge\Fridge.WebClient\Scripts/_references.js" />
"use strict";

angular.module('app')

.controller('HomeController', function ($scope, $rootScope, publicRequests) {
    $scope.recepies = [];
    $scope.currentPage = 1;
    $scope.numPages = 0;
    $scope.numItems = 0;


    publicRequests.getRecipesWithPaging($scope.currentPage)
    .success(function (data) {
        $scope.recepies = data.Result;
        $scope.numPages = data.NumPages;
        $scope.numItems = data.NumItems;
        $scope.fixLayot();
    })

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
    $scope.getMoreRecipes = function () {
        $scope.currentPage++;
      
        publicRequests.getRecipesWithPaging($scope.currentPage)
        .success(function (data) {
            $scope.recepies = $scope.recepies.concat(data.Result);
        })
    }

    $(window).scroll(function (e) {
        var body = document.body;
        var scrollTop = this.pageYOffset || body.scrollTop;
        
        if ($scope.currentPage > $scope.numPages) {
            return;
        }
        console.log(body.scrollHeight);
        console.log(scrollTop);
        console.log(parseFloat(body.clientHeight));

        console.log(body.scrollHeight - scrollTop);

        var $body = $('body');
        if ((($body.get(0).scrollHeight - $body.scrollTop()) == $body.height())) {
            console.log($scope.currentPage);

            $scope.getMoreRecipes();
        }

        if (body.scrollHeight - scrollTop  <= 10) {
          
           
        }
    });
});