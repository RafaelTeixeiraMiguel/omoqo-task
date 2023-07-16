using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Common.Mapping
{
    public static class Mapping
    {
        private static readonly Lazy<IMapper> Lazy = new(() =>
        {
            MapperConfiguration config = new(cfg => { cfg.AddProfile<MappingProfile>(); });
            IMapper mapper = config.CreateMapper();
            return mapper;
        });

        public static IMapper Mapper => Lazy.Value;
    }
}
