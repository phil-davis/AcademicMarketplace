var AcademicMarketplace;
(function (AcademicMarketplace) {
    var Controllers;
    (function (Controllers) {
        var HomeController = (function () {
            function HomeController($scope, userService) {
                this.$scope = $scope;
                this.userService = userService;
                $scope.am = this;
                this.getCurrentUser();
            }
            HomeController.prototype.getCurrentUser = function () {
                var _this = this;
                this.userService.getCurrentUser().then(function (response) {
                    _this.user = response.data;
                });
            };
            return HomeController;
        }());
        HomeController.$inject = ['$scope', 'userService'];
        Controllers.HomeController = HomeController;
    })(Controllers = AcademicMarketplace.Controllers || (AcademicMarketplace.Controllers = {}));
})(AcademicMarketplace || (AcademicMarketplace = {}));
//# sourceMappingURL=homeController.js.map