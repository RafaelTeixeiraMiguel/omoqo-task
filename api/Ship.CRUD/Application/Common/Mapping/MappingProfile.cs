using AutoMapper;
using Domain.Entities;
using Domain.Models.Ship;

namespace Application.Common.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<ShipAddModel, Ship>();
            CreateMap<Ship, ShipGetResponse>();
            CreateMap<Ship, ShipListItemResponse>();
            CreateMap<ShipAddRequest, ShipAddModel>();
            CreateMap<ShipUpdateRequest, ShipUpdateModel>();
        }
    }
}
