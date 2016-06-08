'use strict';

angular.module('coffeeStoreApp')
            .service("orderservice", ['$http', '$q', function ($http, $q) {
                var checkout = function (order) {
                    var deferred = $q.defer();
                    $http.post("../api/order", order).success(function (data) {
                        deferred.resolve(data);
                    }).error(function (error) {
                        console.log(error);
                    });
                    return deferred.promise;
                }
                return {
                    checkout: checkout
                }
            }]);