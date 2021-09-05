using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http;
using Newtonsoft.Json;

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
        public async Task<T> get(string endpoint)
        {
            string json = "";
            HttpResponseMessage response = await client.GetAsync(endpoint);
            if (response.IsSuccessStatusCode)
            {
                json = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<T>(json);
            }
            return default(T);
        }
        public async Task<byte[]> download(string endpoint)
        {
            byte[] array;
            HttpResponseMessage response = await client.GetAsync(endpoint);
            if (response.IsSuccessStatusCode)
            {
                array = await response.Content.ReadAsByteArrayAsync();
                return array;
            }
            return null;
        }
        public async Task<T> post(string endpoint, object obj)
        {
            var response = await client.PostAsync(endpoint, new StringContent(JsonConvert.SerializeObject(obj), Encoding.UTF8, "application/json"));
            string json = "";
            if (response.IsSuccessStatusCode)
            {
                json = await response.Content.ReadAsStringAsync();
                var ret = JsonConvert.DeserializeObject<T>(json);
                return ret;
            }
            return default(T);
        }
        public async Task<T> post(string endpoint, string file, string name)
        {
            MultipartFormDataContent obj = new MultipartFormDataContent();
            HttpContent content = new ByteArrayContent(System.IO.File.ReadAllBytes(file));
            content.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue("application/zip");
            obj.Add(content, name, new System.IO.FileInfo(file).Name);
            var response = await client.PostAsync(endpoint, obj);
            string json = "";
            if (response.IsSuccessStatusCode)
            {
                json = await response.Content.ReadAsStringAsync();
                var ret = JsonConvert.DeserializeObject<T>(json);
                return ret;
            }
            return default(T);
        }
        public async Task<T> post(string endpoint)
        {
            var response = await client.PostAsync(endpoint,null);
            string json = "";
            if (response.IsSuccessStatusCode)
            {
                json = await response.Content.ReadAsStringAsync();
                var ret = JsonConvert.DeserializeObject<T>(json);
                return ret;
            }
            return default(T);
        }
        public async Task<T> put(string endpoint, object obj)
        {
            var response = await client.PutAsync(endpoint, new StringContent(JsonConvert.SerializeObject(obj), Encoding.UTF8, "application/json"));
            string json = "";
            if (response.IsSuccessStatusCode)
            {
                json = await response.Content.ReadAsStringAsync();
                var ret = JsonConvert.DeserializeObject<T>(json);
                return ret;
            }
            return default(T);
        }
        public async Task<T> put(string endpoint)
        {
            var response = await client.PutAsync(endpoint, null);
            string json = "";
            if (response.IsSuccessStatusCode)
            {
                json = await response.Content.ReadAsStringAsync();
                var ret = JsonConvert.DeserializeObject<T>(json);
                return ret;
            }
            return default(T);
        }
        public async Task<T> delete(string endpoint)
        {
            var response = await client.DeleteAsync(endpoint);
            string json = "";
            if (response.IsSuccessStatusCode)
            {
                json = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<T>(json);
            }
            return default(T);
        }
    }
    class API : API<object>
    {

    }
}
