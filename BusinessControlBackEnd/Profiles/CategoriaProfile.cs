using AutoMapper;
using BusinessControlBackEnd.Dtos;
using BusinessControlBackEnd.Models;

namespace BusinessControlBackEnd.Profiles
{
    public class CategoriaProfile : Profile
    {
        public CategoriaProfile()
        {
            CreateMap<Categoria, CategoriaDTO>().ReverseMap();
        }
    }
}