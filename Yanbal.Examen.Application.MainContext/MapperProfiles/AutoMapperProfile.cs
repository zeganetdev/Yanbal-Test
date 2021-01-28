using AutoMapper;
using Yanbal.Examen.Application.MainContext.Dtos;
using Yanbal.Examen.Domain.MainContext.Aggregates.ClienteAgg;

namespace Yanbal.Examen.Application.MainContext.MapperProfiles
{
    public class AutoMapperProfile: Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<Cliente, ClienteDto>().ReverseMap();
        }
    }
}
