using Firebase.Auth.Providers;
using Firebase.Auth;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HappyDogsV2.Configuration
{
    public static class FirebaseConfig
    {
        public static string ApiKey = "AIzaSyD8d76S07BjkoyJFErIqojRGQ5gGJUQeI4";
        public static string AuthDomain = "consumodeaguapi.firebaseapp.com";
        public static FirebaseAuthProvider[] Providers = new FirebaseAuthProvider[]
        {
            new EmailProvider()
        };
        public static FirebaseAuthConfig AuthConfig = new FirebaseAuthConfig
        {
            ApiKey = ApiKey,
            AuthDomain = AuthDomain,
            Providers = Providers
        };
    }
}
