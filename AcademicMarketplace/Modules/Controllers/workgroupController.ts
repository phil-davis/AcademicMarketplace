module AcademicMarketplace.Controllers {
    export class WorkgroupController {
        static $inject = ['$scope', 'workgroupService'];

        newWorkgroup: {};
        allWorkgroups: Models.WorkgroupModel.IWorkgroupModel[];
        mockData: any;

        constructor(
            private $scope,
            private workgroupService: Services.WorkgroupService
        ) {
            $scope.am = this;
            this.loadData();
        }

        private loadData(): any {
            this.workgroupService.getAll().then((response) => {
                this.allWorkgroups = response.data;
            });
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

    }
}
