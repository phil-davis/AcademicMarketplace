module AcademicMarketplace.Services {
    export class WorkgroupService {
        private httpService: any;

        constructor(
            $http: any
        ) {
            this.httpService = $http;
        }

        getAll(): any {
            return this.httpService({
                method: 'GET',
                url: '../Workgroup/GetAll/'
            });
        }

        addWorkgroup(model: Models.WorkgroupModel.IWorkgroupModel): any {
            return this.httpService({
                method: 'POST',
                url: '../Workgroup/AddWorkgroup/',
                data: JSON.stringify(model),
                contentType: "application/json"
            });
        }

        deleteWorkgroup(model: Models.WorkgroupModel.IWorkgroupModel): any {
            return this.httpService({
                method: 'DELETE',
                url: '../Workgroup/DeleteWorkgroup/' + model.code,
                //data: JSON.stringify(model),
                //contentType: "application/json"
            });
        }
    }
}
