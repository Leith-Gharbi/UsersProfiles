using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using UserWebApi.Models;
using UserWebApi.Models.DataBase;

namespace UserWebApi.Services
{
    public class UserServices
    {
        private AppDbContext _context;

        public UserServices(AppDbContext context)
        {
            _context = context;

        }

        public async Task<List<User>> AddUsers()
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
                return result;
            }
            return null;

        }


    }
}
