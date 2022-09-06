using AutoMapper;
using Ecommerce.ProductAPI.Data.DTO;
using Ecommerce.ProductAPI.Model;

namespace Ecommerce.ProductAPI.Config
{
    public class MappingConfig
    {
        public static MapperConfiguration RegisterMaps()
        {
            var mappingConfig = new MapperConfiguration(config =>
            {
                config.CreateMap<ProductDTO, Product>();
                config.CreateMap<Product, ProductDTO>();
            });

         return mappingConfig;
        } 
    }
}
