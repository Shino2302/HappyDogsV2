using HappyDogsV2.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HappyDogsV2.Cconexion;
using Firebase.Database;

namespace HappyDogsV2.Datos
{
    public class DatosPets
    {
        /*
        public async Task InsertarPets(PetsModel parametros)
        {
            await Cconexion.Cconexion.firebase
                .Child("Pets")
                .PostAsync(new PetsModel()
                {
                    //aun no se sabe si tendra id o no
                    IdEjercicios = Guid.NewGuid(),
                    PetName = parametros.PetName,
                    PetAge = parametros.PetAge,
                    PetRace = parametros.PetRace,
                    PetImage= parametros.PetImage,
                    PetSize= parametros.PetSize,
                    HistorieOfFoods= parametros.HistorieOfFoods,

                    //Idpokemon = Guid.NewGuid(),
                });
        }
        */



        public async Task<ObservableCollection<PetsModel>> MostrarPets()
        {
            //return (await Cconexion.firebase
            //    .Child("Pokemon")
            //    .OnceAsync<Mpokemon>())
            //    .Select(item => new Mpokemon
            //    {
            //        Idpokemon=item.Key,
            //        Nombre = item.Object.Nombre,
            //        ColorFondo=item.Object.ColorFondo,
            //        ColorPoder=item.Object.ColorPoder,
            //        Icono=item.Object.Icono,
            //        NroOrden = item.Object.NroOrden,
            //        Poder=item.Object.Poder

            //    }).ToList();
            var data = await Task.Run(() => Cconexion.Cconexion.firebase
                .Child("Pets")
                .AsObservable<PetsModel>()
                .AsObservableCollection());
            return data;
        }
    }
}
