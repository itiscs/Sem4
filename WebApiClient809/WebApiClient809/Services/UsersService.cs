using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using WebApiClient809.Models;

namespace WebApiClient809.Services
{
    public class UsersService
    {
        HttpClient client = new HttpClient();
        string uri = "http://localhost:63680/api/users";

        public async Task<IEnumerable<User>> GetUsers()
        {
            var resp = await client.GetAsync(uri);
            var result = resp.Content.ReadAsStringAsync().Result;
            var users = JsonConvert.DeserializeObject<List<User>>(result);
            return users;
        }
        public async Task<User> GetUsersByID(int id)
        {
            var resp = await client.GetAsync(uri + $"/{id}");
            var result = resp.Content.ReadAsStringAsync().Result;
            var user = JsonConvert.DeserializeObject<User>(result);
            return user;
        }
        /*public async Task<HttpStatusCode> AddUser(User user)
        {
            HttpResponseMessage response = await client.PostAsync(
                uri, user);
            return response.StatusCode;

        }*/





    }
}
