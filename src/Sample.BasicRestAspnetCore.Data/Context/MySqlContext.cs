namespace Sample.BasicRestAspnetCore.Data.Context
{
    using Microsoft.EntityFrameworkCore;
    using Sample.BasicRestAspnetCore.EntitiesDomain;
    public class MySqlContext : DbContext
    {
        public MySqlContext()
        {

        }
        public MySqlContext(DbContextOptions<MySqlContext> options) : base(options)
        {

        }

        public DbSet<Person> Persons { get; set; }
        public DbSet<Book> Books { get; set; }
        public DbSet<Users> Users { get; set; }
    }
}