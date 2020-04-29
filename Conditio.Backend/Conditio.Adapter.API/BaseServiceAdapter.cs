using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;

namespace Conditio.Adapter.API
{
    public class BaseServiceAdapter
    {
        public readonly IMapper Mapper;

        public BaseServiceAdapter(IMapper mapper)
        {
            Mapper = mapper;
        }
    }
}
