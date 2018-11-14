using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AutoMapper;
using cniapi.DAL;
using cniapi.Models;

namespace cniapi.BLL
{
    public static partial class AutoMapperConfiguration
    {
        public static void ConfigureCustomer(IMapperConfigurationExpression cfg)
        {
            cfg.CreateMap<CustomerDAL, Customer>()
                .ForMember(dal => dal.CustNum, dto => dto.MapFrom(d => d.CustNum))
                .ForMember(dal => dal.Route, dto => dto.MapFrom(d => d.Route))
                .ForMember(dal => dal.Account, dto => dto.MapFrom(d => d.Account))
                .ForMember(dal => dal.Sub, dto => dto.MapFrom(d => d.Sub))
                .ForMember(dal => dal.Cycle, dto => dto.MapFrom(d => d.Cycle))
                .ForMember(dal => dal.Status, dto => dto.MapFrom(d => d.Status))
                .ForMember(dal => dal.ActivationDate, dto => dto.MapFrom(d => d.ActivationDate))
                .ForMember(dal => dal.DriverLicense, dto => dto.MapFrom(d => d.DriverLicense))
                .ForMember(dal => dal.SocSecNum, dto => dto.MapFrom(d => d.SocSecNum))
                .ForMember(dal => dal.WorkPhone, dto => dto.MapFrom(d => d.WorkPhone))
                .ForMember(dal => dal.HomePhone, dto => dto.MapFrom(d => d.HomePhone))
                .ForMember(dal => dal.LastName, dto => dto.MapFrom(d => d.LastName))
                .ForMember(dal => dal.FirstName, dto => dto.MapFrom(d => d.FirstName))
                .ForMember(dal => dal.BillAddress1, dto => dto.MapFrom(d => d.BillAddress1))
                .ForMember(dal => dal.BillAddress2, dto => dto.MapFrom(d => d.BillAddress2))
                .ForMember(dal => dal.BillCity, dto => dto.MapFrom(d => d.BillCity))
                .ForMember(dal => dal.BillState, dto => dto.MapFrom(d => d.BillState))
                .ForMember(dal => dal.BillZip, dto => dto.MapFrom(d => d.BillZip))
                .ForMember(dal => dal.ServiceAddress, dto => dto.MapFrom(d => d.ServiceAddress))
                .ForMember(dal => dal.PaymentComment, dto => dto.MapFrom(d => d.PaymentComment))
                .ForMember(dal => dal.PastDue, dto => dto.MapFrom(d => d.PastDue))
                .ForMember(dal => dal.CurrentDue, dto => dto.MapFrom(d => d.CurrentDue))
                .ForMember(dal => dal.TotalDue, dto => dto.MapFrom(d => d.TotalDue))
                .ForMember(dal => dal.BudgetPymtAmt, dto => dto.MapFrom(d => d.BudgetPymtAmt))
                .ForMember(dal => dal.DraftActive, dto => dto.MapFrom(d => d.DraftActive))
                .ForMember(dal => dal.LateDate, dto => dto.MapFrom(d => d.LateDate))
                .ForMember(dal => dal.Email, dto => dto.MapFrom(d => d.Email))
                .ForMember(dal => dal.Password, dto => dto.MapFrom(d => d.Password));

        }
    }
}