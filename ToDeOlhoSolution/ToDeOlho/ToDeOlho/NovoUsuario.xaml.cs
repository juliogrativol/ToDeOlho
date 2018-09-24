using Autenticacao;
using Modelo;
using System;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ToDeOlho
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class NovoUsuario : ContentPage
	{
		public NovoUsuario ()
		{
			InitializeComponent ();
		}

        private void NovoUsuario_btn_Clicked(object sender, EventArgs e)
        {
            UsuarioService usuarioService = new UsuarioService();
            Usuario usuario = new Usuario()
            {
                email = Login_entry.Text,
                senha = Senha_entry.Text
            };

            try
            {
                Usuario usuarioRetorno = usuarioService.NovoUsuario(usuario);
                if (usuarioRetorno!= null)
                {
                    Navigation.PushAsync(new Publicacoes());
                }
                else
                {
                    DisplayAlert("Atenção", "Login Já cadastrado!", "Ok");
                }
            }
            catch (Exception ex)
            {
                DisplayAlert("Atenção", ex.Message, "Ok");
            }
        }
    }
}