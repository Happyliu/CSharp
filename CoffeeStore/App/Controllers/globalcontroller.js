app.controller('GlobalController', ['$scope', 'authService', '$uibModal', '$log', '$state', '$rootScope', '$timeout', function ($scope, authService, $uibModal, $log, $state, $rootScope, $timeout) {
    $rootScope.user = {
        'Username': undefined,
        'Token': 'null',
    };

    $scope.open = function () {

        var modalInstance = $uibModal.open({
            animation: $scope.animationsEnabled,
            templateUrl: 'Views/loginmodal.html',
            controller: 'ModalInstanceCtrl'
        });

        modalInstance.result.then(function (result) {
            //need the timeout to set the value for rootscope user variable, then we refrash the page
            $timeout(function () {
                $rootScope.user.Username = localStorage.getItem("Username");
                $rootScope.user.Token = localStorage.getItem("Token");
                $state.go($state.current, {}, { reload: true });
            }, 3000);
        }, function () {
            $log.info('Modal dismissed at: ' + new Date());
        });
    };


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