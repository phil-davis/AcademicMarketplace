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
        [Route("Marketplace/GetAll/")]
        public List<MarketplaceListingModel> GetAll()
        {
            return _service.GetAll();
        }

        [Authorize]
        [HttpPost]
        [Route("Marketplace/AddListing/")]
        public IHttpActionResult AddListing(MarketplaceListingModel listing)
        {
            try
            {
                _service.AddListing(listing);
                return Ok();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
            return InternalServerError();
        }

        [Authorize]
        [HttpPut]
        [Route("Marketplace/EditListing/")]
        public MarketplaceListingModel EditListing(MarketplaceListingModel listing)
        {
            try
            {
                var edited = _service.EditListing(listing);
                return edited;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
            return listing;
        }

        [Authorize]
        [HttpDelete]
        [Route("Marketplace/DeleteListing/{id?}")]
        public IHttpActionResult DeleteListing(int id)
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
