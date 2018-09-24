using Modelo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;

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
            await RetrieveLocation();
        }

        private async Task RetrieveLocation()
        {
            try
            {
                var location = await Geolocation.GetLastKnownLocationAsync();
                Console.WriteLine($"Latitude: {location.Latitude}, Longitude: {location.Longitude}, Altitude: {location.Altitude}");
            }
            catch (FeatureNotSupportedException fnsEx)
            {
                await DisplayAlert("Handle not supported on device exception",
                    fnsEx.Message, "Ok");
            }
            catch (PermissionException pEx)
            {
                await DisplayAlert("Handle permission exception",
                pEx.Message, "Ok");
            }
            catch (Exception ex)
            {
                await DisplayAlert("Unable to get location",
                ex.Message, "Ok");
            }
        }
    }
}