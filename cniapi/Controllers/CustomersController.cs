using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Collections.Generic;
using System.Net;
using System.Web.Http;
using System.Net.Http;
using cniapi.BLL;
using cniapi.Models;

namespace cniapi.Controllers
{
    [RoutePrefix("api/Customers")]
    public class CustomersController : ApiController
    {
        private readonly CustomersBll _customersBll;

        public CustomersController() : this(new CustomersBll())
        {

        }

        public CustomersController(CustomersBll customersBll)
        {
            _customersBll = customersBll;
        }

        [HttpGet]
        [Route("{id}")]
        public Customer Get(int id)
        {
            return _customersBll.Read(id);
        }

        [HttpGet]
        [Route("{id}/transactions")]
        public IEnumerable<History> GetTransactions(int id)
        {
            return _customersBll.ReadHistory(id);
        }

        [HttpGet]
        [Route("{id}/payments")]
        public IEnumerable<PmtEntry> GetPmtEntries(int id)
        {
            return _customersBll.ReadPmtEntries(id);
        }

        [HttpGet]
        [Route("{id}/services")]
        public IEnumerable<Service> GetServices(int id)
        {
            return _customersBll.ReadServices(id);
        }

        [HttpGet]
        [Route("stats")]
        public CustomerStats GetCustomerStats()
        {
            return _customersBll.ReadCustomerStats();
        }

        [HttpGet]
        [Route("routes")]
        public IEnumerable<int?> GetRoutes()
        {
            return _customersBll.ReadRoutes();
        }

        [HttpGet]
        [Route("cities")]
        public IEnumerable<string> GetCities()
        {
            return _customersBll.ReadCities();
        }

        [HttpGet]
        [Route("states")]
        public IEnumerable<string> GetStates()
        {
            return _customersBll.ReadStates();
        }

        [HttpGet]
        [Route("cycles")]
        public IEnumerable<DateTime?> GetCycles()
        {
            return _customersBll.ReadBillDates();
        }


        [HttpGet]
        [Route("route/{route}/count")]
        public int GetCustomersForRoute(int route)
        {
            return _customersBll.ReadRouteCustomerCount(route);
        }

        [HttpGet]
        [Route("cycles/{cycle}/count")]
        public int GetCustomersForCycles(DateTime cycle)
        {
            return _customersBll.ReadBillingCycleCustomerCount(cycle);
        }

        [HttpGet]
        [Route("city/{city}/count")]
        public int GetCustomersForCity(string city)
        {
            return _customersBll.ReadCityCustomerCount(city);
        }

        [HttpGet]
        [Route("state/{state}/count")]
        public int GetCustomersForState(string state)
        {
            return _customersBll.ReadStateCustomerCount(state);
        }

        [HttpGet]
        [Route("service-deposits")]
        public IEnumerable<ServiceUsage> GetServiceDeposits()
        {
            return _customersBll.ReadDepositsByService();
        }

        [HttpGet]
        [Route("payments-last-12-months")]
        public IEnumerable<KeyValuePair<string, string>> GetTotalPaymentsLast12Months()
        {
            return _customersBll.ReadTotalPaymentsLast12Months();
        }
    }
}