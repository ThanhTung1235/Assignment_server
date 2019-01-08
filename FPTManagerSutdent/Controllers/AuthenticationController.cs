using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FPTManagerSutdent.Data;
using FPTManagerSutdent.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FPTManagerSutdent.Controllers
{
    public class AuthenticationController : Controller
    {
        private readonly Datacontext _context;

        public AuthenticationController(Datacontext context)
        {
            _context = context;
        }

        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(Teacher teacher)
        {
            var existAccount = _context.Teacher.SingleOrDefault(a => a.Email == teacher.Email);
            if (existAccount == null)
            {
                Response.StatusCode = 403;
                return Json("Forbidden");
            }
            if (teacher.Password == existAccount.Password)
            {
                HttpContext.Session.SetString("currentLogin", existAccount.Email);
                HttpContext.Session.SetString("currentLoginId", existAccount.Id.ToString());
                return Redirect("ClassRooms/Index");
            }
            Response.StatusCode = 403;
            return Json("Forbidden1");
        }
      
    }
}