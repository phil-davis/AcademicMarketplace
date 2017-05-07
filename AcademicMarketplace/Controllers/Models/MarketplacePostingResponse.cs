using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using T4TS;

namespace AcademicMarketplace.Controllers.Models
{
    [TypeScriptInterface]
    public class MarketplacePostingResponse
    {
        public int PostId { get; set; }
        public string PostTitle { get; set; }
        public string PostContent { get; set; }
        public DateTime PostDate { get; set; }
        public int PostedBy { get; set; }
        public DateTime CompletedDate { get; set; }
        public int CompletedBy { get; set; }
        public bool Active { get; set; }
    }
}