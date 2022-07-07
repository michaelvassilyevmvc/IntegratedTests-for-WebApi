using DeliveryServiceApi.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace DeliveryServiceApi.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        public DbSet<Order> Orders { get; set; }
    }
}