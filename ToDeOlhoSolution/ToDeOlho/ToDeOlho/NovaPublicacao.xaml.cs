using Autenticacao;
using Modelo;
using Plugin.Media;
using Plugin.Media.Abstractions;
using System;
using System.IO;
using System.Threading.Tasks;
using Xamarin.Essentials;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ToDeOlho
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class NovaPublicacao : ContentPage
	{

        MediaFile file;


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
                if (Titulo_entry.Text.Equals(""))
                {
                    await DisplayAlert("Atenção!",
                    "Título deve ser preenchido!", "Ok");
                }
                else if (Descricao_entry.Text.Equals(""))
                {
                    await DisplayAlert("Atenção!",
                    "Descrição deve ser preenchida!", "Ok");
                }
                else if (file == null)
                {
                    await DisplayAlert("Atenção!",
                    "Foto é obrigatória!", "Ok");
                }
                else
                {
                    var location = await Geolocation.GetLocationAsync();

                    Publicacao publicacao = new Publicacao();
                    publicacao.Origem = "APP";
                    publicacao.Login = "teste";
                    publicacao.Titulo = Titulo_entry.Text;
                    publicacao.Descricao = Descricao_entry.Text;
                    publicacao.Longitude = location.Longitude.ToString();
                    publicacao.Altitude = location.Altitude.ToString();
                    publicacao.Latitude = location.Latitude.ToString();
                    publicacao.Imagem = await ConvertToBase64(file.GetStream());

                    PublicacaoService publicacaoService = new PublicacaoService();
                    Retorno retorno = publicacaoService.NovaPublicacao(publicacao);

                    if (retorno != null)
                    {
                        await DisplayAlert("",
                        "Publicação criada com sucesso!", "Ok");
                        await Navigation.PushAsync(new Publicacoes());
                    }
                    else
                    {
                        await DisplayAlert("Atenção!",
                        "Problemas ao gravar publicação!", "Ok");
                    }
                }
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

        private async Task<String> ConvertToBase64(Stream stream)
        {
            var bytes = new byte[stream.Length];
            await stream.ReadAsync(bytes, 0, (int)stream.Length);
            return System.Convert.ToBase64String(bytes);
        }

        private async void TakePhoto(object sender, EventArgs e)
        {
            await CrossMedia.Current.Initialize();

            if (!CrossMedia.Current.IsTakePhotoSupported ||
                !CrossMedia.Current.IsCameraAvailable)
            {
                await DisplayAlert("No Camera", "No camera detected.", "Ok");
                return;
            }

            file = await CrossMedia.Current.TakePhotoAsync(
                new StoreCameraMediaOptions
                {
                    SaveToAlbum = true,
                    Directory = "CameraAppAlbum",
                    PhotoSize = PhotoSize.Small
                }
            );

            if (file == null)
            {
                return;
            }
            else
            {
                TakePhoto_btn.IsVisible = false;
            }
            
            ImagePreview.Source = ImageSource.FromStream(() => file.GetStream());

            //Upload para o Azure
            //BlobService blobService = new BlobService();
            //await blobService.UploadImage("photos", Guid.NewGuid().ToString() + ".jpg", file.GetStream(), "image/jpg");
        }
    }
}