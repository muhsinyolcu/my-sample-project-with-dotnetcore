using Data.SqlServer.Entities;
using Microsoft.EntityFrameworkCore;

namespace Data.SqlServer.Data.SqlServer.CodeFirst
{
    class MySContext : DbContext
    {
        //TODO
        protected readonly string connectionString = "";
        public MySContext(DbContextOptions<MySContext> options) 
            : base(options)
        {

        }
        public DbSet<MySProduct> MySProduct { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(connectionString);
        }
    }
}
