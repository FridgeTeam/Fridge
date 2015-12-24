/// <reference path="E:\11.WepAPI\Fridge\Fridge\Fridge.WebClient\bower_components/jquery/dist/jquery.js" />
/// <reference path="E:\11.WepAPI\Fridge\Fridge\Fridge.WebClient\Scripts/_references.js" />
"use strict";

angular.module('app')

.controller('HomeController',
    function ($scope, $rootScope, publicRequests, pagination) {

        $scope.pagination = pagination;
        $scope.pagination.bigCurrentPage = 1;  //setup for Pagination (ui.bootstrap.pagination)

        $scope.recipes = [];
        $scope.slides = []; //recipes for carousel
        $scope.myInterval = 5000;
        $scope.noWrapSlides = false;

        $scope.getData = function () {
            publicRequests.getRecipesWithPaging($scope.pagination.bigCurrentPage)
            .success(function (data) {
                $scope.recipes = data.Result;
                $scope.pagination.bigTotalItems = data.NumPages * 10;  //setup for Pagination
                if ($scope.pagination.bigCurrentPage !== 1) {
                    $scope.scrollTo("html body");
                }
            })
        }

        $scope.getRandomRecipies = function () {
            publicRequests.getRandomRecipes(3)
            .success(function (data) {
                $scope.slides = data;
            })
        }

        $scope.scrollTo = function (id) {
            var scrollTo = $(id);
            $('html, body').animate({
                scrollTop: scrollTo.offset().top
            }, 1800);
        }

        //start point for controller
        $scope.getData();
        $scope.getRandomRecipies();
    });