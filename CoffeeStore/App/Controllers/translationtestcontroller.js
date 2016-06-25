'use strict';

angular.module('coffeeStoreApp')
    .controller('translationtestController', ['$scope', 'translationfactory', function ($scope, translationfactory) {
        $scope.translationfactory = translationfactory;
        $scope.tmp = staticData;
    }]);