using AutoMapper;
using Conditio.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Conditio.Adapter.API.Entities
{
    public class EntityProfile : Profile
    {
        public EntityProfile()
        {
            CreateMap<Entity, EntityDTO>();
            CreateMap<Entity, EntityWithTermsDTO>();
            CreateMap<EntitySource, EntityDTO>();
            CreateMap<EntitySource, EntityWithTermsDTO>();
            CreateMap<Terms, TermsDTO>();
        }
    }
}
