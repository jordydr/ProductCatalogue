using Microsoft.EntityFrameworkCore;
using ProductCatalogue.Models;

namespace ProductCatalogue.Data
{
    public class Context : DbContext
    {
        public DbSet<Product> Products { get; set; }

        public Context(DbContextOptions<Context> options)
            : base(options)
        {

        }
    }
}
