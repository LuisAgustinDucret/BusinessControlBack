using AutoMapper;
using BusinessControlBackEnd.Dtos;
using BusinessControlBackEnd.Models;

namespace BusinessControlBackEnd.Profiles
{
    public class StoreProfile : Profile
    {
        public StoreProfile()
        {
            CreateMap<Store, StoreDTO>().ReverseMap();
            CreateMap<StoreCreateUpdateDTO, Store>();
            CreateMap<Store, StoreWithProductsDTO>()
                .ForMember(dto => dto.Products,
                       opt => opt.MapFrom(store => store.ProductsFS.Select(ps => ps.Product)));
        }
    }
}
