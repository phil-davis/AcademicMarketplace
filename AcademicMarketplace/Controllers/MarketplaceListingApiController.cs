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
    public class MarketplaceListingApiController : ApiController
    {
        private readonly IMarketplaceListingService _service;

        public MarketplaceListingApiController()
        {
            _service = new MarketplaceListingService();
        }

        [HttpGet]
        [Route("GetAll/")]
        public List<MarketplaceListingModel> GetAll()
        {
            return _service.GetAll();
        }

        [HttpPost]
        [Route("AddPost/")]
        public IHttpActionResult AddPost(MarketplaceListingModel post)
        {
            try
            {
                _service.AddListing(post);
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
                _service.DeleteListing(id);
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
