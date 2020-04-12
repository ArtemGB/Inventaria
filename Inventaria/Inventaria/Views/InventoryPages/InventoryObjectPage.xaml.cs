using System.Collections.ObjectModel;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Inventaria.Views.InvertoryPages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class InventoryObjectPage : ContentPage
    {
        public ObservableCollection<string> Items { get; set; }

        public InventoryObjectPage()
        {
            InitializeComponent();
        }

    }
}
