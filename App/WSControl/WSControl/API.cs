using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http;
using Json;

namespace WSControl
{
    class API<T>
    {
        const string api = "http://localhost:8000/";
        HttpClient client = null;
        public API()
        {
            client = new HttpClient();
            client.BaseAddress = new Uri(api);
        }
        public async Task<T[]> get(string endpoint)
        {
            T[] ret = null;
            string json = "";
            HttpResponseMessage response = await client.GetAsync(endpoint);
            if (response.IsSuccessStatusCode)
            {
                json = await response.Content.ReadAsStringAsync();
                ret = JsonParser.Deserialize<T[]>(json);
            }
            return ret;
        }
        public async Task<bool> post(string endpoint, T obj)
        {
            var response = await client.PostAsync(endpoint, new StringContent(JsonParser.Serialize<T>(obj), Encoding.UTF8, "application/json"));
            response.EnsureSuccessStatusCode();
            return response.IsSuccessStatusCode;
        }
        public async Task<bool> put(string endpoint, T obj)
        {
            var response = await client.PutAsync(endpoint, new StringContent(JsonParser.Serialize<T>(obj), Encoding.UTF8, "application/json"));
            response.EnsureSuccessStatusCode();
            return response.IsSuccessStatusCode;
        }
        public async Task<bool> delete(string endpoint)
        {
            var response = await client.DeleteAsync(endpoint);
            response.EnsureSuccessStatusCode();
            return response.IsSuccessStatusCode;
        }
    }
}
