module AcademicMarketplace.Services {
    export class UserService {
        static $inject = ["$http"];

        private httpService: any;
        
        constructor(
            $http: any
        ) {
            this.httpService = $http;
        }

        getUser(userId: number): any {
            return this.httpService({
                method: "GET",
                url: "../GetUser/" + userId
            });
        }

        getCurrentUser(): any {
            return this.httpService({
                method: "GET",
                url: "../GetCurrentUser/"
            });
        }
    }
}
