module AcademicMarketplace.Controllers {
    export class MarketplaceController{
        static $inject = ["$scope", "userService", "marketplaceListingService"];
        private user: Models.UserModel.IUserModel;

        newListing: Models.WorkgroupModel.IWorkgroupModel;
        allListings: Models.MarketplaceListingModel.IMarketplaceListingModel[];
        mockData: any;

        constructor(
            private $scope,
            private userService: Services.UserService,
            private marketplaceListingService: Services.MarketplaceListingService
        ) {
            $scope.am = this;
            //this.getCurrentUser();
            this.loadData();
        }

        private loadData(): any {
            this.userService.getCurrentUser().then((response) => {
                this.user = response.data;
            });
            this.marketplaceListingService.getAll().then((response) => {
                this.allListings = response.data;
            });
        }

        public addListing(listing: Models.MarketplaceListingModel.IMarketplaceListingModel) {
            if (listing.name != null && listing.description != null) {
                if (listing.name.trim() !== "" && listing.description.trim() !== "") {
                    this.marketplaceListingService.addListing(listing).then(() => {
                        this.newListing = {code: null, name: null, description: null, marketplaceListings: null, users: null};
                        this.loadData();
                    });
                }
            }
        }

        public userInWorkgroup(listing: Models.MarketplaceListingModel.IMarketplaceListingModel) {
            if (this.user) {
                if (this.user.workgroups.some(x => x.marketplaceListings.some(x => x.name == listing.name))) {
                    return true;
                }
            }
            return false;
        }

        public deleteListing(id: number) {
            this.marketplaceListingService.deleteListing(id).then(() => {
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
