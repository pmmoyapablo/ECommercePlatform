using Microsoft.EntityFrameworkCore;
using ECommerce.Api.ProductCatalog.Model;

namespace ECommerce.Api.ProductCatalog.Persistence
{
    public class ContextProduct : DbContext
    {
        public ContextProduct() { }
     
        public ContextProduct(DbContextOptions<ContextProduct> options) : base(options) { }

        public virtual DbSet<Product> Products { get; set; }

    }
}
