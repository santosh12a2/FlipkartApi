using AutoMapper;
using FlipkartApi.DTOs;
using FlipkartApi.Entites;

namespace FlipkartApi.Mapper
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<ProductDTO, Product>();
        }
    }
}
