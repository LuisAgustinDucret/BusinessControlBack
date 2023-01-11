using AutoMapper;
using BusinessControlBackEnd.Dtos;
using BusinessControlBackEnd.Models;

namespace BusinessControlBackEnd.Profiles
{
    public class UnidadMedidaProfile : Profile
    {
        public UnidadMedidaProfile()
        {
            CreateMap<UnidadMedida, UnidadMedidaDTO>().ReverseMap();
        }
    }
}
