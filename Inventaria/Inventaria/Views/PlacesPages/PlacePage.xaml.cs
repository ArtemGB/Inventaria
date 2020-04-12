using Inventaria.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Inventaria.Views.PlacesPages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class PlacePage : ContentPage
    {
        public PlaceViewModel ViewModel { get; private set; }
        public PlacePage(PlaceViewModel viewModel)
        {
            InitializeComponent();
            ViewModel = viewModel;
            this.BindingContext = ViewModel;

        }
    }
}