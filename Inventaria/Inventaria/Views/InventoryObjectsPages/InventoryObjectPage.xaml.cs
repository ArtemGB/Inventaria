using Inventaria.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Inventaria.Views.InventoryObjectsPages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class InventoryObjectPage : ContentPage
    {
        InventoryObjectVM inventoryObjectVM;
        public InventoryObjectPage(InventoryObjectVM vm)
        {
            InitializeComponent();
            inventoryObjectVM = vm;
            BindingContext = inventoryObjectVM;
        }
    }
}