using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AutoMapper;

namespace cniapi.BLL
{
    public static partial class AutoMapperConfiguration
    {
        public static void Configure()
        {
            Mapper.Initialize(cfg =>
            {
                ConfigureCustomer(cfg);
            });
        }
    }
}