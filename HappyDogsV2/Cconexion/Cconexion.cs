using Firebase.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HappyDogsV2.Cconexion
{
    public class Cconexion
    {
        public static FirebaseClient firebase = new FirebaseClient("https://happydogdb-55b97-default-rtdb.firebaseio.com/");

        //Conexion a API Json
        private HttpClient _httpClient;
        private string apiBaseUrl;
        public Cconexion()
        {
            _httpClient = new HttpClient();
            _httpClient.BaseAddress = new Uri("https://happydogdb-55b97-default-rtdb.firebaseio.com/");
            apiBaseUrl = "https://happydogdb-55b97-default-rtdb.firebaseio.com/";
        }
        public async Task<string> GetAsync(string endpoint)
        {
            var response = await _httpClient.GetAsync(endpoint);
            return await response.Content.ReadAsStringAsync();
        }
        public async Task<string> PostAsync(string endpoint, HttpContent content)
        {
            var response = await _httpClient.PostAsync(endpoint, content);
            return await response.Content.ReadAsStringAsync();
        }
        public async Task<string> DeleteAsync(string path, string queryString = null)
        {
            var uri = BuildUri(path, queryString);
            var response = await _httpClient.DeleteAsync(uri);
            var content = await response.Content.ReadAsStringAsync();
            return content;
        }
        public async Task<string> PutAsync(string endpoint, HttpContent content)
        {
            var response = await _httpClient.PutAsync(endpoint, content);
            return await response.Content.ReadAsStringAsync();
        }
        private Uri BuildUri(string path, string queryString)
        {
            var builder = new UriBuilder(apiBaseUrl);
            builder.Path = path;
            builder.Query = queryString;
            return builder.Uri;
        }




    }
}
