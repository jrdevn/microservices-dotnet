using AutoMapper;
using Shopping.ProductAPI.Data.ValueObjects;
using Shopping.ProductAPI.Model;

namespace Shopping.ProductAPI.Config
{
    public class MappingConfig
    {
        public static MapperConfiguration RegisterMaps()
        {
            var mappingConfig = new MapperConfiguration(config => {
                config.CreateMap<ProductVO, Product>();
                config.CreateMap<Product, ProductVO>();
            });

            return mappingConfig;
        }
    }
}
