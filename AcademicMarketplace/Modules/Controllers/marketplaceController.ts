module AcademicMarketplace.Controllers {
    export class MarketplaceController{
        static $inject = ['$scope'];

        mockData: any;

        constructor(
            private $scope
        ) {
            $scope.am = this;

            this.mockData = this.loadData();


        }

        private loadData(): any {
            return [
                { postId: 1, postTitle: "Data Mining Assistant", postContent: "Need assistant to perform data mining research.", postDate: "March 2017", postedBy: "James" },
                { postId: 2, postTitle: "Usability testing assistant", postContent: "Assistant is required to help in the completion of user testing.", postDate: "April 2017", postedBy: "Steve"  },
                { postId: 3, postTitle: "Marine Biologist needed", postContent: "A marine biologist is needed to help with cross-department research involving marine biology and technology", postDate: "April 2017", postedBy: "Mary"  }
            ];
        }

    }
}
