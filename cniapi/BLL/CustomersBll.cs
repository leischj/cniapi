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
                stats.PaidInFull = db.Set<CustomerDAL>().Where(c => c.CurrentDue == 0).Count();
                stats.CurrentDue = db.Set<CustomerDAL>().Where(c => c.CurrentDue > 0).Count();
                stats.PastDue = db.Set<CustomerDAL>().Where(c => c.PastDue > 0).Count();
                stats.TotalPastDue = db.Set<CustomerDAL>().Select(t => t.PastDue ?? 0).Sum();
                stats.AveragePastDue = stats.TotalPastDue / stats.PastDue;
                stats.ErrorPayments = db.Set<PmtEntryDAL>().Where(c => c.Status == 99).Count();
                return stats;
            }
        }

        public IEnumerable<int?> ReadRoutes()
        {
            using (var db = DbDelegate())
            {
                return db.Set<CustomerDAL>().Select(r => r.Route).Distinct().ToList();
            }
        }

        public IEnumerable<string> ReadCities()
        {
            using (var db = DbDelegate())
            {
                return db.Set<CustomerDAL>().Select(r => r.BillCity).Distinct().ToList().OrderBy(s => s);
            }
        }

        public IEnumerable<string> ReadStates()
        {
            using (var db = DbDelegate())
            {
                return db.Set<CustomerDAL>().Select(r => r.BillState).Distinct().ToList().OrderBy(s => s);
            }
        }

        public IEnumerable<DateTime?> ReadBillDates()
        {
            using (var db = DbDelegate())
            {
                return db.Set<CustomerDAL>().Select(r => r.LateDate).Distinct().ToList();
            }
        }

        public int ReadRouteCustomerCount(int route)
        {
            using (var db = DbDelegate())
            {

                return db.Set<CustomerDAL>().Where(c => c.Route == route).Count();
      
            }

        }

        public int ReadBillingCycleCustomerCount(DateTime cycle)
        {
            using (var db = DbDelegate())
            {
                return db.Set<CustomerDAL>().Where(c => c.LateDate == cycle).Count();
            }
        }
        public int ReadCityCustomerCount(string city)
        {
            using (var db = DbDelegate())
            {

                return db.Set<CustomerDAL>().Where(c => c.BillCity.ToLower() == city.ToLower()).Count();
                
            }

        }

        public int ReadStateCustomerCount(string state)
        {
            using (var db = DbDelegate())
            {

                return db.Set<CustomerDAL>().Where(c => c.BillState.ToLower() == state.ToLower()).Count();
            }

        }

        public IEnumerable<ServiceUsage> ReadDepositsByService()
        {
            using (var db = DbDelegate())
            {
                var services = db.Set<ServiceDAL>().Select(r => r.SrvcType).Distinct().ToList().OrderBy(s => s);
                List<ServiceUsage> ret = new List<ServiceUsage>(services.Count());
                foreach (string service in services)
                {
                    var item = new ServiceUsage();
                    item.ServiceType = service;
                    var srvcOfType = db.Set<ServiceDAL>().Where(r => r.SrvcType == service);
                    item.Count = srvcOfType.Count();
                    item.DepositAmount = db.Set<ServiceDAL>().Where(r => r.SrvcType == service).Sum(r => r.DepositAmt);
                    ret.Add(item);
                }
                return ret;
            }
        }

        public IEnumerable<KeyValuePair<string, string> > ReadTotalPaymentsLast12Months()
        {
            using (var db = DbDelegate())
            {
                var ret = new List<KeyValuePair<string, string>>();
                var thisMonth = DateTime.Now;
                for (int i = 1; i <= 12; ++i)
                {
                    var past = thisMonth.AddMonths(i * -1);
                    var firstDayOfMonth = new DateTime(past.Year, past.Month, 1);
                    var lastDayOfMonth = firstDayOfMonth.AddMonths(1).AddSeconds(-1);
                    var sum = db.Set<PmtEntryDAL>().Where(r => r.ExportDate != null
                                                        && r.ExportDate >= firstDayOfMonth
                                                        && r.ExportDate <= lastDayOfMonth).Sum(r => r.PmtAmount);
                    var kv = new KeyValuePair<string, string>(firstDayOfMonth.ToString("MMM yyyy"), sum.ToString());
                    ret.Add(kv);
                }

                return ret;
            }

        }
    }
}