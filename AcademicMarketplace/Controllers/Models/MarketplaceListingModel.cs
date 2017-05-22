using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AcademicMarketplace.Controllers.Models
{
    [T4TS.TypeScriptInterface(Module = "Models.MarketplaceListingModel")]
    public class MarketplaceListingModel
    {
        public int Id { get; set; }
        public string Workgroup { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Image { get; set; }

        public virtual WorkgroupModel Workgroup1 { get; set; }
        public virtual List<ServiceRequestModel> ServiceRequests { get; set; }
    }
}