using Microsoft.EntityFrameworkCore;
using ECommerce.Api.OrderManagement.Model;

namespace ECommerce.Api.OrderManagement.Persistence
{
    public class CarContext : DbContext
    {
        public CarContext(DbContextOptions<CarContext> options) : base(options) { }

        public DbSet<CarSession> CarSessions { get; set; }

        public DbSet<CarSessionDetail> CarSessionDetails { get; set; }

    }
}
