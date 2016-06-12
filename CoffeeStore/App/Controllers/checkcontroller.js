'use strict';

angular.module('coffeeStoreApp')
    .controller('CheckController', ['$scope', 'customerservice', 'orderservice', '$state', '$timeout', '$uibModal', '$log', function ($scope, customerservice, orderservice, $state, $timeout, $uibModal, $log) {
        $scope.state = "FL";
        $scope.country = "US";
        $scope.states = ["FL", "CA", "TX", "NM", "AZ"];
        $scope.countries = ["US", "UK", "China", "Canda", "India"];
        $scope.checkout = {
            userid: "",
            firstName: "",
            lastName: "",
            email: "",
            addressline1: "",
            addressline2: ""
        };
        customerservice.getCustomerIdByName($scope.$parent.service.getAuthInfo().user).then(
            function (data) {
                if (data !== 0)
                    $scope.checkout.userid = data;
                console.log("userid " + data);
            },
            function (error) {

            }
        );

        $scope.openLoginModel = function () {

            var modalInstance = $uibModal.open({
                animation: $scope.animationsEnabled,
                templateUrl: 'Views/loginmodal.html',
                controller: 'ModalInstanceCtrl'
            });

            modalInstance.result.then(function (result) {
                //need the timeout to set the value for rootscope user variable, then we refrash the page
                $timeout(function () {
                    $scope.$parent.cartService.init();
                    $state.go('app.checkout', {}, { reload: true });
                }, 2000);
            }, function () {
                $log.info('Modal dismissed at: ' + new Date());
            });
        };

        $scope.checkout = function () {
            var authInfo = $scope.$parent.service.getAuthInfo();
            if ((authInfo.user === "" && authInfo.authToken === "") || (authInfo.user === undefined && authInfo.authToken === undefined)) {
                alert("session time out, please login again!");
                $timeout(function () {
                    $scope.openLoginModel();
                }, 2000);
            } else {
                $scope.$parent.service.checkValidToken().then(function (data) {
                    if (data) {
                        var order = {
                            StoreID: 1,
                            CustomerID: $scope.checkout.userid,
                            OrderPrice: 0,
                            OrderTime: new Date(),
                            PickUp: 0,
                            PickUpTime: new Date(),
                            Status: "processing",
                            Lines: ""
                        }
                        order.OrderPrice = $scope.$parent.cartService.getTotalPrice();
                        order.Lines = $scope.$parent.cartService.getItems();
                        var pickupinfo = $scope.$parent.cartService.getPickupInfo();
                        order.PickUpTime = pickupinfo.pickuptime.toISOString();
                        order.PickUp = pickupinfo.pickup;
                        order.OrderTime = order.OrderTime.toISOString();
                        console.log(order);
                        orderservice.checkout(order).then(
                            function (data) {
                                alert("place order successful!");
                                $scope.$parent.cartService.clearCart();
                                console.log("place order success! redirect to home page ...");
                                $timeout(function () {
                                    $state.go('app', {}, { reload: true })
                                }, 2000);
                            },
                            function (error) {
                                console.log("place order has error");
                            }
                        );
                    } else {
                        alert("session time out, please login again!");
                        $scope.$parent.service.resetisAuthenticated();
                        $timeout(function () {
                            $scope.openLoginModel();
                        }, 2000);
                    }
                });
            }
        }
    }]);