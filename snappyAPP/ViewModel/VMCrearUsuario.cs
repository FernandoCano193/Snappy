using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Firebase.Auth;
using Newtonsoft.Json;
using snappyAPP.Conexion;
using Xamarin.Essentials;

namespace snappyAPP.ViewModel
{
    public class VMCrearUsuario
    {
        string IdUsuario;

        public async void CrearCuenta(string email, string password)
        {
            var authProvider = new FirebaseAuthProvider(new FirebaseConfig(FirebaseDB.WebapiFirebase));

            await authProvider.CreateUserWithEmailAndPasswordAsync(email, password);
        }

        //VALIDACION DE LOS DATOS
        public async void ValidarCuenta(string email, string password)
        {
            var authProvider = new FirebaseAuthProvider(new FirebaseConfig(FirebaseDB.WebapiFirebase));

            var auth = await authProvider.SignInWithEmailAndPasswordAsync(email, password);

            //VERIFICA SI SE LOGEO
            var recuperarToken = await auth.GetFreshAuthAsync();
            var token =JsonConvert.SerializeObject(recuperarToken);

            Preferences.Set("MyFirebaseRefreshToken", token);
        }

        public async Task<string> ObtenerIdUsuario()
        {
            var authProvider = new FirebaseAuthProvider(new FirebaseConfig(FirebaseDB.WebapiFirebase));
            var GuardarId = JsonConvert.DeserializeObject<FirebaseAuth>(Preferences.Get("MyFirebaseRefreshToken", ""));
            var refreshContent = await authProvider.RefreshAuthAsync(GuardarId);

            Preferences.Set("MyFirebaseRefreshToken", JsonConvert.SerializeObject(refreshContent));

            IdUsuario = GuardarId.User.LocalId;
            return IdUsuario;
        }


    }
}
