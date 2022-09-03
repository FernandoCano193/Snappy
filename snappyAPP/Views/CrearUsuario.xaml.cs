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
    }
}