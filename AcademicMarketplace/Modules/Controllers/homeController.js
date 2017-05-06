var AcademicMarketplace;
(function (AcademicMarketplace) {
    var Controllers;
    (function (Controllers) {
        var HomeController = (function () {
            function HomeController($scope) {
                this.$scope = $scope;
                $scope.am = this;
            }
            return HomeController;
        }());
        HomeController.$inject = ['$scope'];
        Controllers.HomeController = HomeController;
    })(Controllers = AcademicMarketplace.Controllers || (AcademicMarketplace.Controllers = {}));
})(AcademicMarketplace || (AcademicMarketplace = {}));
//# sourceMappingURL=homeController.js.map