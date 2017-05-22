using System;
using System.Collections.Generic;
using AcademicMarketplace.Controllers.Models;
using AcademicMarketplace.Data;
using Microsoft.AspNet.Identity;


namespace AcademicMarketplace.Business
{

    public interface IWorkgroupService
    {
        List<WorkgroupModel> GetAll();
        WorkgroupModel AddWorkgroup(WorkgroupModel model);
        string DeleteWorkgroup(string code);
    }

    public class WorkgroupService : IWorkgroupService
    {
        private IDataAccessService _data;

        public WorkgroupService()
        {
            _data = new DataAccessService();
        }

        public List<WorkgroupModel> GetAll()
        {
            return _data.GetAllWorkgroups();
        }

        public WorkgroupModel AddWorkgroup(WorkgroupModel model)
        {
            return _data.AddWorkgroup(model);
        }

        public string DeleteWorkgroup(string code)
        {
            try
            {
                var attempt = _data.DeleteWorkgroup(code);
                return attempt;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
            return "fail";
        }
    }
}