using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using SqlAPITest.Entity;

namespace SqlAPITest.Concrete
{
	public class SqlDbContext : DbContext
	{
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=sql-server5,1433;Initial Catalog=sql2;User ID=SA;Password=reallyStrongPwd123;TrustServerCertificate=true;");
        }

        public DbSet<Product> Products { get; set; }

    }
}

