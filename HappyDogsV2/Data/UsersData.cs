using HappyDogsV2.Models;
using HappyDogsV2.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Firebase.Database.Query;
using System.Collections.ObjectModel;

namespace HappyDogsV2.Data
{
    public class UsersData
    {
        public async Task UserRegister(UsersModel userToInsert)
        {
            await ConecctionWithFireBase.client.Child("Users").PostAsync
                (new UsersModel()
                {
                    UserId = Guid.NewGuid(),
                    Email = userToInsert.Email,
                    Name = userToInsert.Password,
                    Password = userToInsert.Password,
                    PhoneNumber = userToInsert.PhoneNumber,
                    ProfileImage = userToInsert.ProfileImage
                });
        }
        public async Task UserDelete(Guid userId)
        {
            var userToDelete = (await ConecctionWithFireBase.client
                .Child("Users").OnceAsync<UsersModel>()).
                Where(a => a.Object.UserId == userId).FirstOrDefault();

            await ConecctionWithFireBase.client.Child("Users").Child(userToDelete.Key).DeleteAsync();
        }

        public async Task<ObservableCollection<UsersModel>> SeeUserData()
        {
            var data = await Task.Run(() => ConecctionWithFireBase.client
                .Child("Users")
                .AsObservable<UsersModel>()
                .AsObservableCollection());
            return data;
        }
    }
}
