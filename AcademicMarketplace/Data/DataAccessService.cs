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
        UserModel GetUser(string id);
        List<MarketplaceListingModel> GetAll();
        MarketplaceListingModel AddListing(MarketplaceListingModel post);
        string DeleteListing(int id);
    }

    public class DataAccessService : IDataAccessService
    {
        private DefaultConnectionEntities _context;

        public DataAccessService()
        {
            _context = new AcademicMarketplace.Data.Model.DefaultConnectionEntities();
        }

        #region User

        public UserModel GetUser(string id)
        {
            var result = _context.AspNetUsers
                .Include(b => b.Balance)
                .Include(r => r.ServiceRequests)
                .Include(w => w.Workgroups).FirstOrDefault(x => x.Id == id);

            var serviceRequests = new List<ServiceRequestModel>();
            var workgroups = new List<WorkgroupModel>();
            var balance = new BalanceModel();

            if(result.ServiceRequests != null)
                foreach (var item in result.ServiceRequests)
                {
                    serviceRequests.Add(new ServiceRequestModel
                    {
                        Id = item.Id,
                        MarketListing = item.MarketListing,
                        RequestedBy = item.RequestedBy,
                        Status = item.Status
                    });
                }
            if(result.Workgroups != null)
                foreach (var item in result.Workgroups)
                {
                    workgroups.Add(new WorkgroupModel
                    {
                        Code = item.Code,
                        Name = item.Name,
                        Description = item.Description,
                    });
                }
            if (result.Balance != null)
            {
                balance.User = result.Id;
                balance.Balance = result.Balance.Balance1;
            }

            return new UserModel
            {
                Id = result.Id,
                Username = result.UserName,
                Email = result.Email,
                FirstName = result.FirstName,
                Surname = result.Surname,
                Location = result.Location,
                Balance = balance,
                ServiceRequests = serviceRequests,
                Workgroups = workgroups
            };
        }

        #endregion

        #region Post

        public List<MarketplaceListingModel> GetAll()
        {
            var listings = _context.MarketplaceListings.ToList();
            var result = new List<MarketplaceListingModel>();
            //var result = Mapper.Map<List<MarketplaceListingModel>>(_context.MarketplaceListings.ToList());
            if (result != null)
            {
                foreach (var model in listings)
                {
                    var item = Mapper.Map<MarketplaceListingModel>(model);
                    result.Add(item);
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

    }
}