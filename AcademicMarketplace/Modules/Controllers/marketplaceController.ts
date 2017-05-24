module AcademicMarketplace.Controllers {
    export class MarketplaceController{
        static $inject = ["$scope", "userService", "marketplaceListingService"];
        private user: Models.UserModel.IUserModel;
        private viewingListingInfo = false;
        private editingListingInfo = false;

        private newListing: Models.MarketplaceListingModel.IMarketplaceListingModel;
        private currentListing: Models.MarketplaceListingModel.IMarketplaceListingModel;
        private allListings: Models.MarketplaceListingModel.IMarketplaceListingModel[];
        
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

        /* Startup Functions */
        private loadData(): any {
            this.userService.getCurrentUser().then((response) => {
                this.user = response.data;
            });
            this.marketplaceListingService.getAll().then((response) => {
                this.allListings = response.data;
            });
        }

        /* Listing Functions */
        public addListing(listing: Models.MarketplaceListingModel.IMarketplaceListingModel) {
            if (listing.name != null && listing.description != null) {
                if (listing.name.trim() !== "" && listing.description.trim() !== "") {
                    this.marketplaceListingService.addListing(listing).then(() => {
                        this.newListing = { id: null, workgroup: null, name: null, description: null, image: null, workgroup1: null, serviceRequests: null };
                        this.loadData();
                    });
                }
            }
        }

        public showListing(listing: Models.MarketplaceListingModel.IMarketplaceListingModel) {
            this.currentListing = listing;
            this.viewingListingInfo = true;
            this.editingListingInfo = false;
        }

        public showAllListings() {
            this.viewingListingInfo = false;
            this.editingListingInfo = false;
            this.newListing = { id: null, workgroup: null, name: null, description: null, image: null, workgroup1: null, serviceRequests: null };
        }

        public editListing(listing: Models.MarketplaceListingModel.IMarketplaceListingModel) {
            this.editingListingInfo = true;
            this.newListing = listing;
        }

        public cancelEditListing() {
            this.editingListingInfo = false;
            this.newListing = { id: null, workgroup: null, name: null, description: null, image: null, workgroup1: null, serviceRequests: null };
        }

        public saveEdit(listing: Models.MarketplaceListingModel.IMarketplaceListingModel) {
            this.marketplaceListingService.editListing(listing).then(() => {
                this.cancelEditListing();
                this.loadData();
            });
        }

        public deleteListing(id: number) {
            this.marketplaceListingService.deleteListing(id).then(() => {
                this.loadData();
            });
        }


        /* User Check Functions */
        private getCurrentUser() {
            this.userService.getCurrentUser().then((response) => {
                this.user = response.data;
            });
        }

        public userInWorkgroup(listing: Models.MarketplaceListingModel.IMarketplaceListingModel) {
            if (this.user) {
                if (this.user.workgroups.some(x => x.marketplaceListings.some(x => x.name == listing.name))) {
                    return true;
                }
            }
            return false;
        }
    }
}
