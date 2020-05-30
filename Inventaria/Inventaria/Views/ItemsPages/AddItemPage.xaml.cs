using Inventaria.ViewModels;
using System.Collections.Generic;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Inventaria.Views.ItemsPages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AddItemPage : ContentPage
    {
        public PlaceVM PViewModel { get; private set; }
        public InventoryObjectVM InvViewModel { get; private set; }
        public AddItemPage(IItemVM viewModel)
        {
            InitializeComponent();
            if (viewModel is PlaceVM)
            {
                PViewModel = viewModel as PlaceVM;
                BindingContext = PViewModel;
                Title = "Добавление места";
                string[] Categories = { "Дом", "Офис", "Склад", "Предприятие", "Кабинет", "Комната", "Другое" };
                foreach (var cat in Categories)
                    CategoryPicker.Items.Add(cat);
            }
            if(viewModel is InventoryObjectVM)
            {
                InvViewModel = viewModel as InventoryObjectVM;
                BindingContext = InvViewModel;
                Title = "Добавление предмета";
                string[] Categories = { "Еда", "Электроника","Техника","Оборудование","Инструменты","Хозяйственные принадлежности","Спорт", "Строительные материалы",
                                        "Одежда", "Мебель", "Другое" };
                foreach (var cat in Categories)
                    CategoryPicker.Items.Add(cat);
            }
        }

        private async void ConfirmToolbarItem_Clicked(object sender, System.EventArgs e)
        {
            if (string.IsNullOrEmpty(NameEntry.Text?.Trim()))
                await DisplayAlert("Введите данные", "Вы не ввели название.", "Ок");
        }
    }
}