using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace OrderAPI.Infrastructure.Data
{
    public class OrderDbContextFactory : IDesignTimeDbContextFactory<OrderDbContext>
    {
        public OrderDbContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<OrderDbContext>();

            optionsBuilder.UseSqlServer(
                         "Data Source=DESKTOP-HS233JS;Initial Catalog=OrderDB;Integrated Security=True;TrustServerCertificate=True;");

            return new OrderDbContext(optionsBuilder.Options);
        }
    }
}
