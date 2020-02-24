using Newtonsoft.Json;
using Reddit.Core.Models;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Reddit.Core.Services
{
    public static class RedditService
    {
        public static async Task<RedditDTO> GetTopPost()
        {
            var client = new RestClient("https://www.reddit.com/r");
            var request = new RestRequest("pics/top.json", DataFormat.Json);
            var response = client.Get(request);
            var result = JsonConvert.DeserializeObject<RedditDTO>(response.Content);

            return result;
        }
    }
}
