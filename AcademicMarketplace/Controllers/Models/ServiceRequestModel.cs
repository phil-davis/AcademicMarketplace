using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AcademicMarketplace.Controllers.Models
{
    public class ServiceRequestModel
    {
        public int Id { get; set; }
        public int MarketListing { get; set; }
        public string RequestedBy { get; set; }
        public string Status { get; set; }

        public virtual UserModel RequestedBy1 { get; set; }
        public virtual MarketplaceListingModel MarketListing1 { get; set; }
    }
}