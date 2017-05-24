module AcademicMarketplace.Controllers {
    export class WorkgroupController {
        static $inject = ["$scope", "userService", "workgroupService"];
        private user: Models.UserModel.IUserModel;
        private viewingWorkgroupInfo = false;
        private editingWorkgroupInfo = false;

        newWorkgroup: {};
        currentWorkgroup: Models.WorkgroupModel.IWorkgroupModel;
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

        /* Startup Functions */
        private loadData(): any {
            this.workgroupService.getAll().then((response) => {
                this.allWorkgroups = response.data;
            });
        }

        

        /* Workgroup Functions */
        public addWorkgroup(workgroup: Models.WorkgroupModel.IWorkgroupModel) {
            if (workgroup.code.trim() !== "" && workgroup.name.trim() !== "") {
                this.workgroupService.addWorkgroup(workgroup).then(() => {
                    this.newWorkgroup = {};
                    this.loadData();
                });
            }
        }

        public showWorkgroup(group: Models.WorkgroupModel.IWorkgroupModel) {
            this.currentWorkgroup = group;
            this.viewingWorkgroupInfo = true;
            this.editingWorkgroupInfo = false;
        }

        public showAllWorkgroups() {
            this.viewingWorkgroupInfo = false;
            this.editingWorkgroupInfo = false;
            this.newWorkgroup = {};
        }

        public editWorkgroup(group: Models.WorkgroupModel.IWorkgroupModel) {
            this.editingWorkgroupInfo = true;
            this.newWorkgroup = angular.copy(group);
        }

        public cancelEditWorkgroup() {
            this.editingWorkgroupInfo = false;
            this.newWorkgroup = {};
        }

        public saveEdit(group: Models.WorkgroupModel.IWorkgroupModel) {
            this.workgroupService.editWorkgroup(group).then(() => {
                this.currentWorkgroup = group;
                this.cancelEditWorkgroup();
                this.loadData();
            });
        }

        public deleteWorkgroup(workgroup: Models.WorkgroupModel.IWorkgroupModel) {
            this.workgroupService.deleteWorkgroup(workgroup).then(() => {
                this.loadData();
            });
        }

        /* User Check Functions */
        private getCurrentUser() {
            this.userService.getCurrentUser().then((response) => {
                this.user = response.data;
            });
        }

        public userInWorkgroup(workgroup: Models.WorkgroupModel.IWorkgroupModel) {
            if (workgroup.users.some(x => x.username == this.user.username)) {
                return true;
            }
            return false;
        }

        public isAdmin() {
            return this.user.admin;
        }

    }
}
