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
        public IActionResult Login(Student student)
        {
            var existAccount = _context.Student.SingleOrDefault(a => a.Email == student.Email);
            if (existAccount == null)
            {
                Response.StatusCode = 403;
                return Json("Forbidden");
            }
            student.Salt = existAccount.Salt;
            student.EncryptPassword();
            if (student.Password == existAccount.Password)
            {
                HttpContext.Session.SetString("currentLogin", existAccount.Email);
                HttpContext.Session.SetString("currentLoginId", existAccount.Id.ToString());
                return Json("Success");
            }
            Response.StatusCode = 403;
            return Json("Forbidden1");
        }
    }
}