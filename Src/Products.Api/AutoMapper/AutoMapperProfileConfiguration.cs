using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Products.Api.AutoMapper
{
    public class AutoMapperProfileConfiguration : Profile
    {
        public AutoMapperProfileConfiguration() : this("Profile")
        {

        }

        public AutoMapperProfileConfiguration(string profileName) : base(profileName)
        {

        }

    }
}
