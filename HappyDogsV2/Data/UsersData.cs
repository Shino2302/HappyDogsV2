using HappyDogsV2.Models;
using HappyDogsV2.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Firebase.Database.Query;
using System.Collections.ObjectModel;
using Firebase.Database;
using HappyDogsV2.Services;
using Newtonsoft.Json;
using System.Linq.Expressions;
using Firebase.Auth;

namespace HappyDogsV2.Data
{
    public class UsersData
    {
        ConecctionWithFireBase connection = new ConecctionWithFireBase();

        UserService userService = new UserService();

        public async Task UserInsert(UsersModel newUser)
        {
            try
            {
                var registerAuth = await userService.RegisterAsync(newUser.Email, newUser.Password, newUser.Name);

                var firebaseUserId = registerAuth.Uid;

                var datas = new Dictionary<string, UsersModel>();
                datas.Add(firebaseUserId, new UsersModel
                {
                    Name = newUser.Name,
                    Email = newUser.Email,
                    Password = newUser.Password,
                    PhoneNumber = newUser.PhoneNumber,
                    ProfileImage = newUser.ProfileImage,
                    UID = firebaseUserId
                });

                var json = JsonConvert.SerializeObject(datas);
                var content = new StringContent(json, Encoding.UTF8, "application/json");
                var response = await connection.PostAsync("", content);
                var data = JsonConvert.DeserializeObject<Dictionary<string, UsersModel>>(response);
                var firebaseKey = data.Keys.FirstOrDefault();
                var result = response.ToString();
            }
            catch (FirebaseAuthException ex){}
            catch (Exception ex) { }
        }
        public async Task<bool> DeleteUser(string key)
        {
            await connection.DeleteAsync($"");
            return true;
        }
    }
}
