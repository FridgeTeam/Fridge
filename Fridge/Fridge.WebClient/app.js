angular.module('app', [
    'ngRoute',
    'ngAnimate',
    'ngSanitize',
    'ui.bootstrap'
])

.config(['$routeProvider', '$locationProvider', function ($routeProvider, $locationProvider) {
    $routeProvider

    .when('/', {
        templateUrl: 'views/home-view.html',
        controller: 'HomeController'
    })

    .when('/register', {
        templateUrl: 'views/register-view.html',
        controller: 'RegisterController'
    })

    .when('/login', {
        templateUrl: 'views/login-view.html',
        controller: 'LoginController'
    })

     .when('/logout', {
         templateUrl: 'views/login-view.html',
         controller: 'LogoutController'
     })

    .when('/recipe/:name', {
        templateUrl: 'views/recipe-view.html',
        controller: 'RecipeController'
    })

    .when('/category/:name', {
        templateUrl: 'views/category-view.html',
        controller: 'CategoryController'
    })

}])


.controller('LogoutController', function ($location, userSession, notyService) {
    userSession.logout();
    $location.path('/');
    notyService.success('Logout successfully.');
})

.run(function ($rootScope, $location, userSession, publicRequests) {
    $rootScope.username = "";
    $rootScope.isLogin = false;
    $rootScope.isAdmin = "";
    $rootScope.categories = [];
    $rootScope.subLocation = "";

    $rootScope.getCategories = function () {
        publicRequests.getAllCategories()
        .success(function (data) {
            $rootScope.categories = data;
        })
        .error(function (error) {
            console.log(error);
        })
    }

    $rootScope.getCategories();

    $rootScope.$on('$locationChangeStart', function (event) {
        if (userSession.getCurrentUser()) {
            $rootScope.username = userSession.getCurrentUser().userName;
            $rootScope.isAdmin = userSession.isAdmin();
            $rootScope.isLogin = true;

        } else {
            $rootScope.username = "";
            $rootScope.isAdmin = "";
            $rootScope.isLogin = false;
        }

        console.log($rootScope.isAdmin);


        if ($location.path().indexOf("/user/") != -1 && !userSession.getCurrentUser()) {
            // Authorization check: anonymous site visitors cannot access user routes
            $location.path("/");
            $rootScope.isLogin = false;
        }

        if (userSession.isAdmin() && $location.path().indexOf("/user/") != -1) {
            $location.path('/admin/home');
            console.log("admin");
        }

    });
})