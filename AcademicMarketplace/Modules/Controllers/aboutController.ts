module AcademicMarketplace.Controllers
{
    export class AboutController
    {
        static $inject = ['$scope'];

        constructor(
            private $scope
        )
        {
            $scope.am = this;
        }
    }
}
