module AcademicMarketplace.Services {
    export class PostService {
        private httpService: any;

        constructor(
            $http: any
        ) {
            this.httpService = $http;
        }

        getAll(): any{
            return this.httpService({
                method: 'GET',
                url: '../GetAll/'
            });
        }

        addPost(newPost: Models.PostModel.IPostModel): any {
            return this.httpService({
                method: 'POST',
                url: '../AddPost/',
                data: JSON.stringify(newPost),
                contentType: "application/json"
            });
        }

        deletePost(id: number): any {
            return this.httpService({
                method: 'DELETE',
                url: '../DeletePost/' + id,
                //data: id.valueOf(),
            });
        }
    }
}
