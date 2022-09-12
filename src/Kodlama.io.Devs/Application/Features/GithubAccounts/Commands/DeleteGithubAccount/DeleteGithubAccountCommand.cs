using Application.Features.GithubAccounts.Dtos;
using Application.Features.GithubAccounts.Rules;
using Application.Features.ProgrammingTechnologies.Dtos;
using Application.Features.ProgrammingTechnologies.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.GithubAccounts.Commands.DeleteGithubAccount
{
    public class DeleteGithubAccountCommand : IRequest<DeletedGithubAccountDto>
    {
        public int Id { get; set; }

        public class DeleteGithubAccountCommandHandler : IRequestHandler<DeleteGithubAccountCommand, DeletedGithubAccountDto>
        {
            private readonly IGithubAccountRepository _githubAccountRepository;
            private readonly IMapper _mapper;
            private readonly GithubAccountBusinessRules _githubAccountBusinessRules;

            public DeleteGithubAccountCommandHandler(IGithubAccountRepository githubAccountRepository, IMapper mapper, GithubAccountBusinessRules githubAccountBusinessRules)
            {
                _githubAccountRepository = githubAccountRepository;
                _mapper = mapper;
                _githubAccountBusinessRules = githubAccountBusinessRules;
            }

            public async Task<DeletedGithubAccountDto> Handle(DeleteGithubAccountCommand request, CancellationToken cancellationToken)
            {
                await _githubAccountBusinessRules.FindTheGithubAccountUrlYouWantToDelete(request.Id);

                GithubAccount findDataForDeletedGithubAccount = await _githubAccountRepository.GetAsync(p => p.Id == request.Id);
                GithubAccount mappedGithubAccount = _mapper.Map<GithubAccount>(findDataForDeletedGithubAccount);
                GithubAccount deletedGithubAccount = await _githubAccountRepository.DeleteAsync(mappedGithubAccount);
                DeletedGithubAccountDto deletedGithubAccountDto = _mapper.Map<DeletedGithubAccountDto>(deletedGithubAccount);

                return deletedGithubAccountDto;
            }
        }
    }
}
