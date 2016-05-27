'use strict';

angular.module('coffeeStoreApp')
    .controller('CheckController', ['$scope', function ($scope) {
        $scope.state = "FL";
        $scope.country = "US";
        $scope.states = ["FL", "CA", "TX", "NM", "AZ"];
        $scope.countries = ["US", "UK", "China", "Canda", "India"];
        $scope.checkout = {
            firstName: "",
            lastName: "",
            email: "",
            addressline1: "",
            addressline2: ""
        };
        $scope.checkout = function () {
            alert("hello");
        }
    }]);