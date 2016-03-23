'use strict';

angular.module('coffeeStoreApp')
        .constant("baseURL", "http://zoliu1fl:9180/")
        .service('menuFactory', ['$http', '$q', 'baseURL', function ($http, $q, baseURL) {

            this.getProducts = function () {
                var deferred = $q.defer();
                $http({
                    method: "GET",
                    url: "../api/products",
                    headers: { 'Content-Type': 'application/json' }
                }).success(function (data) {
                    deferred.resolve(data);
                });
                return deferred.promise;
            }

            /*this.getProducts = function ($scope) {
                return $http({
                    method: "GET",
                    url: "../api/products",
                    headers: { 'Content-Type': 'application/json' }
                }).success(function (data) {
                    $scope.products = data;
                    console.log(data);
                }).error(function (data) {
                    console.log(data);
                });

            };*/



        }])

;