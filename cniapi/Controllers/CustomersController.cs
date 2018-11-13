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
    }
}