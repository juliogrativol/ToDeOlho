using Modelo;
using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ToDeOlho
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Publicacoes : ContentPage
    {
        public ObservableCollection<Publicacao> Items { get; set; }

        public Publicacoes()
        {
            InitializeComponent();

            Items = new ObservableCollection<Publicacao>();

            Publicacao publicacao = new Publicacao();
            publicacao.Titulo = "Buraco na minha rua";
            publicacao.Data = "17/09/2018";

            Publicacao publicacao2 = new Publicacao();
            publicacao2.Titulo = "Cadê o lixeiro";
            publicacao2.Data = "17/09/2018";

            Publicacao publicacao3 = new Publicacao();
            publicacao3.Titulo = "Quase quebrei meu carro";
            publicacao3.Data = "17/09/2018";

            Items.Add(publicacao);
            Items.Add(publicacao2);
            Items.Add(publicacao3);

            MyListView.ItemsSource = Items;
        }

        async void Handle_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            if (e.Item == null)
                return;

            await DisplayAlert("Item", ((Publicacao) e.Item).Titulo, "OK");

            //Deselect Item
            ((ListView)sender).SelectedItem = null;
        }

        private void btn_novaPublicacao_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new NovaPublicacao());
        }
    }
}
