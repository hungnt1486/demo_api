using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using ApiTemplate.Models;
using ApiTemplate.Helpers;

namespace ApiTemplate.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : BaseController
    {
        #region custom httpget
        public UsersController(demoDbContext context,
            IConfiguration configuration) : base(context, configuration)
        { }
        //custom httpget
        [HttpGet("getListLang")]
        public IEnumerable<string> GetListLang()
        {
            return new string[] { "lang 1", "lang 2" };
        }
        [HttpGet("getLangs")]
        public async Task<IEnumerable<Users>> GetLangs()
        {
            //todo
            var a = Libs.CreateToken();
            var langs = await DbContext.Users.AsNoTracking().ToListAsync();
            return langs;
            //return null;
        }

        [HttpPost("Login")]
        public string Login(VM_Users vmuser)
        {
            var user = DbContext.Users.Any(x=>x.Username.ToUpper().Contains(vmuser.username.ToUpper())&& x.Password == vmuser.password);
            if (user)
            {
                var tmpUser = DbContext.Users.Where(x => x.Username.Contains(vmuser.username)).First();
                var a = tmpUser.ExpireAccessToken.CompareTo(DateTime.Now);
                if (tmpUser.AccessToken == null || tmpUser.ExpireAccessToken.CompareTo(DateTime.Now) < 0 )
                {
                    tmpUser.AccessToken = Libs.CreateToken();
                    var time = DateTime.Now.AddMinutes(30);
                    tmpUser.ExpireAccessToken = time;
                    DbContext.SaveChanges();
                }
                return tmpUser.AccessToken;
            }
            return "declined";
        }
        #endregion
        
        // GET: api/Languages
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/Languages/5
        [HttpGet("{id}", Name = "Get")]
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Languages
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT: api/Languages/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
