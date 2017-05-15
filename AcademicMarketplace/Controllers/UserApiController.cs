using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using AcademicMarketplace.Controllers.Models;
using AcademicMarketplace.Business;

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
        public UserModel Get(int id)
        {
            return _service.GetUser(id);
        }


        // DELETE: api/UserApi/5
        public void Delete(int id)
        {
        }
    }
}
