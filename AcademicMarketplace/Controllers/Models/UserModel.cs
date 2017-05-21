using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AcademicMarketplace.Controllers.Models
{
    [T4TS.TypeScriptInterface(Module = "Models.UserModel")]

    public class UserModel
    {
        public string Id { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }
        public virtual BalanceModel Balance { get; set; }
        public virtual List<PostModel> PostsMade { get; set; }
        public virtual List<PostModel> PostsCompleted { get; set; }
    }
}