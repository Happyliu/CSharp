'use strict';

angular.module('coffeeStoreApp')
    .controller('IndexController', ['$scope', 'menuFactory', function ($scope, menuFactory) {
        $scope.message = "Hello Baodan!!!";
        menuFactory.getProducts().then(function (data) {
            $scope.products = data;
        });

    }])


;