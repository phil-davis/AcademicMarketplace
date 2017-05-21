using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AcademicMarketplace.Data.Model;

namespace AcademicMarketplace.Controllers.Models
{
    public class WorkgroupModel
    {
        public string Code { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        public virtual List<MarketplaceListingModel> MarketplaceListings { get; set; }
        public virtual List<UserModel> Users { get; set; }
    }
}