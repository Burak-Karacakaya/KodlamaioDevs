﻿using Application.Features.ProgrammingTechnologies.Commands.CreateProgrammingTechnology;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.GithubAccounts.Commands.CreateGithubAccount
{
    public class CreateGithubAccountCommandValidator : AbstractValidator<CreateGithubAccountCommand>
    {
        public CreateGithubAccountCommandValidator()
        {
            RuleFor(g => g.GithubUrl).NotEmpty();
        }
    }
}
