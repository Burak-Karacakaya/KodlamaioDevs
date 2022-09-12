using Application.Features.GithubAccounts.Models;
using Application.Features.ProgrammingTechnologies.Models;
using Application.Features.ProgrammingTechnologies.Queries.GetListProgrammingTechnology;
using Application.Services.Repositories;
using AutoMapper;
using Core.Application.Requests;
using Core.Persistence.Paging;
using Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.GithubAccounts.Queries.GetListGithubAccount
{
    public class GetListGithubAccountQuery : IRequest<GithubAccountListModel>
    {
        public PageRequest PageRequest { get; set; }

        public class GetListGithubAccountQueryHandler : IRequestHandler<GetListGithubAccountQuery, GithubAccountListModel>
        {
            private readonly IGithubAccountRepository _githubAccountRepository;
            private readonly IMapper _mapper;

            public GetListGithubAccountQueryHandler(IGithubAccountRepository githubAccountRepository, IMapper mapper)
            {
                _githubAccountRepository = githubAccountRepository;
                _mapper = mapper;
            }

            public async Task<GithubAccountListModel> Handle(GetListGithubAccountQuery request, CancellationToken cancellationToken)
            {
                IPaginate<GithubAccount> githubAccounts = await _githubAccountRepository.GetListAsync(include:
                    p => p.Include(u => u.User),
                    index: request.PageRequest.Page,
                    size: request.PageRequest.PageSize);

                GithubAccountListModel mappedGithubAccountListModel = _mapper.Map<GithubAccountListModel>(githubAccounts);

                return mappedGithubAccountListModel;
            }

            
        }
    }
}
