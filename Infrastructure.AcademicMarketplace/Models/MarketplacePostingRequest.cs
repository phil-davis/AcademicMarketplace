using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Infrastructure.AcademicMarketplace.Models
{
    public class MarketplacePostingRequest
    {
        public int PostId { get; set; }
        public string PostTitle { get; set; }
        public int PostedBy { get; set; }

    }
}