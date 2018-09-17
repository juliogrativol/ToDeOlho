using Modelo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ToDeOlho
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class NovaPublicacao : ContentPage
	{
		public NovaPublicacao ()
		{
			InitializeComponent ();
		}

        private async void btn_salvarPublicacao_Clicked(object sender, EventArgs e)
        {
            Publicacao publicacao = new Publicacao();
            publicacao.Titulo = Titulo_entry.Text;
            publicacao.Data = DateTime.Now.ToString("dd/MM/yyyy");

            Repository repository = Repository.Instance;

            repository.addItems(publicacao);

            await Navigation.PopAsync(true);
        }
    }
}