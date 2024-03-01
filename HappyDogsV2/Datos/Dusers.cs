using HappyDogsV2.Conexion;
using HappyDogsV2.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HappyDogsV2.Datos
{
    public class Dusers
    {
        //peticiones a la API Json (abrir la conexion con FB)
        Cconexion conexion = new Cconexion();

        //peticoines a los sevicios de FB falta crear la clase UserService
        UserService userservice = new UserService();

        //usar el metodo de obtenerAsync para mostrar las mascotas del usuario actual
        public async Task<ObservableCollection<Musers>> ViewPets()
        {
            //obtenemos los datos del " .json" de la conexion 
            var response = await conexion.ObtenerAsync("Users.json");
            var json = response.ToString();
            var usuarios = JsonConvert.DeserializeObject<Musers>(json);
            var items = new ObservableCollection<Musers>();
            
            foreach (var item in usuarios)
            {
                item.add(item);
            }
            return items;
        }

    }
}
