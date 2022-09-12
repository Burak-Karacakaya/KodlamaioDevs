using Application.Services.Repositories;
using Core.CrossCuttingConcerns.Exceptions;
using Core.Persistence.Paging;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.GithubAccounts.Rules
{
    public class GithubAccountBusinessRules
    {
        private readonly IGithubAccountRepository _githubAccountRepository;

        public GithubAccountBusinessRules(IGithubAccountRepository githubAccountRepository)
        {
            _githubAccountRepository = githubAccountRepository;
        }

        public async Task GithubUrlCanNotBeDuplicatedWhenInserted(string githubUrl)
        {
            IPaginate<GithubAccount> result = await _githubAccountRepository.GetListAsync(p => p.GithubUrl == githubUrl);
            if (result.Items.Any()) throw new BusinessException("Github Account exists.");
        }

        public async Task FindTheGithubAccountUrlYouWantToDelete(int id)
        {
            IPaginate<GithubAccount> result = await _githubAccountRepository.GetListAsync(p => p.Id == id);
            if (result.Items == null) throw new BusinessException("Github Account can not found.");
        }
    }
}
