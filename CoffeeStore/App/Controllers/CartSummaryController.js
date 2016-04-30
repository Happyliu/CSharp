'use strict';

angular.module('coffeeStoreApp')
    .controller('CartSummaryController', ['$scope', function ($scope) {
        //get shopping cart items from global conteoller
        $scope.items = $scope.$parent.cartService.getItems();
        $scope.totalPrice = $scope.$parent.cartService.getTotalPrice();
    }])

    .directive('cartSummaryTable', function () {
        return {
            restrict: "E",
            replace: true,
            templateUrl: "Directive/cartsummarytabledirectivetemplate.html",
            scope: {
                cartItems: "=",
                totalPrice: "="
            }
        }
    })

;