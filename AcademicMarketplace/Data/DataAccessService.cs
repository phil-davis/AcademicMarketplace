using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AcademicMarketplace.Controllers.Models;
using AcademicMarketplace.Data.Model;

namespace AcademicMarketplace.Data
{
    interface IDataAccessService
    {
        User GetUser(int id);
        List<Post> GetAll();
        Post AddPost(PostModel post);
        string DeletePost(int id);
    }

    public class DataAccessService : IDataAccessService
    {
        private DBEntities _context;

        public DataAccessService()
        {
            _context = new DBEntities();
        }

        #region User

        public User GetUser(int id)
        {
            return _context.Users.FirstOrDefault(x => x.Id == id);
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