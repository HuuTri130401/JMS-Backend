﻿using Domain.BaseEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Models.UserModels
{
    public class UserSearch : BaseSearch
    {
        public string? Ids { get; set; }
        public string? Roles { get; set; }
    }
}
