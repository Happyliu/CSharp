'use strict';

angular.module('coffeeStoreApp')
            .service('authService', ['$http', '$q', function ($http, $q) {
                var Local_Token_Key = 'mykey';
                var isAuthenticated = false;
                var username = "";
                var authToken;

                function loadUserCredentials() {
                    var token = window.localStorage.getItem(Local_Token_Key);
                    if (token) {
                        useCredentials(token);
                    }
                }

                function storeUserCredentials(token) {
                    window.localStorage.setItem(Local_Token_Key, token);
                }

                function useCredentials(token) {
                    isAuthenticated = false;
                    authToken = token;
                }

                function destoryUserCredentials() {
                    authToken = undefined;
                    isAuthenticated = false;

                    window.localStorage.removeItem(Local_Token_Key);
                }

                var register = function (user) {

                }

                var login = function (user) {
                    var deferred = $q.defer();
                    $http.post('../api/login', user).success(function (data) {
                        deferred.resolve(data);
                    });
                    return deferred.promise;
                }

                var logout = function () {
                    destoryUserCredentials();
                }

                loadUserCredentials();

                return {
                    login: login,
                    register: register,
                    logout: logout,
                    isAuthenticated: function () { return isAuthenticated; },
                };

            }]);