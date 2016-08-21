'use strict';

angular.module('coffeeStoreApp')
            .service("solrsearchservice", ['$http', '$q', function ($http, $q) {
                var solrsearch = function (model) {
                    var deferred = $q.defer();
                    $http.post("http://liuzhaodf91:5732/api/solrsearchproduct", model).success(function (data) {
                        deferred.resolve(data);
                    }).error(function (error) {
                        console.log(error);
                    });
                    return deferred.promise;
                }
                return {
                    solrsearch: solrsearch
                }
            }]);