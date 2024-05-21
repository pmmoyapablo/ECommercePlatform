using AutoMapper;
using ECommerce.Api.ProductCatalog.Aplication;
using ECommerce.Api.ProductCatalog.Model;

namespace ECommerce.Api.ProductCatalog.Test.Utils
{
  public class MappingTest : Profile
  {
    public MappingTest()
    {
      CreateMap<Product, ProductDto>();
    }

  }
}