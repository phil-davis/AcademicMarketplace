using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AcademicMarketplace.Controllers.Models
{
    [T4TS.TypeScriptInterface(Module = "Models.BalanceModel")]

    public class BalanceModel
    {
        public string User { get; set; }
        public int? Balance { get; set; }

        public virtual UserModel User1 { get; set; }
    }
}