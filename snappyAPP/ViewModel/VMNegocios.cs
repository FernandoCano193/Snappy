using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using Firebase.Auth;
using Firebase.Database;
using Firebase.Database.Query;
using Firebase.Storage;
using snappyAPP.Conexion;
using snappyAPP.Model;

namespace snappyAPP.ViewModel
{
    public class VMNegocios
    {
        string RutaFoto;

        public async Task InsertarNegocio(MNegocios negocio)
        {
            await FirebaseDB.firebase
                .Child("Negocios")
                .PostAsync(new MNegocios()
                {
                    Celular = negocio.Celular,
                    Descripcion = negocio.Descripcion,
                    Direccion = negocio.Direccion,
                    Foto = negocio.Foto,
                    Nombre = negocio.Nombre,
                    Prioridad = negocio.Prioridad,
                    idCategoria = negocio.idCategoria,
                    idLocalidad = negocio.idLocalidad,
                    idUsuario = negocio.idUsuario
                });
        }

        public async Task<string> SubirFotoStorage(Stream StreamFoto, string IdUsuario)
        {
            var storageFoto = await new FirebaseStorage(FirebaseDB.Storage)
                .Child("Negocios")
                .Child(IdUsuario + ".jpg")
                .PutAsync(StreamFoto);

            RutaFoto = storageFoto;

            return RutaFoto;
        }
    }
}
