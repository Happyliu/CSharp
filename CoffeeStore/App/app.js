var app = angular.module('coffeeStoreApp', ['ui.router', 'ui.bootstrap', 'ngTable']);

app.controller('HeaderController', function ($scope) {

});

app.controller('DropdownCtrl', function ($scope) {

    $scope.items = [
        "The first choice!",
        "And another choice for you.",
        "but wait! A third!"
    ];
});

app.config(function ($stateProvider, $urlRouterProvider, $locationProvider) {

    $stateProvider

    //route for the home page
    .state('app', {
        url: '/',
        views: {
            'header': {
                templateUrl: 'Views/header.html',
            },
            'content': {
                templateUrl: 'Views/home.html',
                controller: 'IndexController'
            },
            'footer': {
                templateUrl: 'Views/footer.html'
            }
        }
    })

    //route for the menu page
    .state('app.menu', {
        url: 'menu',
        views: {
            'content@': {
                templateUrl: 'views/menu.html',
                controller: 'MenuController'
            }
        }
    })

    //route for dishdetail page
    .state('app.productdetails', {
        url: 'menu/:id',
        views: {
            'content@': {
                templateUrl: 'views/productdetail.html',
                controller: 'ProductDetailController'
            }
        }
    });

    $urlRouterProvider.otherwise('/');

});