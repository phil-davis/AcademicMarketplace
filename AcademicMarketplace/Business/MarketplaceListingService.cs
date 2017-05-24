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
    public interface IMarketplaceListingService
    {
        List<MarketplaceListingModel> GetAll();
        MarketplaceListingModel AddListing(MarketplaceListingModel newListing);
        MarketplaceListingModel EditListing(MarketplaceListingModel listing);
        string DeleteListing(int id);
    }

    public class MarketplaceListingService : IMarketplaceListingService
    {
        private IDataAccessService _data;

        public MarketplaceListingService()
        {
            _data = new DataAccessService();
        }

        public List<MarketplaceListingModel> GetAll()
        {
            return _data.GetAllListings();
        }

        public MarketplaceListingModel AddListing(MarketplaceListingModel newListing)
        {
            return _data.AddListing(newListing);
        }

        public MarketplaceListingModel EditListing(MarketplaceListingModel listing)
        {
            return _data.EditListing(listing);
        }

        public string DeleteListing(int id)
        {
            try
            {
                var attempt = _data.DeleteListing(id);
                return attempt;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
            return "fail";
        }
    }
}