using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity.Core;
using AutoMapper;
using cniapi.DAL;
using cniapi.Models;

namespace cniapi.BLL
{
    public class CustomersBll
    {
        protected DbContextDelegate DbDelegate;

        public CustomersBll(DbContextDelegate dbContextDelegate)
        {
            DbDelegate = dbContextDelegate;

        }

        public CustomersBll() : this(() => new CniAppContext())
        {

        }

        public Customer Read(int id)
        {
            using ( var db = DbDelegate())
            {
                CustomerDAL result = db.Set<CustomerDAL>().Find(id);
                if (result == null)
                    throw new ObjectNotFoundException("Could not find customer with id " + id);

                Customer customer = Mapper.Map<CustomerDAL, Customer>(result);
                return customer;
            }
        }

        public IEnumerable<History> ReadHistory(int id)
        {
            using (var db = DbDelegate())
            {
                IEnumerable<HistoryDAL> result = db.Set<HistoryDAL>().Where(c => c.CustNum == id).OrderByDescending(o => o.HistId);

                IEnumerable<History> returnList = Mapper.Map<IEnumerable<HistoryDAL>, IEnumerable<History>>(
                    (result ?? throw new InvalidOperationException()).ToList());

                return returnList;
            }
        }

        public IEnumerable<PmtEntry> ReadPmtEntries(int id)
        {
            using (var db = DbDelegate())
            {
                IEnumerable<PmtEntryDAL> result = db.Set<PmtEntryDAL>().Where(c => c.CustNum == id && c.Status != 0).OrderByDescending(o => o.CreateDate);

                IEnumerable<PmtEntry> returnList = Mapper.Map<IEnumerable<PmtEntryDAL>, IEnumerable<PmtEntry>>(
                    (result ?? throw new InvalidOperationException()).ToList());

                return returnList;
            }
        }

        public IEnumerable<Service> ReadServices(int id)
        {
            using (var db = DbDelegate())
            {
                IEnumerable<ServiceDAL> result = db.Set<ServiceDAL>().Where(c => c.CustNum == id).OrderBy(o => o.SrvcType);

                IEnumerable<Service> returnList = Mapper.Map<IEnumerable<ServiceDAL>, IEnumerable<Service>>(
                    (result ?? throw new InvalidOperationException()).ToList());

                return returnList;
            }
        }

        public CustomerStats ReadCustomerStats()
        {
            using (var db = DbDelegate())
            {
                var stats = new CustomerStats();

                stats.Active = db.Set<CustomerDAL>().Where(c => c.Status == "A").Count();
                stats.Total = db.Set<CustomerDAL>().Count();
                stats.WithEmail = db.Set<CustomerDAL>().Where(c => !string.IsNullOrEmpty(c.Email)).Count();
                stats.WithBankDraft = db.Set<CustomerDAL>().Where(c => c.DraftActive == "Y").Count();
                stats.WithBudgetPayments = db.Set<CustomerDAL>().Where(c => c.BudgetPymtAmt > 0).Count();
                return stats;
            }
        }

        public IEnumerable<int> ReadRoutes()
        {
            using (var db = DbDelegate())
            {

                var x = db.Set<CustomerDAL>().Select(r => new { r.Route }).Distinct();
                return null;
            }
        }
    }
}