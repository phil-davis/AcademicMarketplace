var AcademicMarketplace;
(function (AcademicMarketplace) {
    var Controllers;
    (function (Controllers) {
        var HomeController = (function () {
            function HomeController() {
                alert("controller");
            }
            return HomeController;
        }());
        Controllers.HomeController = HomeController;
    })(Controllers = AcademicMarketplace.Controllers || (AcademicMarketplace.Controllers = {}));
})(AcademicMarketplace || (AcademicMarketplace = {}));
