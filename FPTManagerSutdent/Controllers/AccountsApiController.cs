using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using FPTManagerSutdent.Data;
using FPTManagerSutdent.Models;

namespace FPTManagerSutdent.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountsApiController : ControllerBase
    {
        private readonly Datacontext _context;

        public AccountsApiController(Datacontext context)
        {
            _context = context;
        }

        // GET: api/AccountsApi
        [HttpGet]
        public IEnumerable<Account> GetAccount()
        {
            return _context.Account;
        }
        
        [HttpPost("authentication")]
        public IActionResult Authentication([FromBody] Account account)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var existAccount = _context.Account.SingleOrDefault(a => a.Email == account.Email);
            if (existAccount == null)
            {
                Response.StatusCode = 403;
                return new JsonResult("Forbidden1");
            }

            var isValidPassword = existAccount.CheckLoginPassword(account.Password);
            if (isValidPassword)
            {
                MyCredential credential = new MyCredential(existAccount.Id);
                _context.MyCredentials.Add(credential);
                _context.SaveChanges();
                Response.StatusCode = 200;
                return new JsonResult(credential);
            }
            Response.StatusCode = 403;
            return new JsonResult("Forbidden2");
        }
    }
}