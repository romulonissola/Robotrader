using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Robotrader.Business.Utils
{
    public class HttpClientFactory
    {
        private HttpClient _client;
        public HttpClientFactory(string uri)
        {
            _client = new HttpClient
            {
                BaseAddress = new Uri(uri)
            };
        }

        public void AddHeader(string name, string value)
        {
            _client.DefaultRequestHeaders.Add(name, value);
        }

        public async Task<T> GetAsync<T>(string path)
        {
            var result = await _client.GetAsync(path);
            if(!result.IsSuccessStatusCode)
            {
                throw new Exception($"Some Problem has Occurred Accessing {_client.BaseAddress}/{path} statusCode: {result.StatusCode} message {result.RequestMessage}");
            }
            return JsonConvert.DeserializeObject<T>(await result.Content.ReadAsStringAsync());
        }
    }
}
