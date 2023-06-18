﻿using Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Concrete.EntityFramework
{
    public class NorthwindContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //optionsBuilder.UseSqlServer(@"Server=(localdb)\MSSQLLocalDB;Database=Northwind;Trusted_Connection=true");
            optionsBuilder.UseSqlServer(@"Server=(localdb)\mssqllocaldb;Database=Northwind;Trusted_Connection=True;");

            //"Server=(localdb)\mssqllocaldb;Database=Northwind;Trusted_Connection=True;"
        }

        public DbSet<Product> Products {get; set; }
        //public DbSet<Category> Categories { get; set; }
        //public DbSet<Customer> Customers { get; set; }

    }
}
