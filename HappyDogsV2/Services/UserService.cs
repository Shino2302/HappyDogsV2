using Firebase.Auth;
using FirebaseAdmin.Auth;
using FirebaseAdmin;
using Google.Apis.Auth.OAuth2;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Firebase.Database;
using System.Runtime.CompilerServices;
using HappyDogsV2.Configuration;

namespace HappyDogsV2.Services
{
    public class UserService 
    {
        private static FirebaseAuthClient _firebaseAuthClient;
        private Firebase.Auth.UserCredential _userCredential;
        private string _token;


        public static FirebaseAuthClient FirebaseAuthInstance
        {
            get
            {
                if (_firebaseAuthClient == null)
                {
                    _firebaseAuthClient = new FirebaseAuthClient(FirebaseConfig.AuthConfig);
                }
                return _firebaseAuthClient;
            }
        }
        public async Task<bool> LoginAsync(string email, string password)
        {
            try
            {
                _userCredential = await FirebaseAuthInstance.SignInWithEmailAndPasswordAsync(email, password);
                var user = _userCredential.User;
                _token = await user.GetIdTokenAsync();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public async Task<bool> LogoutAsync()
        {
            try
            {

                FirebaseAuthInstance.SignOut();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public async Task<User> GetCurrentUserAsync()
        {
            try
            {
                // Variables del usuario logueado
                var user = _userCredential.User;
                var uid = user.Uid;
                var name = user.Info.DisplayName;

                return user; // Regresa el usuario logueado
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public async Task<User> RegisterAsync(string email, string password, string name)
        {
            try
            {
                var authResult = await FirebaseAuthInstance.CreateUserWithEmailAndPasswordAsync(email, password, name);
                var user = authResult.User;
                return user;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

    }
}
