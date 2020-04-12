using Inventaria.ViewModels;
using System.Collections.Generic;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Inventaria.Views.ItemsPages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AddItemPage : ContentPage
    {
        public PlaceViewModel PViewModel { get; private set; }
        public InventoryObjectViewModel InvViewModel { get; private set; }
        public AddItemPage(object viewModel)
        {
            InitializeComponent();
            if (viewModel is PlaceViewModel)
            {
                PViewModel = viewModel as PlaceViewModel;
                BindingContext = PViewModel;
                Title = "Добавление нового места";
                string[] Categories = { "Дом", "Офис", "Склад", "Предприятие", "Кабинет", "Комната", "Другое" };
                foreach (var cat in Categories)
                    CategoryPicker.Items.Add(cat);
            }
            if(viewModel is InventoryObjectViewModel)
            {
                InvViewModel = viewModel as InventoryObjectViewModel;
                BindingContext = InvViewModel;
                Title = "Добавление нового объекта";
            }
        }

        private async void ConfirmToolbarItem_Clicked(object sender, System.EventArgs e)
        {
            if (string.IsNullOrEmpty(NameEntry.Text?.Trim()))
                await DisplayAlert("Введите данные", "Вы не ввели название.", "Ок");
        }
    }
}