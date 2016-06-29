'use strict';

angular.module('coffeeStoreApp')
            .factory("translationfactory", ['$http', '$q', 'customerservice', 'authService', function ($http, $q, customerservice, authService) {
                var keys = [];
                var current = {};
                var culturecode = null;
                function init() {
                    var translationKeys = staticData.translationKeys;
                    loadKeysFromStaticData(translationKeys);
                    var cusName = authService.getAuthInfo().user;
                    customerservice.getCustomerCultureByName(cusName).then(function (result) {
                        culturecode = result;
                    }).then(function () {
                        var translationRequest = {
                            CultureKey: culturecode,
                            Values: keys
                        }
                        getTranslation(translationRequest).then(function (data) {
                            loadDataToCurrent(data.Values)
                            console.log(current);
                        });
                    });
                }

                function initPromise() {
                    var defered = $q.defer();
                    var translationKeys = staticData.translationKeys;
                    loadKeysFromStaticData(translationKeys);
                    var cusName = authService.getAuthInfo().user;
                    customerservice.getCustomerCultureByName(cusName).then(function (result) {
                        culturecode = result;
                    }).then(function () {
                        var translationRequest = {
                            CultureKey: culturecode,
                            Values: keys
                        }
                        getTranslation(translationRequest).then(function (data) {
                            loadDataToCurrent(data.Values)
                            console.log(current);
                            defered.resolve(data);
                        });
                    });
                    return defered.promise;
                }

                function logoutPromise() {
                    var defered = $q.defer();
                    var translationKeys = staticData.translationKeys;
                    loadKeysFromStaticData(translationKeys);

                    var translationRequest = {
                        CultureKey: "",
                        Values: keys
                    }
                    getTranslation(translationRequest).then(function (data) {
                        loadDataToCurrent(data.Values)
                        console.log(current);
                        defered.resolve(data);
                    });
                    return defered.promise;
                }

                function loadKeysFromStaticData(translationKeys) {
                    angular.forEach(translationKeys, function (value, key) {
                        keys.push({
                            Key: value.Key,
                            Value: value.Value,
                            CustomValue: null
                        })
                    });
                }

                function getTranslation(transReq) {
                    var defered = $q.defer();
                    $http.post("../api/translation", transReq).success(function (res) {
                        defered.resolve(res);
                    }).error(function (error) {
                        console.log(error);
                    });
                    return defered.promise;
                }

                function loadDataToCurrent(data) {
                    angular.forEach(data, function (value, key) {
                        if (value.CustomValue !== null)
                            current[value.Key] = value.CustomValue;
                        else
                            current[value.Key] = value.Value;
                    });
                }

                function changeCulture() {

                }
                function clearCache() {

                }
                function getTranslatedValue() {

                }
                init();
                return {
                    init: init,
                    initPromise: initPromise,
                    logoutPromise: logoutPromise,
                    getTranslatedValue: getTranslatedValue,
                    current: current
                }
            }]);