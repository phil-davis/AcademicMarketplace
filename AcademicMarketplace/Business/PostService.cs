using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Http.Results;
using AcademicMarketplace.Controllers.Models;
using AcademicMarketplace.Data;
using Microsoft.Ajax.Utilities;

namespace AcademicMarketplace.Business
{
    public interface IPostService
    {
        List<PostModel> GetAll();
        PostModel AddPost(PostModel post);
        string DeletePost(int id);
    }

    public class PostService : IPostService
    {
        private IDataAccessService _data;

        public PostService()
        {
            _data = new DataAccessService();
        }

        public List<PostModel> GetAll()
        {
            var newList = new List<PostModel>();
            var data = _data.GetAll();
            var postedBy = new UserModel();
            var completedBy = new UserModel();
            foreach (var post in data)
            {
                if (post.PostedByUser != null)
                {
                    postedBy.Id = post.PostedBy;
                    postedBy.Username = post.PostedByUser.Username;
                    postedBy.FirstName = post.PostedByUser.FirstName;
                    postedBy.LastName = post.PostedByUser.LastName;
                    postedBy.Admin = post.PostedByUser.Admin;
                }
                if (post.CompletedByUser != null)
                {
                    completedBy.Id = post.PostedBy;
                    completedBy.Username = post.PostedByUser.Username;
                    completedBy.FirstName = post.PostedByUser.FirstName;
                    completedBy.LastName = post.PostedByUser.LastName;
                    completedBy.Admin = post.PostedByUser.Admin;
                }

                newList.Add(new PostModel()
                {
                    Id = post.Id,
                    Title = post.Title,
                    Description = post.Description,
                    PostedBy = post.PostedBy,
                    PostedDate = post.PostedDate,
                    CompletedBy = post.CompletedBy,
                    CompletedDate = post.CompletedDate,
                    PostedByUser = postedBy,
                    CompletedByUser = completedBy

                });
            }
            return newList;
        }

        public PostModel AddPost(PostModel post)
        {
            var data = _data.AddPost(post);
            var postedBy = new UserModel();
            var completedBy = new UserModel();

            if (data.PostedByUser != null)
            {
                postedBy.Id = data.PostedBy;
                postedBy.Username = data.PostedByUser.Username;
                postedBy.FirstName = data.PostedByUser.FirstName;
                postedBy.LastName = data.PostedByUser.LastName;
                postedBy.Admin = data.PostedByUser.Admin;
            }
            if (data.CompletedByUser != null)
            {
                completedBy.Id = data.CompletedBy;
                completedBy.Username = data.CompletedByUser.Username;
                completedBy.FirstName = data.CompletedByUser.FirstName;
                completedBy.LastName = data.CompletedByUser.LastName;
                completedBy.Admin = data.CompletedByUser.Admin;
            }
            return new PostModel()
            {
                Id = data.Id,
                Title = data.Title,
                Description = data.Description,
                PostedBy = data.PostedBy,
                PostedDate = data.PostedDate,
                CompletedBy = data.CompletedBy,
                CompletedDate = data.CompletedDate,
                PostedByUser = postedBy,
                CompletedByUser = completedBy
            };
        }

        public string DeletePost(int id)
        {
            try
            {
                _data.DeletePost(id);
                return "success";
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
            return "fail";
        }
    }
}