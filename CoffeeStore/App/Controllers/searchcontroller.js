'use strict';

angular.module('coffeeStoreApp')
    .controller('searchController', ['$scope', 'solrsearchservice', function ($scope, solrsearchservice) {
        $scope.searchtext = "";
        $scope.solrResults = [];
        $scope.search = function () {
            var model = {
                Query: ""
            };
            model.Query = $scope.searchtext;
            solrsearchservice.solrsearch(model).then(
                function (data) {
                    solrResults = data;
                },
                function (error) {
                    console.log("solr search has error");
                }
            );
        }
    }]);