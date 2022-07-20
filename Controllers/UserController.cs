using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace UserWebAPI21.Controllers
{
    public class UserController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }
    }
}
