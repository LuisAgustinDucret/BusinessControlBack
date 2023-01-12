using AutoMapper;
using BusinessControlBackEnd.Dtos;
using BusinessControlBackEnd.Models;

namespace BusinessControlBackEnd.Profiles
{
    public class RubroProfile : Profile
    {
        public RubroProfile()
        {
            CreateMap<Rubro, RubroDTO>().ReverseMap();
        }
    }
}