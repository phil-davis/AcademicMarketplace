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
                {
                    postId: 1,
                    postTitle: "Post 1",
                    postContent: "Post 1 content"
                },
                {
                    postId: 2,
                    postTitle: "Post 2",
                    postContent: "Post 2 content"
                },
                {
                    postId: 3,
                    postTitle: "Post 3",
                    postContent: "Post 3 content"
                }
            ];
        }

    }
}
