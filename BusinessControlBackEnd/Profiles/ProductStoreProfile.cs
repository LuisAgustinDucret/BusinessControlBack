using AutoMapper;
using BusinessControlBackEnd.Dtos;
using BusinessControlBackEnd.Models;

namespace BusinessControlBackEnd.Profiles
{
    public class ProductStoreProfile : Profile
    {
        public ProductStoreProfile()
        {
            CreateMap<ProductStore, ProductStoreDTO>().ReverseMap();
        }
    }
}