var app = angular.module('coffeeStoreApp', ['ui.router', 'ui.bootstrap', 'ngTable']);

app.config(function ($stateProvider, $urlRouterProvider, $locationProvider, $httpProvider) {

    $httpProvider.interceptors.push(function () {
        return {
            // optional method
            'request': function (config) {
                // do something on success
                config.headers['Token'] = localStorage.getItem('Token')
                return config;
            }
        };
    });

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

    //route for the contactus page
    .state('app.contactus', {
        url: 'contactus',
        views: {
            'content@': {
                templateUrl: 'views/contactus.html',
                controller: 'ContactController'
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

    //route for cartsummary page
    .state('app.cartsummary', {
        url: 'cartsummary',
        views: {
            'content@': {
                templateUrl: 'views/cartsummary.html',
                controller: 'CartSummaryController'
            }
        }
    })

    //route for checkout page
    .state('app.checkout', {
        url: 'checkout',
        views: {
            'content@': {
                templateUrl: 'views/checkout.html',
                controller: 'CheckController'
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

    $locationProvider.html5Mode({
        enabled: true,
        requireBase: false
    });

    $urlRouterProvider.otherwise('/');
    //$locationProvider.html5Model(true);
});