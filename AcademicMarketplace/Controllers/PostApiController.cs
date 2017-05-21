using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using AcademicMarketplace.Controllers.Models;
using AcademicMarketplace.Business;
using Microsoft.AspNet.Identity;

namespace AcademicMarketplace.Controllers
{
    public class PostApiController : ApiController
    {
        private readonly IPostService _service;

        public PostApiController()
        {
            _service = new PostService();
        }

        [HttpGet]
        [Route("GetAll/")]
        public List<PostModel> GetAll()
        {
            return _service.GetAll();
        }

        [HttpPost]
        [Route("AddPost/")]
        public IHttpActionResult AddPost(PostModel post)
        {
            post.PostedBy = User.Identity.GetUserId();
            try
            {
                _service.AddPost(post);
                return Ok();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
            return InternalServerError();
        }

        [HttpDelete]
        [Route("DeletePost/{id?}")]
        public IHttpActionResult DeletePost(int id)
        {
            try
            {
                _service.DeletePost(id);
                return Ok();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
            return InternalServerError();
        }
    }
}
