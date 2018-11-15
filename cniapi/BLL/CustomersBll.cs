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
    }
}