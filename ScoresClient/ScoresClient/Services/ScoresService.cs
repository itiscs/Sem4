using Newtonsoft.Json;
using ScoresClient.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;

namespace ScoresClient.Services
{
    public class ScoresService
    {
        private HttpClient client = new HttpClient();
        private string Uri = "http://localhost:59533/api/players";
        
       
        public async Task<IEnumerable<Player>> GetPlayers()
        {
            var resp = await client.GetAsync(Uri);
            return  JsonConvert.DeserializeObject<List<Player>>(resp.Content.ReadAsStringAsync().Result);
        }

        public async Task<Player> GetPlayerByID(int id)
        {
            var resp = await client.GetAsync(Uri+"/"+id.ToString());
            return JsonConvert.DeserializeObject<Player>(resp.Content.ReadAsStringAsync().Result);
        }


    }
}