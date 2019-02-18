using Microsoft.EntityFrameworkCore;

namespace Sample.BasicRestAspnetCore.Host.Models.Context
{
    public class MySqlContext : DbContext
    {
        public MySqlContext()
        {

        }
        public MySqlContext(DbContextOptions<MySqlContext> options) : base(options)
        {

        }

        public DbSet<Person> Persons { get; set; }
    }
}