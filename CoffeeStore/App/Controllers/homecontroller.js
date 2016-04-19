'use strict';

angular.module('coffeeStoreApp')
    .controller('IndexController', ['$scope', 'menuFactory', function ($scope, menuFactory) {
        menuFactory.getProducts().then(function (data) {
            $scope.products = data;
        });

        $scope.myInterval = 5000;
        $scope.noWrapSlides = false;
        var slides = $scope.slides = [];
        
        $scope.addSlide = function () {
            var newWidth = 1200 +slides.length + 1;
            slides.push({
                image: '//lorempixel.com/' + newWidth + '/400/food',
                text: ['More', 'Extra', 'Lots of', 'Surplus'][slides.length % 4] + ' ' +
                  ['Pic', 'Pic', 'Pic', 'Pic'][slides.length % 4]
            });
        };
        for (var i = 0; i < 4; i++) {
            $scope.addSlide();
        }

    }]);