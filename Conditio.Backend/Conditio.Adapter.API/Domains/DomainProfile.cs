using AutoMapper;
using Conditio.Core.Domains;
using System;
using System.Collections.Generic;
using System.Text;

namespace Conditio.Adapter.API.Domains
{
    public class DomainProfile : Profile
    {
        public DomainProfile()
        {
            CreateMap<Domain, DomainDTO>();
        }
    }
}
