using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using AcademicMarketplace.Business;
using AcademicMarketplace.Controllers.Models;
using Microsoft.AspNet.Identity;

namespace AcademicMarketplace.Controllers
{
    public class WorkgroupApiController : ApiController
    {
        private readonly IWorkgroupService _service;

        public WorkgroupApiController()
        {
            _service = new WorkgroupService();
        }

        [HttpGet]
        [Route("Workgroup/GetAll/")]
        public List<WorkgroupModel> GetAll()
        {
            return _service.GetAll();
        }

        [Authorize]
        [HttpPost]
        [Route("Workgroup/GetUserWorkgroups/")]
        public List<WorkgroupModel> GetUserWorkgroups(UserModel user)
        {
            return _service.GetUserWorkgroups(user);
        }

        [Authorize]
        [HttpPost]
        [Route("Workgroup/AddWorkgroup/")]
        public IHttpActionResult AddListing(WorkgroupModel model)
        {
            try
            {
                model.Users = new List<UserModel>();
                model.Users.Add(new UserModel
                {
                    Username = User.Identity.GetUserName()
                });
                _service.AddWorkgroup(model);
                return Ok();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
            return InternalServerError();
        }

        [Authorize]
        [HttpDelete]
        [Route("Workgroup/DeleteWorkgroup/{code?}")]
        public IHttpActionResult DeleteWorkgroup(string code)
        {
            try
            {
                _service.DeleteWorkgroup(code);
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