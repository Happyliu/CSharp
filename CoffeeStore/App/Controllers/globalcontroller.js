app.controller('GlobalController', ['$scope', 'authService', 'cartservice', '$uibModal', '$log', '$state', '$rootScope', '$timeout', 'translationfactory', function ($scope, authService, cartservice, $uibModal, $log, $state, $rootScope, $timeout, translationfactory) {

    $scope.service = authService;
    $scope.translationfactory = translationfactory;

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
                cartservice.init();
                translationfactory.initPromise().then(function () {
                    $state.go($state.current, {}, { reload: true });
                }, 2000);
            });

        }, function () {
            $log.info('Modal dismissed at: ' + new Date());
        });
    };

    $scope.logout = function () {
        authService.logout();
        translationfactory.logoutPromise().then(
            function () {
                $state.go($state.current, {}, { reload: true });
            },
            function () {
                $state.go($state.current, {}, { reload: true });
            }
        );
    }

    $scope.cartService = cartservice;
    $scope.items = [];
    $scope.toggled = function (open) {
        $scope.items = cartservice.getItems();
    };

    $scope.addItem = function (id, name, qty, price, image) {
        cartservice.addItem(id, name, qty, price, image);
    }

    $scope.getItems = function () {
        return cartservice.getItems();
    }

    $scope.clearCart = function () {
        $scope.items = [];
        cartservice.clearCart();
        $state.go($state.current, {}, { reload: true });
    }
    $scope.state = $state;

    $scope.i18n = {
        currentLang: 'en-US',
        supportedLangs: ['en-US', 'zh-CN']
    };
    $scope.onLanguageChange = function (lang) {
        $scope.i18n.currentLang = lang;
        translationfactory.changeCulture(lang).then(function () {
            $state.go($state.current, {}, { reload: true });
        }, function (error) {
            console.log("change language error");
        });
    };
}]);

// Please note that $uibModalInstance represents a modal window (instance) dependency.
// It is not the same as the $uibModal service used above.

app.controller('ModalInstanceCtrl', ['$scope', 'authService', '$uibModalInstance', '$state', 'translationfactory', function ($scope, authService, $uibModalInstance, $state, translationfactory) {

    $scope.translationfactory = translationfactory;
    $scope.hasLoginError = false;
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

    $scope.alerts = [
        { type: 'danger', msg: '' },
    ];


    $scope.closeAlert = function (index) {
        $scope.alerts.splice(index, 1);
    };

    $scope.ok = function () {
        authService.login($scope.user).then(
            function (data) {
                $scope.result.Username = $scope.user.Username;
                $scope.result.Token = data;
                localStorage.setItem('Username', $scope.user.Username);
                $uibModalInstance.close($scope.result);
            },
            function (error) {
                console.log(error.data.Message);
                $scope.hasLoginError = true;
                $scope.alerts[0].msg = error.data.Message;
                //$uibModalInstance.close($scope.result);
            }
        );

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