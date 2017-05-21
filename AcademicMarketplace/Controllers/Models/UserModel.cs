using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AcademicMarketplace.Data.Model;

namespace AcademicMarketplace.Controllers.Models
{
    [T4TS.TypeScriptInterface(Module = "Models.UserModel")]

    public class UserModel
    {
        public string Id { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }
        public string FirstName { get; set; }
        public string Surname { get; set; }
        public string Location { get; set; }
        public virtual BalanceModel Balance { get; set; }
        public virtual List<ServiceRequestModel> ServiceRequests { get; set; }
        public virtual List<WorkgroupModel> Workgroups { get; set; }
    }
}