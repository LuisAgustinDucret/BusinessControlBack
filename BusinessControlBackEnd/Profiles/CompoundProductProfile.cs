using AutoMapper;
using BusinessControlBackEnd.Dtos;
using BusinessControlBackEnd.Models;

namespace BusinessControlBackEnd.Profiles
{
    public class CompoundProductProfile : Profile
    {
        public CompoundProductProfile()
        {
            CreateMap<CompoundProduct, CompoundProductDTO>().ReverseMap();
        }
    }
}
