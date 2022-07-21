using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using static System.Net.Mime.MediaTypeNames;

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
            => options.UseSqlServer($"Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=\"{Environment.CurrentDirectory+ "\\APP_DATA\\USERDB.MDF"}\";Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
        public DbSet<User> Users { get; set; }
    }
}