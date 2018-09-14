using Autenticacao;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
            Login login = new Login();
            login.email = Email_entry.Text;
            login.senha = Senha_entry.Text;

            DisplayAlert("Login", login.email, "OK");
        }
    }
}
