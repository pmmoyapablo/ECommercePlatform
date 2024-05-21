using System;

namespace ECommerce.Api.ProductCatalog.Aplication
{
    public class ProductDto
    {
      public Guid? Id { get; set; }

      public string Description { get; set; }

      public DateTime? DateCreated { get; set; }

      public string? Category { get; set; }

      public decimal Price { get; set; }

  }
}
