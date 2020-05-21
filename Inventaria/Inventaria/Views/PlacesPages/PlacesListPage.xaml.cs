using Inventaria.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Inventaria.Views.PlacesPages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class PlacesListPage : ContentPage
    {
        public PlacesListPage()
        {
            InitializeComponent();
            PlacesListVM lvm = new PlacesListVM() { Navigation = this.Navigation };
            lvm.Places.Add((new PlaceVM(new Models.Place("Home", "My home", Models.PlaceCategory.Home)) { ListViewModel = lvm }));
            lvm.Places.Add((new PlaceVM(new Models.Place("Cabinet", "My Cabinet", Models.PlaceCategory.Cabinet)) { ListViewModel = lvm }));
            lvm.Places.Add((new PlaceVM(new Models.Place("Factory", "My Factory", Models.PlaceCategory.Factory)) { ListViewModel = lvm }));
            lvm.Places.Add((new PlaceVM(new Models.Place("Office", "My Office", Models.PlaceCategory.Office)) { ListViewModel = lvm }));
            lvm.Places.Add((new PlaceVM(new Models.Place("Room", "My Room", Models.PlaceCategory.Room)) { ListViewModel = lvm }));
            lvm.Places.Add((new PlaceVM(new Models.Place("Warehouse", "My Warehouse", Models.PlaceCategory.Warehouse)) { ListViewModel = lvm }));
            lvm.Places.Add((new PlaceVM(new Models.Place("Home", "My home", Models.PlaceCategory.Home)) { ListViewModel = lvm }));
            lvm.Places.Add((new PlaceVM(new Models.Place("Cabinet", "My Cabinet", Models.PlaceCategory.Cabinet)) { ListViewModel = lvm }));
            lvm.Places.Add((new PlaceVM(new Models.Place("Factory", "My Factory", Models.PlaceCategory.Factory)) { ListViewModel = lvm }));
            lvm.Places.Add((new PlaceVM(new Models.Place("Office", "My Office", Models.PlaceCategory.Office)) { ListViewModel = lvm }));
            lvm.Places.Add((new PlaceVM(new Models.Place("Room", "My Room", Models.PlaceCategory.Room)) { ListViewModel = lvm }));
            lvm.Places.Add((new PlaceVM(new Models.Place("Warehouse", "My Warehouse", Models.PlaceCategory.Warehouse)) { ListViewModel = lvm }));
            lvm.Places.Add((new PlaceVM(new Models.Place("Home", "My home", Models.PlaceCategory.Home)) { ListViewModel = lvm }));
            lvm.Places.Add((new PlaceVM(new Models.Place("Cabinet", "My Cabinet", Models.PlaceCategory.Cabinet)) { ListViewModel = lvm }));
            lvm.Places.Add((new PlaceVM(new Models.Place("Factory", "My Factory", Models.PlaceCategory.Factory)) { ListViewModel = lvm }));
            lvm.Places.Add((new PlaceVM(new Models.Place("Office", "My Office", Models.PlaceCategory.Office)) { ListViewModel = lvm }));
            lvm.Places.Add((new PlaceVM(new Models.Place("Room", "My Room", Models.PlaceCategory.Room)) { ListViewModel = lvm }));
            lvm.Places.Add((new PlaceVM(new Models.Place("Warehouse", "My Warehouse", Models.PlaceCategory.Warehouse)) { ListViewModel = lvm }));
            BindingContext =  lvm;
        }
    }
}
