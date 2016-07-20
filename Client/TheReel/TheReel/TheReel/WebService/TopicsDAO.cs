using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace TheReel.WebService
{
    public class TopicsDAO
    {
        public IEnumerable<Topic> getActiveTopics()
        {

            //DAO this
            var client = new HttpClient();

            client.BaseAddress = new Uri("http://reelweb.azurewebsites.net/");

            var response = client.GetStringAsync("api/Topics");
            response.Wait();
            
            return JsonConvert.DeserializeObject<List<Topic>>(response.Result));
        }
    }
}
