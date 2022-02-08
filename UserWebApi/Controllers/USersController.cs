using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using UserWebApi.Models;
using UserWebApi.Models.DataBase;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace UserWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class USersController : ControllerBase
    {
        private AppDbContext _context;

        public USersController(AppDbContext context)
        {
            _context = context;

        }
        // GET: api/<USersController>
        [HttpGet]
        public IEnumerable<User> Get()
        {
            return _context.Users.ToList();
        }
        [HttpGet("from-url")]
        public async Task<IActionResult> GetFromurl()
        {
            try
            {
                var client = new RestClient($"https://api.github.com/users");
                var request = new RestRequest("https://api.github.com/users", Method.Get);
                var response = await client.ExecuteAsync(request);

                //TODO: transform the response here to suit your needs
                //JObject json = JObject.Parse(response.Content);
                //  IList<User> aPerList = new List<User>(User);
                var result = JsonConvert.DeserializeObject<List<User>>(response.Content);


                var all = from c in _context.Users select c;
                _context.Users.RemoveRange(all);
                _context.SaveChanges();

                _context.Users.AddRange(result);
                var created = _context.SaveChanges();
                if (created > 0)
                {
                    return Ok(result);
                }
                return BadRequest("error");
            }
            catch (Exception ex)
            {

                return BadRequest(ex);
            }
        }
         



           

        // GET api/<USersController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<USersController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<USersController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<USersController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
