using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AcademicMarketplace.Controllers.Models
{
    [T4TS.TypeScriptInterface(Module = "Models.BalanceModel")]

    public class BalanceModel
    {
        public string UserId { get; set; }
        public int? CreditBalance { get; set; }
    }
}