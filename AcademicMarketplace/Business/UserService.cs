using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AcademicMarketplace.Controllers.Models;
using AcademicMarketplace.Data;

namespace AcademicMarketplace.Business
{
    public interface IUserService
    {
        UserModel GetUser(string id);
    }

    public class UserService : IUserService
    {
        private IDataAccessService _data;

        public UserService()
        {
            _data = new DataAccessService();
        }

        public UserModel GetUser(string id)
        {
            return _data.GetUser(id);
        }

        public void Delete(int id)
        {
        }
    }
}