using AutoMapper;
using Conditio.Core.Assets;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Conditio.Adapter.API.Assets
{
    public class AssetProfile : Profile
    {
        public AssetProfile()
        {
            CreateMap<Asset, AssetWithSourcesDTO>();
            CreateMap<Asset, AssetWithTermsDTO>()
                .ForMember(dto => dto.Source, m => m.MapFrom(a => a.Sources.FirstOrDefault()));

            CreateMap<AssetSource, AssetSourceDTO>();
            CreateMap<AssetSource, AssetSourceWithTermsDTO>();
        }
    }
}
