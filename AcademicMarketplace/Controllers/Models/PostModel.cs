using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AcademicMarketplace.Controllers.Models
{
    [T4TS.TypeScriptInterface(Module = "Models.PostModel")]
    public class PostModel
    {
        public int? Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime PostedDate { get; set; }
        public string PostedBy { get; set; }
        public DateTime? CompletedDate { get; set; }
        public string CompletedBy { get; set; }
        public bool Active { get; set; }
        public virtual UserModel CompletedByUser { get; set; }
        public virtual UserModel PostedByUser { get; set; }
    }
}