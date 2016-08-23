'use strict';

angular.module('coffeeStoreApp')
            .service('authService', ['$http', '$q', function ($http, $q) {
                var Local_Token_Key = 'Token';
                var isAuthenticated = false;
                var userKey = "username";
                var authToken;
                var username;

                function loadUserCredentials() {
                    var token = window.localStorage.getItem(Local_Token_Key);
                    var user = window.localStorage.getItem(userKey);
                    if (token && user) {
                        useCredentials(token, user);
                    }
                    console.log("auth service start");
                }

                function storeUserCredentials(token, username) {
                    window.localStorage.setItem(Local_Token_Key, token);
                    window.localStorage.setItem(userKey, username);
                    isAuthenticated = true;
                    loadUserCredentials();
                }

                function useCredentials(token, user) {
                    isAuthenticated = true;
                    authToken = token;
                    username = user;

                }

                function destoryUserCredentials() {
                    authToken = undefined;
                    isAuthenticated = false;
                    window.localStorage.removeItem(Local_Token_Key);
                    window.localStorage.removeItem(userKey);
                }

                function resetisAuthenticated() {
                    authToken = false;
                }

                var register = function (user) {

                }

                function login(user) {
                    var deferred = $q.defer();
                    $http.post('../api/login', user).then(function (data) {
                        storeUserCredentials(data.data, user.Username);
                        deferred.resolve(data);
                    }, function (error) {
                        console.log(error.data.Message);
                        deferred.reject(error);
                    });
                    return deferred.promise;
                }

                var logout = function () {
                    destoryUserCredentials();
                }

                var getAuthInfo = function () {
                    var authInfo = {
                        user: "",
                        isAuthenticated: "",
                        authToken: "",
                    };
                    authInfo.user = username;
                    authInfo.isAuthenticated = isAuthenticated;
                    authInfo.authToken = authToken;
                    return authInfo;
                }

                var checkTokenFromServer = function () {
                    var deferred = $q.defer();
                    $http({
                        method: "GET",
                        url: "../api/login",
                        headers: { 'Content-type': 'application/json' }
                    }).success(function (data) {
                        deferred.resolve(data);
                    });
                    return deferred.promise;
                }

                var checkValidToken = function () {
                    if ((username === undefined && authToken === undefined) || (username === "" && authToken === ""))
                        return false;
                    else {
                        return checkTokenFromServer();
                    }
                }

                loadUserCredentials();

                return {
                    login: login,
                    register: register,
                    logout: logout,
                    getAuthInfo: getAuthInfo,
                    checkValidToken: checkValidToken,
                    resetisAuthenticated: resetisAuthenticated
                };

            }]);