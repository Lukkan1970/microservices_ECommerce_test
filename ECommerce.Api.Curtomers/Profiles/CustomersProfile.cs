﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ECommerce.Api.Curtomers.Profiles
{
    public class CustomersProfile : AutoMapper.Profile
    {
        public CustomersProfile()
        {
            CreateMap<Db.Customer, Models.Customer>();
        }
    }
}
