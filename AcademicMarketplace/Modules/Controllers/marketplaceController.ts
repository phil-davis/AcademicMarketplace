module AcademicMarketplace.Controllers {
    export class MarketplaceController{
        static $inject = ["$scope", "marketplaceListingService"];

        newListing: {};
        allListings: Models.MarketplaceListingModel.IMarketplaceListingModel[];
        mockData: any;

        constructor(
            private $scope,
            private marketplaceListingService: Services.MarketplaceListingService
        ) {
            $scope.am = this;
            this.loadData();
        }

        private loadData(): any {
            this.marketplaceListingService.getAll().then((response) => {
                this.allListings = response.data;
            });
        }

        public addListing(listing: Models.MarketplaceListingModel.IMarketplaceListingModel) {
            if (listing.name.trim() !== "" && listing.description.trim() !== "") {
                this.marketplaceListingService.addListing(listing).then(() => {
                    this.newListing = {};
                    this.loadData();
                });
            }
        }

        public deleteListing(id: number) {
            this.marketplaceListingService.deleteListing(id).then(() => {
                this.loadData();
            });
        }

    }
}
