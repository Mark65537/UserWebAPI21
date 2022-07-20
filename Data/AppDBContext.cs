using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace UserWebAPI21.Models
{
    public class AppDBContext : DbContext
    {
        public AppDBContext()
               : base()
        {
            //Database.EnsureCreated();
        }
        protected override void OnConfiguring(DbContextOptionsBuilder options)
            => options.UseSqlServer($"Server=(localdb)\\mssqllocaldb;Database=UserDB;Trusted_Connection=True;");
        public DbSet<User> Users { get; set; }
    }
}