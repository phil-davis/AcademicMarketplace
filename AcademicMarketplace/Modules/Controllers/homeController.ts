﻿module AcademicMarketplace.Controllers {
    export class HomeController {
        static $inject = ['$scope'];

        constructor(
            private $scope
        ) {
            $scope.am = this;
        }
    }
}
