using AutoMapper;
using Ecommerce.CartAPI.Data.DTO;
using Ecommerce.CartAPI.Model;

namespace Ecommerce.CartAPI.Config
{
    public class MappingConfig
    {
        public static MapperConfiguration RegisterMaps()
        {
            var mappingConfig = new MapperConfiguration(config =>
            {
                config.CreateMap<ProductDTO, Product>().ReverseMap();
                config.CreateMap<CartHeaderDTO, CartHeader>().ReverseMap();
                config.CreateMap<CartDTO, Cart>().ReverseMap();
                config.CreateMap<CartDetailDTO, CartDetail>().ReverseMap();
            });

         return mappingConfig;
        } 
    }
}
