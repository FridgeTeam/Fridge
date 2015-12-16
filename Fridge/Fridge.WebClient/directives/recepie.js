angular.module('app')

.directive('recepie', function () {
    return {
        scope: {
            datasource: '='
        },
        templateUrl: 'directives/Recepie.html'
    };
});