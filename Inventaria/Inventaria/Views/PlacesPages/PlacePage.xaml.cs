using Inventaria.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Inventaria.Views.PlacesPages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class PlacePage : ContentPage
    {
        public PlaceVM ViewModel { get; private set; }
        public PlacePage(PlaceVM viewModel)
        {
            InitializeComponent();
            ViewModel = viewModel;
            ViewModel.InventoryListVM.Navigation = this.Navigation;
            ViewModel.InventoryListVM.InventoryObjects.Add(new InventoryObjectVM() { Name = "1", Category = 1, Description = "qedqe", ListViewModel = ViewModel.InventoryListVM });
            ViewModel.InventoryListVM.InventoryObjects.Add(new InventoryObjectVM() { Name = "2", Category = 2, Description = "qedqe", ListViewModel = ViewModel.InventoryListVM });
            ViewModel.InventoryListVM.InventoryObjects.Add(new InventoryObjectVM() { Name = "3", Category = 3, Description = "qedqe", ListViewModel = ViewModel.InventoryListVM });
            ViewModel.InventoryListVM.InventoryObjects.Add(new InventoryObjectVM() { Name = "4", Category = 4, Description = "qedqe", ListViewModel = ViewModel.InventoryListVM });
            ViewModel.InventoryListVM.InventoryObjects.Add(new InventoryObjectVM() { Name = "5", Category = 5, Description = "qedqe", ListViewModel = ViewModel.InventoryListVM });
            ViewModel.InventoryListVM.InventoryObjects.Add(new InventoryObjectVM() { Name = "6", Category = 6, Description = "qedqe", ListViewModel = ViewModel.InventoryListVM });
            ViewModel.InventoryListVM.InventoryObjects.Add(new InventoryObjectVM() { Name = "7", Category = 1, Description = "qedqe", ListViewModel = ViewModel.InventoryListVM });
            ViewModel.InventoryListVM.InventoryObjects.Add(new InventoryObjectVM() { Name = "8", Category = 2, Description = "qedqe", ListViewModel = ViewModel.InventoryListVM });
            ViewModel.InventoryListVM.InventoryObjects.Add(new InventoryObjectVM() { Name = "9", Category = 3, Description = "qedqe", ListViewModel = ViewModel.InventoryListVM });
            ViewModel.InventoryListVM.InventoryObjects.Add(new InventoryObjectVM() { Name = "10", Category = 4, Description = "qedqe", ListViewModel = ViewModel.InventoryListVM });
            ViewModel.InventoryListVM.InventoryObjects.Add(new InventoryObjectVM() { Name = "11", Category = 5, Description = "qedqe", ListViewModel = ViewModel.InventoryListVM });
            ViewModel.InventoryListVM.InventoryObjects.Add(new InventoryObjectVM() { Name = "12", Category = 6, Description = "qedqe", ListViewModel = ViewModel.InventoryListVM });
            ViewModel.InventoryListVM.InventoryObjects.Add(new InventoryObjectVM() { Name = "13", Category = 1, Description = "qedqe", ListViewModel = ViewModel.InventoryListVM });
            ViewModel.InventoryListVM.InventoryObjects.Add(new InventoryObjectVM() { Name = "14", Category = 2, Description = "qedqe", ListViewModel = ViewModel.InventoryListVM });
            ViewModel.InventoryListVM.InventoryObjects.Add(new InventoryObjectVM() { Name = "15", Category = 3, Description = "qedqe", ListViewModel = ViewModel.InventoryListVM });
            ViewModel.InventoryListVM.InventoryObjects.Add(new InventoryObjectVM() { Name = "16", Category = 4, Description = "qedqe", ListViewModel = ViewModel.InventoryListVM });
            this.BindingContext = ViewModel;

        }
    }
}