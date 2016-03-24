'use strict';

angular.module('coffeeStoreApp')
    .controller('MenuController', ['$scope', 'menuFactory', 'ngTableParams', function ($scope, menuFactory, ngTableParams) {
        $scope.tab = 1;
        $scope.filtText = "";
        $scope.showDetails = false;
        $scope.showMenu = false;
        $scope.message = "Loading ... ";
        $scope.start = 0;
        $scope.end = 5;

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
            $scope.start += 5;
            $scope.end += 5;
        }

        $scope.minusFive = function () {
            $scope.start -= 5;
            $scope.end -= 5;
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