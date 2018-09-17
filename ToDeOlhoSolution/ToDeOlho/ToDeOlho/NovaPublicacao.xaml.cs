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

        private void btn_salvarPublicacao_Clicked(object sender, EventArgs e)
        {

        }
    }
}