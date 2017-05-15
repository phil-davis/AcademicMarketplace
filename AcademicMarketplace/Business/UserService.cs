using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AcademicMarketplace.Controllers.Models;
using AcademicMarketplace.Data;

namespace AcademicMarketplace.Business
{
    public interface IUserService
    {
        UserModel GetUser(int id);
    }

    public class UserService : IUserService
    {
        private IDataAccessService _data;

        public UserService()
        {
            _data = new DataAccessService();
        }

        public UserModel GetUser(int id)
        {
            var data = _data.GetUser(1);
            var postsMade = new List<PostModel>();
            var postsCompleted = new List<PostModel>();
            foreach (var post in data.PostsMade)
            {
                postsMade.Add(new PostModel()
                {
                    Id = post.Id,
                    Title = post.Title,
                    Description = post.Description,
                    PostedDate = post.PostedDate,
                    PostedBy = post.PostedBy,
                    CompletedDate = post.CompletedDate,
                    CompletedBy = post.CompletedBy,
                    Active = post.Active
                });
            }
            foreach (var post in data.PostsCompleted)
            {
                postsCompleted.Add(new PostModel()
                {
                    Id = post.Id,
                    Title = post.Title,
                    Description = post.Description,
                    PostedDate = post.PostedDate,
                    PostedBy = post.PostedBy,
                    CompletedDate = post.CompletedDate,
                    CompletedBy = post.CompletedBy,
                    Active = post.Active
                });
            }
            return new UserModel()
            {
                Id = data.Id,
                Username = data.Username,
                FirstName = data.FirstName,
                LastName = data.LastName,
                Balance = new BalanceModel()
                {
                    UserId = data.Balance.UserId,
                    CreditBalance = data.Balance.Balance1
                },
                PostsMade = postsMade,
                PostsCompleted = postsCompleted,
            };
        }

        public UserModel AddUser(UserModel user)
        {
            return null;
        }

        public void Delete(int id)
        {
        }
    }
}