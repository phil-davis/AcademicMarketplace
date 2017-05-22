module AcademicMarketplace.Controllers {
    export class WorkgroupController {
        static $inject = ['$scope', 'userService', 'workgroupService'];
        private user: Models.UserModel.IUserModel;

        newWorkgroup: {};
        allWorkgroups: Models.WorkgroupModel.IWorkgroupModel[];
        mockData: any;

        constructor(
            private $scope,
            private userService: Services.UserService,
            private workgroupService: Services.WorkgroupService
        ) {
            $scope.am = this;
            this.getCurrentUser();
            this.loadData();
        }

        private loadData(): any {
            this.workgroupService.getAll().then((response) => {
                this.allWorkgroups = response.data;
            });
        }

        public userInWorkgroup(workgroup: Models.WorkgroupModel.IWorkgroupModel) {
            if (workgroup.users.some(x => x.username == this.user.username)) {
                return true;
            }
            return false;
        }

        public addWorkgroup(workgroup: Models.WorkgroupModel.IWorkgroupModel) {
            if (workgroup.code.trim() !== "" && workgroup.name.trim() !== "") {
                this.workgroupService.addWorkgroup(workgroup).then(() => {
                    this.newWorkgroup = {};
                    this.loadData();
                });
            }
        }

        public deleteWorkgroup(workgroup: Models.WorkgroupModel.IWorkgroupModel) {
            this.workgroupService.deleteWorkgroup(workgroup).then(() => {
                this.loadData();
            });
        }

        private getCurrentUser() {
            this.userService.getCurrentUser().then((response) => {
                this.user = response.data;
            });
        }

    }
}
