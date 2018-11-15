using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace cniapi.DAL
{
    public delegate DbContext DbContextDelegate();

    public class CniAppContext : DbContext
    {
        public CniAppContext() : base("name=CniAppContext")
        {

        }

        public virtual DbSet<CustomerDAL> Customers { get; set; }

        public virtual DbSet<HistoryDAL> History { get; set; }
    }
}