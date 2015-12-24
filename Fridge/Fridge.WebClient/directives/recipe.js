angular.module('app')
.directive('ngRecipe', function () {
    return {
        scope: {
            datasource: '='
        },
        templateUrl: 'directives/recipe.html'
    };
});