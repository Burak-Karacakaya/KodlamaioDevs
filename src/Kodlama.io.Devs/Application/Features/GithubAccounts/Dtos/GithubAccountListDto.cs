﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.GithubAccounts.Dtos
{
    public class GithubAccountListDto
    {
        public int Id { get; set; }
        public string GithubUrl { get; set; }
        public string UserEmail { get; set; }
    }
}
