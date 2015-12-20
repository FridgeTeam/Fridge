﻿angular.module('app')

.controller('HomeController', function ($scope, $rootScope, publicRequests) {
    $scope.recepies = [
            { title: 'Chef John\'s Perfect Prime Rib', chef: 'Chef John', description: 'this delicious chicken dish is exquisite and easy to prepare. the light and luscious lemon sauce really pops without being too acidic; it is simply divine. serve it with herb-roasted potatoes or lemon-rice pilaf.', image: 'http://images.media-allrecipes.com/userphotos/250x250/1876731.jpg' },
            { title: 'Absolutely Ultimate Potato Soup', chef: 'Karena', description: 'I have made this for many whom have given it the title. This takes a bit of effort but is well worth it. Please note: for those who do not wish to use bacon, substitute 1/4 cup melted butter for the bacon grease and continue with the recipe. (I generally serve this soup as a special treat as it is not recommended for people counting calories.)', image: 'http://images.media-allrecipes.com/userphotos/250x250/168555.jpg' },
            { title: 'Lemon Chicken Piccata', chef: 'LemonLush', description: 'This delicious chicken dish is exquisite and easy to prepare. The light and luscious lemon sauce really pops without being too acidic; it is simply divine. Serve it with herb-roasted potatoes or lemon-rice pilaf.', image: 'http://images.media-allrecipes.com/userphotos/250x250/450856.jpg' },
            { title: 'Overnight Blueberry French Toast', chef: 'KARAN1946', description: 'This is a very unique breakfast dish. Good for any holiday breakfast or brunch, it\'s filled with the fresh taste of blueberries, and covered with a rich blueberry sauce to make it a one of a kind.', image: 'http://images.media-allrecipes.com/userphotos/250x250/381517.jpg' },
            { title: 'Absolutely Ultimate Potato Soup', chef: 'Karena', description: 'I have made this for many whom have given it the title. This takes a bit of effort but is well worth it. Please note: for those who do not wish to use bacon, substitute 1/4 cup melted butter for the bacon grease and continue with the recipe. (I generally serve this soup as a special treat as it is not recommended for people counting calories.)', image: 'http://images.media-allrecipes.com/userphotos/250x250/168555.jpg' },
            { title: 'Lemon Chicken Piccata', chef: 'LemonLush', description: 'This delicious chicken dish is exquisite and easy to prepare. The light and luscious lemon sauce really pops without being too acidic; it is simply divine. Serve it with herb-roasted potatoes or lemon-rice pilaf.', image: 'http://images.media-allrecipes.com/userphotos/250x250/450856.jpg' },
            { title: 'Overnight Blueberry French Toast', chef: 'KARAN1946', description: 'This is a very unique breakfast dish. Good for any holiday breakfast or brunch, it\'s filled with the fresh taste of blueberries, and covered with a rich blueberry sauce to make it a one of a kind.', image: 'http://images.media-allrecipes.com/userphotos/250x250/381517.jpg' },
            { title: 'Chef John\'s Perfect Prime Rib', chef: 'Chef John', description: 'this delicious chicken dish is exquisite and easy to prepare. the light and luscious lemon sauce really pops without being too acidic; it is simply divine. serve it with herb-roasted potatoes or lemon-rice pilaf.', image: 'http://images.media-allrecipes.com/userphotos/250x250/1876731.jpg' }
    ];

    $scope.fixLayot = function () {
        $(function () {
            setTimeout(function () {
                $(".grid").masonry();
            }, 200);

            $(window).resize(function () {
                console.log("asd");
                setTimeout(function () {
                    $(".grid").masonry();
                    console.log("asd");
                }, 1000);


            });

        })
    }

    $scope.fixLayot();
});