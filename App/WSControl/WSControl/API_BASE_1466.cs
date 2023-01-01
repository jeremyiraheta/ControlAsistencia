using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http;
using Newtonsoft.Json;

namespace WSControl
{
    /// <summary>
    /// Interfaz para acceder a la api
    /// </summary>
    /// <typeparam name="T"></typeparam>
    class API<T>
    {
        const string api = "http://localhost:8000/";
        HttpClient client = null;
        /// <summary>
        /// Crea instancia del acceso a la api se puede redifinir el valor predeterminado usando el registro del usuario local Sofware\Digestyc valor api
        /// </summary>
        public API()
        {
            client = new HttpClient();
            string apirelocate = null;
            try
            {
                apirelocate = (string)Microsoft.Win32.Registry.CurrentUser.OpenSubKey("Software\\Digestyc", false).GetValue("api");
            }
            catch (Exception)
            {
            }
            if (apirelocate != null && !apirelocate.Equals(""))
                client.BaseAddress = new Uri(apirelocate);
            else
                client.BaseAddress = new Uri(api);
        }
        /// <summary>
        /// Peticion get asincrona
        /// </summary>
        /// <param name="endpoint">recurso de la api</param>
        /// <returns></returns>
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
        /// <summary>
        /// Descarga de archivo asincrona
        /// </summary>
        /// <param name="endpoint">recurso de la api</param>
        /// <returns></returns>
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
        /// <summary>
        /// Realiza peticion post asincrona
        /// </summary>
        /// <param name="endpoint">recurso de la api</param>
        /// <param name="obj">objecto a enviar</param>
        /// <returns></returns>
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
        /// <summary>
        /// Realizar peticion post asincrona envia archivo
        /// </summary>
        /// <param name="endpoint">recurso de la api</param>
        /// <param name="file">locacion del archivo</param>
        /// <param name="name">nombre del parametro</param>
        /// <returns></returns>
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
        /// <summary>
        /// Realiza peticion post asincrona sin enviar datos
        /// </summary>
        /// <param name="endpoint">recurso de la api</param>
        /// <returns></returns>
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
        /// <summary>
        /// Realiza peticion put asincrona
        /// </summary>
        /// <param name="endpoint">recurso de la api</param>
        /// <param name="obj">objecto enviado</param>
        /// <returns></returns>
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
        /// <summary>
        /// Realiza peticion put asincrona sin enviar datos
        /// </summary>
        /// <param name="endpoint">recurso de la api</param>
        /// <returns></returns>
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
        /// <summary>
        /// Realiza peticion delete
        /// </summary>
        /// <param name="endpoint">recurso de la api</param>
        /// <returns></returns>
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
    /// <summary>
    /// Interfaz para acceder api tipo object prederminada
    /// </summary>
    class API : API<object>
    {

    }
}
