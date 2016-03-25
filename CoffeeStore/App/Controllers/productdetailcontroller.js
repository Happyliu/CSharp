'use strict';

angular.module('coffeeStoreApp')
.controller('ProductDetailController', ['$scope', '$stateParams', 'menuFactory', function ($scope, $stateParams, menuFactory) {
    $scope.newComment = { ProductID: 0, CommentID: 0, Rating: 5, CommentText: "", Author: "", CommentTime: "" };
    $scope.dish = {};
    $scope.showDish = false;
    $scope.message = "Loading ... ";
    $scope.productId = $stateParams.id;
    menuFactory.getProductById($scope.productId).then(
        function (response) {
            $scope.dish = response;
            $scope.newComment.ProductID = $scope.productId;
            $scope.showDish = true;
        },
        function (response) {
            $scope.message = "Error: " + response.status + " " + response.statusText;
        }
    );

    menuFactory.getCommentsByProductID($scope.productId).then(
        function (response) {
            $scope.comments = response;
        },
        function (response) {
            $scope.message = "Error: " + response.status + " " + response.statusText;
        }
    );

    $scope.typ = "";
    $scope.addComment = function () {
        $scope.newComment.CommentTime = new Date();
        $scope.comments.push($scope.newComment);
        //menuFactory.getDishes().update({id:$scope.dish.id},$scope.dish);
        menuFactory.AddComment($scope.newComment).then(
            function (response) {
                $scope.newComment = { ProductID: 0, CommentID: 0, Rating: 5, CommentText: "", Author: "", CommentTime: "" };
                console.log("add comment success");
            },
            function (response) {
                $scope.message = "Error: " + response.status + " " + response.statusText;
            }
        );

        $scope.dishCommentForm.$setPristine();
    }

}])