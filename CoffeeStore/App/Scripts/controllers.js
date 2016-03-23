'use strict';

angular.module('coffeeStoreApp')
    .controller('IndexController', ['$scope', 'menuFactory', function ($scope, menuFactory) {
        $scope.message = "hello";
        menuFactory.getProducts().then(function (data) {
            $scope.products = data;
        });

    }])


;