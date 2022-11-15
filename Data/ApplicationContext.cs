using WebApiAuto.Model;
using Microsoft.EntityFrameworkCore;

namespace WebApplication2.Data
{
    public class ApplicationContext : DbContext
    {

        public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options)
        {
        }

        public DbSet<AutoSale> AutoSales { get; set; }


    }
}
