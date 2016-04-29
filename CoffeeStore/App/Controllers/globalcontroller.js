app.controller('GlobalController', ['$scope', 'authService', 'cartservice', '$uibModal', '$log', '$state', '$rootScope', '$timeout', function ($scope, authService, cartservice, $uibModal, $log, $state, $rootScope, $timeout) {

    $scope.service = authService;

    //using watch to make sure when user login change the value for current and isAuthenticated, the third value for the watch function is to watch an object
    $scope.$watch('service.getAuthInfo()', function (authInfo) {
        $scope.currentUser = authInfo.user;
        $scope.isAuthenticated = authInfo.isAuthenticated;
    }, true);

    $scope.open = function () {

        var modalInstance = $uibModal.open({
            animation: $scope.animationsEnabled,
            templateUrl: 'Views/loginmodal.html',
            controller: 'ModalInstanceCtrl'
        });

        modalInstance.result.then(function (result) {
            //need the timeout to set the value for rootscope user variable, then we refrash the page
            $timeout(function () {
                $state.go($state.current, {}, { reload: true });
            }, 2000);
        }, function () {
            $log.info('Modal dismissed at: ' + new Date());
        });
    };

    $scope.logout = function () {
        authService.logout();
        $state.go($state.current, {}, { reload: true });
    }

    $scope.addItem = function (id, name, qty, price) {
        cartservice.addItem(id, name, qty, price);
        $log.info(this.getItems());
    }

    $scope.getItems = function () {
        return cartservice.getItems();
    }

    $scope.clearCart = function () {
        return cartservice.clearCart();
    }

}]);

// Please note that $uibModalInstance represents a modal window (instance) dependency.
// It is not the same as the $uibModal service used above.

app.controller('ModalInstanceCtrl', ['$scope', 'authService', '$uibModalInstance', '$state', function ($scope, authService, $uibModalInstance, $state) {

    $scope.user = {
        "Username": "",
        "Password": "",
        "Ip": "232131",
        "UserAgent": "dsd",
        "Label": 23312
    };

    $scope.result = {
        "Username": "",
        "Token": "",
    }

    $scope.ok = function () {
        authService.login($scope.user).then(
            function (data) {
                $scope.result.Username = $scope.user.Username;
                $scope.result.Token = data;
                localStorage.setItem('Username', $scope.user.Username);
            },
            function (data) {

            }
        );
        $uibModalInstance.close($scope.result);
    };

    $scope.cancel = function () {
        $uibModalInstance.dismiss('cancel');
    };
}]);

app.controller('DropdownCtrl', function ($scope) {

    $scope.items = [
        "The first choice!",
        "And another choice for you.",
        "but wait! A third!"
    ];
});