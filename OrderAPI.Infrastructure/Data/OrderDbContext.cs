using Microsoft.EntityFrameworkCore;
using OrderAPI.Domain.Entities;

namespace OrderAPI.Infrastructure.Data
{
    public class OrderDbContext : DbContext
    {
        public OrderDbContext(DbContextOptions<OrderDbContext> options) : base(options)
        {
        }
        public DbSet<Order> Orders { get; set; }
    }
}
