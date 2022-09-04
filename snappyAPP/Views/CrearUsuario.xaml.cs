using Plugin.Media;
using Plugin.Media.Abstractions;
using snappyAPP.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace snappyAPP.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class CrearUsuario : ContentPage
    {
        public CrearUsuario()
        {
            InitializeComponent();
        }

        MediaFile FileFoto;
        string IdUsuario;

        private void btnCrearCuenta_Clicked(object sender, EventArgs e)
        {
            if(!string.IsNullOrEmpty(txtNombre.Text))
            {
                if (!string.IsNullOrEmpty(txtEmail.Text))
                {
                    if (!string.IsNullOrEmpty(txtPassword.Text))
                    {
                        CrearCuenta();
                        IniciarSesion();
                        ObtenerIdUsuario();
                    }
                }
            }
            
        }

        private void CrearCuenta()
        {
            var funcion = new VMCrearUsuario();
            funcion.CrearCuenta(txtEmail.Text, txtPassword.Text);
        }

        private void IniciarSesion()
        {
            var funcion = new VMCrearUsuario();
            funcion.ValidarCuenta(txtEmail.Text, txtPassword.Text);
        }

        private async void ObtenerIdUsuario()
        {
            var funcion = new VMCrearUsuario();
            IdUsuario = await funcion.ObtenerIdUsuario();
        }

        private async void btnSubirFoto_Clicked(object sender, EventArgs e)
        {
            //INICIALIZA LA BUSQUEDA DE LA FOTO EN EL ALMACENAMIENTO DEL DISPOSITIVO
            await CrossMedia.Current.Initialize();

            try
            {
                FileFoto = await CrossMedia.Current.PickPhotoAsync(new PickMediaOptions()
                {
                    PhotoSize = PhotoSize.Medium,
                });
                if (FileFoto == null)
                    return;
                else
                    FotoPerfil.Source = ImageSource.FromStream(FileFoto.GetStream);
            }
            catch (Exception ex)
            {
                await DisplayAlert("Error", ex.Message, "OK");
            }
        }
    }
}