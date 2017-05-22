using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Web;
using AcademicMarketplace.Controllers.Models;
using AcademicMarketplace.Data.Model;
using System.Data.Entity;
using System.Web.Mvc;
using Antlr.Runtime.Misc;
using AutoMapper;
using Microsoft.Ajax.Utilities;

namespace AcademicMarketplace.Data
{
    interface IDataAccessService
    {
        // User
        UserModel GetUser(string id);

        // Marketplace
        List<MarketplaceListingModel> GetAllListings();
        MarketplaceListingModel AddListing(MarketplaceListingModel post);
        string DeleteListing(int id);

        // WOrkgroups
        List<WorkgroupModel> GetAllWorkgroups();
        WorkgroupModel AddWorkgroup(WorkgroupModel post);
        string DeleteWorkgroup(string code);
    }

    public class DataAccessService : IDataAccessService
    {
        private DefaultConnectionEntities _context;

        public DataAccessService()
        {
            initializeMappings();
            _context = new DefaultConnectionEntities();
        }

        #region User

        public UserModel GetUser(string id)
        {
            var result = _context.AspNetUsers
                .Include(b => b.Balance)
                .Include(r => r.ServiceRequests)
                .Include(w => w.Workgroups).FirstOrDefault(x => x.Id == id);

            return Mapper.Map<UserModel>(result);
        }

        #endregion

        #region MarketplaceListings

        public List<MarketplaceListingModel> GetAllListings()
        {
            var listings = _context.MarketplaceListings.ToList();
            var result = new List<MarketplaceListingModel>();
            //var result = Mapper.Map<List<MarketplaceListingModel>>(_context.MarketplaceListings.ToList());
            if (result != null)
            {
                foreach (var model in listings)
                {
                    result.Add(Mapper.Map<MarketplaceListingModel>(model));
                }
            }
            return result;
        }

        public MarketplaceListingModel AddListing(MarketplaceListingModel post)
        {
            var model = Mapper.Map<MarketplaceListing>(post);
            try
            {
                _context.MarketplaceListings.Add(model);
                _context.SaveChanges();
                return post;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
            return null;
        }

        public string DeleteListing(int id)
        {
            try
            {
                var post = _context.MarketplaceListings.FirstOrDefault(x => x.Id == id);
                if (post != null)
                {
                    _context.MarketplaceListings.Remove(post);
                    _context.SaveChanges();
                    return "success";
                }
                else
                {
                    return "not found";
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
            return "fail";

        }
        #endregion

        #region Workgroups
        public List<WorkgroupModel> GetAllWorkgroups()
        {
            var groups = _context.Workgroups.ToList();
            var result = new List<WorkgroupModel>();
            if (result != null)
            {
                foreach (var group in groups)
                {
                    var item = Mapper.Map<WorkgroupModel>(group);
                    result.Add(item);
                }
            }
            return result;
        }

        public WorkgroupModel AddWorkgroup(WorkgroupModel post)
        {
            var model = Mapper.Map<Workgroup>(post);
            try
            {
                foreach (var user in post.Users)
                {
                    var newUser = _context.AspNetUsers.FirstOrDefault(x => x.UserName == user.Username);
                    model.AspNetUsers.Add(newUser);
                }
                
                _context.Workgroups.Add(model);
                _context.SaveChanges();
                return post;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
            return null;
        }

        public string DeleteWorkgroup(string code)
        {
            try
            {
                var group = _context.Workgroups.FirstOrDefault(x => x.Code == code);
                if (group != null)
                {
                    _context.Workgroups.Remove(group);
                    _context.SaveChanges();
                    return "success";
                }
                else
                {
                    return "not found";
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
            return "fail";

        }
        #endregion


        private void initializeMappings()
        {
            Mapper.Initialize(cfg =>
            {
                cfg.CreateMap<UserModel, AspNetUser>();
                cfg.CreateMap<AspNetUser, UserModel>();

                cfg.CreateMap<MarketplaceListingModel, MarketplaceListing>();
                cfg.CreateMap<MarketplaceListing, MarketplaceListingModel>();

                cfg.CreateMap<WorkgroupModel, Workgroup>();
                cfg.CreateMap<Workgroup, WorkgroupModel>();

                cfg.CreateMap<ServiceRequestModel, ServiceRequest>();
                cfg.CreateMap<ServiceRequest, ServiceRequestModel>();

                cfg.CreateMap<BalanceModel, Balance>();
                cfg.CreateMap<Balance, BalanceModel>();
            });
        }
    }
}