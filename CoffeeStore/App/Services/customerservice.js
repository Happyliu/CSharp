'use strict';

angular.module('coffeeStoreApp')
            .service("customerservice", ['$http', '$q', function ($http, $q) {
                var getCustomerIdByName = function (cusName) {
                    var deferred = $q.defer();
                    $http({
                        method: "GET",
                        url: "../api/customer?cusName=" + cusName,
                        headers: { 'content-type': 'application/json' }
                    }).success(function (data) {
                        deferred.resolve(data);
                    }).error(function (data) {

                    });
                    return deferred.promise;
                }
                return {
                    getCustomerIdByName: getCustomerIdByName
                }
            }]);