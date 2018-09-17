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
            Repository repository = Repository.Instance;

            Items = repository.getItems();

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
