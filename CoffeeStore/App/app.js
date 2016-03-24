var app = angular.module('coffeeStoreApp', ['ui.router', 'ngTable']);

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

    $urlRouterProvider.otherwise('/');

});