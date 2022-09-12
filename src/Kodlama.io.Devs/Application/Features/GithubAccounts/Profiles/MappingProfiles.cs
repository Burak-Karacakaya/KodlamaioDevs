using Application.Features.GithubAccounts.Dtos;
using Application.Features.GithubAccounts.Models;
using AutoMapper;
using Core.Persistence.Paging;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.GithubAccounts.Profiles
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<GithubAccount, GithubAccountListDto>()
                .ForMember(u => u.UserEmail, opt => opt.MapFrom(u => u.User.Email))
                .ReverseMap();

            CreateMap<IPaginate<GithubAccount>, GithubAccountListModel>().ReverseMap();
        }

    }
}
