using System;
using System.Collections.Generic;
using System.Text;
using Firebase.Database;

namespace snappyAPP.Conexion
{
    public class FirebaseDB
    {
        public static FirebaseClient firebase = new FirebaseClient("https://snappy-c89b7-default-rtdb.firebaseio.com/");
    }
}
