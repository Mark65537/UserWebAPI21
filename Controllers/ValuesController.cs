using UserWebAPI21.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net;
using Microsoft.AspNetCore.Mvc;

namespace UserWebAPI21.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        AppDBContext db = new AppDBContext();
        //для проверки
        //public IEnumerable<String> Get()
        //{
        //    return new string[] { "value1", "value2" };
        //}

        // GET api/values
        [HttpGet]
        public IEnumerable<User> GetUsers()
        {
            return db.Users;
        }
        [HttpGet("{id}")]
        public User GetUser(int id)
        {
            User user = db.Users.Find(id);
            return user;
        }

        // POST api/values
        [HttpPost]
        public void CreateUser([FromBody] User user)
        {
            db.Users.Add(user);
            db.SaveChanges();
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void EditUser(int id, [FromBody] User user)
        {
            if (id == user.Id)
            {
                db.Entry(user).State = EntityState.Modified;

                db.SaveChanges();
            }
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void DeleteUser(int id)
        {
            User user = db.Users.Find(id);
            if (user != null)
            {
                db.Users.Remove(user);
                db.SaveChanges();
            }
        }
    }
}
