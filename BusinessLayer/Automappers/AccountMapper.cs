using AutoMapper;
using BusinessLayer.Models.Requests;
using BusinessLayer.Models.Responses;
using DataAccessLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Automappers
{
    public class AccountMapper : Profile
    {
        public AccountMapper()
        {
            //chìu từ trái sang phải
            CreateMap<SystemAccount, SystemAccountRequest>().ReverseMap();
            CreateMap<SystemAccount, SystemAccountResponse>().ReverseMap();
        }
    }
}
