using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Web;
using AcademicMarketplace.Controllers.Models;
using AcademicMarketplace.Data.Model;

namespace AcademicMarketplace.Data
{
    interface IDataAccessService
    {
        AspNetUser GetUser(string id);
        List<Post> GetAll();
        Post AddPost(PostModel post);
        string DeletePost(int id);
    }

    public class DataAccessService : IDataAccessService
    {
        private DefaultConnectionEntities _context;

        public DataAccessService()
        {
            _context = new AcademicMarketplace.Data.Model.DefaultConnectionEntities();
        }

        #region User

        public AspNetUser GetUser(string id)
        {
            return _context.AspNetUsers.FirstOrDefault(x => x.Id.Equals(id));
        }

        #endregion

        #region Post

        public List<Post> GetAll()
        {
            return _context.Posts.ToList();
        }

        public Post AddPost(PostModel post)
        {
            var model = new Post()
            {
                Title = post.Title,
                Description = post.Description,
                PostedDate = DateTime.Now,
                PostedBy = post.PostedBy,
                Active = true
            };
            try
            {
                _context.Posts.Add(model);
                _context.SaveChanges();
                return model;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
            return null;
        }

        public string DeletePost(int id)
        {
            try
            {
                var post = _context.Posts.FirstOrDefault(x => x.Id == id);
                _context.Posts.Remove(post);
                _context.SaveChanges();
                return "success";
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
            return "fail";

        }
        #endregion

    }
}