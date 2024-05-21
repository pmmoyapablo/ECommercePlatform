using AutoMapper;
using ECommerce.Api.ProductCatalog.Model;

namespace ECommerce.Api.ProductCatalog.Aplication
{
    public class MappingProfile : Profile
    {
        public MappingProfile() {
            CreateMap<Product, ProductDto>();
        }
    }
}