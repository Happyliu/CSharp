'use strict';

angular.module('coffeeStoreApp')
    .controller('CartSummaryController', ['$scope', '$uibModal', '$log', '$state', '$timeout', function ($scope, $uibModal, $log, $state, $timeout) {
        //get shopping cart items from global conteoller
        var items = $scope.$parent.cartService.getItems();
        var totalPrice = $scope.$parent.cartService.getTotalPrice();
        var addOneQty = function (id, name, qty, price, image) {
            $scope.$parent.cartService.addItem(id, name, qty, price, image);
            $scope.$parent.state.go($scope.$parent.state.current, {}, { reload: true });
        }
        var minusOneQty = function (id, qty) {
            if (qty === 1) {
                if (!confirm("Do you want to delete this item?"))
                    return;
            }
            $scope.$parent.cartService.minusQuantity(id);
            $scope.$parent.state.go($scope.$parent.state.current, {}, { reload: true });
        }
        $scope.cartSummaryData = {
            items: items,
            totalPrice: totalPrice,
            addOneQty: addOneQty,
            minusOneQty: minusOneQty
        };
        $scope.pickUp = false;
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
                $scope.openLoginModel();
            } else {
                if ($scope.$parent.service.checkValidToken()) {
                    $state.go('app.checkout', {}, { reload: true });
                } else {
                    $scope.openLoginModel();
                }
            }
        }

        //uil date picker control
        $scope.today = function () {
            $scope.dt = new Date();
        };
        $scope.today();
        $scope.toggleMin = function () {
            $scope.minDate = $scope.minDate ? null : new Date();
        };
        $scope.toggleMin();
        $scope.maxDate = new Date(2020, 5, 22);
        $scope.setDate = function (year, month, day) {
            $scope.dt = new Date(year, month, day);
        };
        $scope.dateOptions = {
            formatYear: 'yy',
            startingDay: 1
        };
        $scope.formats = ['dd-MMMM-yyyy', 'yyyy/MM/dd', 'dd.MM.yyyy', 'shortDate'];
        $scope.format = $scope.formats[0];
        $scope.status = {
            opened: false
        };
        $scope.open = function ($event) {
            $scope.status.opened = true;
        };
        // Disable weekend selection
        $scope.disabled = function (date, mode) {
            return (mode === 'day' && (date.getDay() === 0 || date.getDay() === 6));
        };

        //uil time picker control
        $scope.mytime = new Date();

        $scope.hstep = 1;
        $scope.mstep = 15;

        $scope.options = {
            hstep: [1, 2, 3],
            mstep: [1, 5, 10, 15, 25, 30]
        };

        $scope.ismeridian = true;
        $scope.toggleMode = function () {
            $scope.ismeridian = !$scope.ismeridian;
        };

        $scope.update = function () {
            var d = new Date();
            d.setHours(14);
            d.setMinutes(0);
            $scope.mytime = d;
        };

        $scope.changed = function () {
            $log.log('Time changed to: ' + $scope.mytime);
        };

        $scope.clear = function () {
            $scope.mytime = null;
        };

    }])

    .directive('cartSummaryTable', function () {
        return {
            restrict: "E",
            replace: true,
            templateUrl: "Directive/cartsummarytabledirectivetemplate.html",
            scope: {
                cartSummaryData: "=",
            }
        }
    })

;