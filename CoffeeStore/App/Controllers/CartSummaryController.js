'use strict';

angular.module('coffeeStoreApp')
    .controller('CartSummaryController', ['$scope', function ($scope) {
        //get shopping cart items from global conteoller
        var items = $scope.$parent.cartService.getItems();
        var totalPrice = $scope.$parent.cartService.getTotalPrice();
        var addOneQty = function (id, name, qty, price, image) {
            $scope.$parent.cartService.addItem(id, name, qty, price, image);
            $scope.$parent.state.go($scope.$parent.state.current, {}, { reload: true });
        }
        var minusOneQty = function (id, qty) {
            if (qty === 1) {
                if (!confirm("Do you want to delete this item?"))
                    return;
            }
            $scope.$parent.cartService.minusQuantity(id);
            $scope.$parent.state.go($scope.$parent.state.current, {}, { reload: true });
        }
        $scope.cartSummaryData = {
            items: items,
            totalPrice: totalPrice,
            addOneQty: addOneQty,
            minusOneQty: minusOneQty
        };

    }])

    .directive('cartSummaryTable', function () {
        return {
            restrict: "E",
            replace: true,
            templateUrl: "Directive/cartsummarytabledirectivetemplate.html",
            scope: {
                cartSummaryData: "=",
            }
        }
    })

;