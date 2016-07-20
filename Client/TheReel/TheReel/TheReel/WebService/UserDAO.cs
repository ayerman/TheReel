using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace TheReel.WebService
{
    public class UserDAO
    {
        public bool Login(User user)
        {
            var client = new HttpClient();

            client.BaseAddress = new Uri("http://reelweb.azurewebsites.net/");

            var response = client.GetStringAsync("api/Users");
            response.Wait();

            bool result = false;
            foreach (var curUser in JsonConvert.DeserializeObject<List<User>>(response.Result))
            {
                if (curUser.username.ToLower() == user.username.ToLower() && curUser.password == user.password)
                {
                    result = true;
                    curUser.id = user.id;
                    break;
                }
            }
            return result;
        }

        public bool Register(User user)
        {
            var client = new HttpClient();

            client.BaseAddress = new Uri("http://reelweb.azurewebsites.net/");
            var serialized = JsonConvert.SerializeObject(user);
            HttpContent queryString = new StringContent(serialized, Encoding.UTF8, "application/json");

            var response = client.PostAsync("api/Users", queryString);
            response.Wait();

            if (response.Result.IsSuccessStatusCode)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
