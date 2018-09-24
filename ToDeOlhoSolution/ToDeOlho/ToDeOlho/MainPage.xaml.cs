using Autenticacao;
using Modelo;
using System;
using Xamarin.Forms;

namespace ToDeOlho
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        private void login_Clicked(object sender, EventArgs e)
        {
            Login login = new Login
            {
                email = Email_entry.Text,
                senha = Senha_entry.Text
            };

            try
            {
                AutenticacaoService autenticacaoService = new AutenticacaoService();
                LoginRetorno retornoLogin = autenticacaoService.Autenticar(login);

                if (retornoLogin.ativo)
                {
                    Navigation.PushAsync(new Publicacoes());
                }
                else
                {
                    DisplayAlert("Atenção", "Usuário ou senha inválidos!", "Ok");
                }
            }
            catch (Exception ex)
            {
                DisplayAlert("Atenção", ex.Message, "Ok");
            }
        }

        private void Novo_btn_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new NovoUsuario());
        }
    }
}
