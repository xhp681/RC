using Microsoft.EntityFrameworkCore;
using System;
using Rs.Config;

namespace Rs.Data
{
    public class LpDbContext:DbContext
    {
        public LpDbContext(DbContextOptions<LpDbContext> options) : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //optionsBuilder.UseSqlServer("Data Source=.\\SQLSERVER2014;Initial Catalog=EfCore.Test;User ID=sa;Pwd=1");
            optionsBuilder.UseSqlServer(ConfigHelper.ReadDbConfig());
            base.OnConfiguring(optionsBuilder);
            
        }
    }
}
