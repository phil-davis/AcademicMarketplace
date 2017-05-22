using System;
using System.Web.Http;
using AcademicMarketplace.Controllers.Models;
using AcademicMarketplace.Business;
using Microsoft.AspNet.Identity;

namespace AcademicMarketplace.Controllers
{
    public class UserApiController : ApiController
    {
        private IUserService _service;
        public UserApiController()
        {
            _service = new UserService();
        }

        [HttpGet]
        [Route("GetUser/{id?}")]
        public UserModel Get(string id)
        {
            return _service.GetUser(id);
        }

        [HttpGet]
        [Route("GetCurrentUser/")]
        public UserModel GetCurrentUser()
        {
            try
            {
                return _service.GetUser(User.Identity.GetUserId());
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
            
        }


        // DELETE: api/UserApi/5
        public void Delete(int id)
        {
        }
    }
}
