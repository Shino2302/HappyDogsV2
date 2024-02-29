using Firebase.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HappyDogsV2.Data
{
    public class ConecctionWithFireBase
    {
        public static FirebaseClient client = new FirebaseClient("https://happydogdb-55b97-default-rtdb.firebaseio.com/");
        public string webApiKey = "";
    }
}
