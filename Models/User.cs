using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace UserWebAPI21.Models
{
    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Year { get; set; }

        public User(string name, int year)
        {
            Name = name;    
            Year = year;
        }
    }
}