using System;
using System.Collections.Generic;
using System.Text;
using Firebase.Database;

namespace snappyAPP.Conexion
{
    public class FirebaseDB
    {
        public static FirebaseClient firebase = new FirebaseClient("https://snappy-c89b7-default-rtdb.firebaseio.com/");

        public const string WebapiFirebase = "AIzaSyCX9r595JOLUD-dIZqNwZYZJMGuWQL9sbA";
        
        public static string Storage = "snappy-c89b7.appspot.com/";
    }
}
