module AcademicMarketplace.Services {
    export class MarketplaceListingService {
        static $inject = ["$http"];

        private httpService: any;

        constructor(
            $http: any
        ) {
            this.httpService = $http;
        }

        getAll(): any{
            return this.httpService({
                method: "GET",
                url: "../Marketplace/GetAll/"
            });
        }

        addListing(newListing: Models.MarketplaceListingModel.IMarketplaceListingModel): any {
            return this.httpService({
                method: "POST",
                url: "../Marketplace/AddListing/",
                data: JSON.stringify(newListing),
                contentType: "application/json"
            });
        }

        editListing(listing: Models.MarketplaceListingModel.IMarketplaceListingModel): any {
            return this.httpService({
                method: "PUT",
                url: "../Marketplace/EditListing/",
                data: JSON.stringify(listing),
                contentType: "application/json"
            });
        }

        deleteListing(id: number): any {
            return this.httpService({
                method: "DELETE",
                url: "../Marketplace/DeleteListing/" + id,
                //data: id.valueOf(),
            });
        }
    }
}
