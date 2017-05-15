module AcademicMarketplace.Controllers {
    export class HomeController {
        static $inject = ['$scope', 'userService'];
        private user: Models.UserModel.IUserModel;

        constructor(
            private $scope,
            private userService: Services.UserService
        ) {
            $scope.am = this;
            this.getCurrentUser();
            
        }

        private getCurrentUser() {
            this.userService.getUser(1).then((response) => {
                this.user = response.data;
            });
        }

    }
}
