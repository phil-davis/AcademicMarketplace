module AcademicMarketplace.Controllers {
    export class MarketplaceController{
        static $inject = ['$scope', 'postService'];

        newPost: {};
        allPosts: Models.PostModel.IPostModel[];
        mockData: any;

        constructor(
            private $scope,
            private postService: Services.PostService
        ) {
            $scope.am = this;
            this.loadData();
        }

        private loadData(): any {
            this.postService.getAll().then((response) => {
                this.allPosts = response.data;
            });
        }

        public addPost(post: Models.PostModel.IPostModel) {
            if (post.title.trim() !== "" && post.description.trim() !== "") {
                this.postService.addPost(post).then(() => {
                    this.newPost = {};
                    this.loadData();
                });
            }
        }

        public deletePost(id: number) {
            this.postService.deletePost(id).then(() => {
                this.loadData();
            });
        }

    }
}
