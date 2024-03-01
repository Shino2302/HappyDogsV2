using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using Firebase.Database;
using Foundation;

namespace HappyDogsV2.Conexion
{
    public class Cconexion
    {
        //frirebascliente que es el URL de tu base de datos en Firebase
        public static FirebaseClient Firebase = new FirebaseClient("https://asddf-69717-default-rtdb.firebaseio.com/");

        //conexion a API a Json
        private HttpClient _httpClient;
        private string apiBaseUrl;

        //Metodo de conexion
        public Cconexion()
        {
            //hacemos un nuevo httpClient
            _httpClient = new HttpClient();
            //y le ponemos una URL el "BASEADDREESS" es la direccion Base.
            //P.D. El compañero tiene un enlace un poco diferente al de firebase mirar en su repositorio
            _httpClient.BaseAddress = new Uri("https://asddf-69717-default-rtdb.firebaseio.com/");
            apiBaseUrl = "https://asddf-69717-default-rtdb.firebaseio.com/";
        }


        //metodo para obtener datos de la conexion
                                             //el "endpoint" es una parte de
                                             //la  url en la que especifica la collecion
        public async Task<string> ObtenerAsync(string endpoint)
        {
            //aqui se consiguen los datos con el metodo "GetAsync" y se guardan en el response
            var response = await _httpClient.GetAsync(endpoint);

            //esto se lee y convierte en string el contenido de "response"
            return await response.Content.ReadAsStringAsync();  
        }

        //metodo para enviar datos, el cual require un "endpoint" y el "content"
        public async Task<string> EnviarAsync(string endpoint, HttpContent content)
        {
            //se guarda el envio? con el "endpoint" y el "content" en el response
            var response = await _httpClient.PostAsync(endpoint, content);

            //esto se lee y convierte en string el contenido de "response"
            return await response.Content.ReadAsStringAsync();
        }

        //metodo para borrar datos, el cual requiere un path y "queryString"
        public async Task<string> BorrarAsync(string path, string queryString = null )
        {
            //en el "uri" se guarda lo que te regresa el metodo "BuildUri" un los datos dados
            var uri = BuildUri(path, queryString);
            //se guarda en el response y borra con el metodo de "DeleteAsync"
            var response = await _httpClient.DeleteAsync(uri);
            var content = await response.Content.ReadAsStringAsync();
            return content;
        }

        //este metodo es necesario para el de borrar ya que...ayuda :'c
        private Uri BuildUri(string path, string queryString )
        {
            var builder = new UriBuilder(apiBaseUrl);
            builder.Path = path;
            builder.Query = queryString;
            return builder.Uri;
        }

        //metodo para editar 
        public async Task<string> EditarAsync(string endpoint,HttpContent content)
        {
            //guarda en el response  y edita con el metodo "PutAsync"
            var response = await _httpClient.PutAsync(endpoint, content);
            return await response.Content.ReadAsStringAsync();
        }





    }
}
