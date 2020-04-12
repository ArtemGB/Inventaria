using Inventaria.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Inventaria.Views.PlacesPages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AddPlacePage : ContentPage
    {
        public PlaceViewModel ViewModel { get; private set; }
        public AddPlacePage(PlaceViewModel placeViewModel)
        {
            InitializeComponent();
            ViewModel = placeViewModel;
            this.BindingContext = ViewModel;
        }

        private async void ConfirmToolbarItem_Clicked(object sender, System.EventArgs e)
        {
            if (string.IsNullOrEmpty(NameEntry.Text?.Trim()))
                await DisplayAlert("Введите данные", "Вы не ввели название.", "Ок");
        }
    }
}