'use strict';

angular.module('coffeeStoreApp')
    .controller('MenuController', ['$scope', 'menuFactory', 'ngTableParams', function ($scope, menuFactory, ngTableParams) {
        $scope.tab = 1;
        $scope.filtText = "";
        $scope.showDetails = false;
        $scope.showMenu = false;
        $scope.message = "Loading ... ";
        $scope.start = 0;
        $scope.end = 6;

        menuFactory.getProducts().then(
            function (response) {
                $scope.dishes = response;
                $scope.showMenu = true;
            },
            function (response) {
                $scope.message = "Error: " + response.status + " " + response.statusText;
            }
        );

        $scope.addFive = function () {
            if ($scope.end < $scope.dishes.length) {
                $scope.start += 6;
                $scope.end += 6;
            }
        }

        $scope.minusFive = function () {
            if ($scope.start >= 6) {
                $scope.start -= 6;
                $scope.end -= 6;
            }
        }

        $scope.select = function (setTab) {
            $scope.tab = setTab;
            if (setTab === 2) {
                $scope.filtText = "food";
            }
            else if (setTab === 3) {
                $scope.filtText = "drink";
            }
            else if (setTab === 4) {
                $scope.filtText = "dessert";
            }
            else {
                $scope.filtText = "";
            }
        };

        $scope.isSelected = function (checkTab) {
            return ($scope.tab === checkTab);
        };

        $scope.toggleDetails = function () {
            $scope.showDetails = !$scope.showDetails;
        };
    }])

    .filter('slice', function () {
        return function (arr, start, end) {
            return arr.slice(start, end);
        };
    });