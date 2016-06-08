'use strict';

angular.module('coffeeStoreApp')
    .controller('CheckController', ['$scope', 'customerservice', 'orderservice', function ($scope, customerservice, orderservice) {
        $scope.state = "FL";
        $scope.country = "US";
        $scope.states = ["FL", "CA", "TX", "NM", "AZ"];
        $scope.countries = ["US", "UK", "China", "Canda", "India"];
        $scope.checkout = {
            userid: "",
            firstName: "",
            lastName: "",
            email: "",
            addressline1: "",
            addressline2: ""
        };
        customerservice.getCustomerIdByName($scope.$parent.service.getAuthInfo().user).then(
            function (data) {
                if (data !== 0)
                    $scope.checkout.userid = data;
                console.log("userid " + data);
            },
            function (error) {

            }
        );
        $scope.checkout = function () {
            var order = {
                StoreID: 1,
                CustomerID: $scope.checkout.userid,
                OrderPrice: 0,
                OrderTime: "2016-04-10",
                PickUp: 0,
                PickUpTime: "2016-04-10",
                Status: "processing",
                Lines: ""
            }
            order.OrderPrice = $scope.$parent.cartService.getTotalPrice();
            order.Lines = $scope.$parent.cartService.getItems();
            console.log(order);
            orderservice.checkout(order).then(
                function (data) {
                    alert("place order successful!");
                    console.log("place order success");
                },
                function (error) {
                    console.log("place order has error");
                }
            );
        }
    }]);