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
        MarketplaceListingModel AddListing(MarketplaceListingModel newListing);
        MarketplaceListingModel EditListing(MarketplaceListingModel listing);
        string DeleteListing(int id);

        // WOrkgroups
        List<WorkgroupModel> GetAllWorkgroups();
        WorkgroupModel AddWorkgroup(WorkgroupModel group);
        WorkgroupModel EditWorkgroup(WorkgroupModel group);
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

            var newUser = Mapper.Map<UserModel>(result);
            if(result.Balance != null)
                newUser.Balance = Mapper.Map<BalanceModel>(result.Balance);
            else
                newUser.Balance = null;
            return newUser;
        }

        #endregion

        #region MarketplaceListings

        public List<MarketplaceListingModel> GetAllListings()
        {
            var listings = _context.MarketplaceListings.ToList();
            //var result = new List<MarketplaceListingModel>();
            var result = Mapper.Map<List<MarketplaceListingModel>>(listings);
            //if (result != null)
            //{
            //    foreach (var model in listings)
            //    {
            //        result.Add(Mapper.Map<MarketplaceListingModel>(model));
            //    }
            //}
            return result;
        }

        public MarketplaceListingModel AddListing(MarketplaceListingModel newListing)
        {
            var model = Mapper.Map<MarketplaceListing>(newListing);
            try
            {
                var modelListing = _context.MarketplaceListings.Add(model);
                _context.SaveChanges();
                return Mapper.Map<MarketplaceListingModel>(modelListing);
                //return newListing;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
            return null;
        }

        public MarketplaceListingModel EditListing(MarketplaceListingModel listing)
        {
            var model = Mapper.Map<MarketplaceListing>(listing);
            try
            {
                var entry = _context.MarketplaceListings.SingleOrDefault(x => x.Id == model.Id);
                if (entry != null)
                {
                    _context.Entry(entry).CurrentValues.SetValues(model);
                    _context.SaveChanges();
                    return Mapper.Map<MarketplaceListingModel>(entry);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
            
            return listing;
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
            var groups = _context.Workgroups
                .Include(x => x.AspNetUsers);
            var result = Mapper.Map<List<WorkgroupModel>>(groups);
            foreach (var item in result)
            {
                item.Users = Mapper.Map<List<UserModel>>(groups.FirstOrDefault(x => x.Code == item.Code).AspNetUsers);
            }
            return result;
        }

        public WorkgroupModel AddWorkgroup(WorkgroupModel group)
        {
            var model = Mapper.Map<Workgroup>(group);
            try
            {
                foreach (var user in group.Users)
                {
                    var newUser = _context.AspNetUsers.FirstOrDefault(x => x.UserName == user.Username);
                    model.AspNetUsers.Add(newUser);
                }
                
                _context.Workgroups.Add(model);
                _context.SaveChanges();
                return group;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
            return null;
        }

        public WorkgroupModel EditWorkgroup(WorkgroupModel group)
        {
            var model = Mapper.Map<WorkgroupModel>(group);
            try
            {
                var entry = _context.Workgroups.SingleOrDefault(x => x.Code == model.Code);
                if (entry != null)
                {
                    _context.Entry(entry).CurrentValues.SetValues(model);
                    _context.SaveChanges();
                    return Mapper.Map<WorkgroupModel>(entry);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }

            return group;
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
                cfg.CreateMap<MarketplaceListing, MarketplaceListingModel>().ForMember(x => x.Workgroup1, opt => opt.Ignore());

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