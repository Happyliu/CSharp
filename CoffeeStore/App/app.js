var app = angular.module('coffeeStoreApp', ['ui.router']);

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

});