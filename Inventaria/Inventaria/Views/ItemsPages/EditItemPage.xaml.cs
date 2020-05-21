using Inventaria.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Inventaria.Views.ItemsPages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class EditItemPage : ContentPage
    {
        public PlaceVM PViewModel { get; private set; }
        public InventoryObjectVM InvViewModel { get; private set; }
        public EditItemPage(IItemVM viewModel)
        {
            InitializeComponent();
            if (viewModel is PlaceVM)
            {
                PViewModel = viewModel as PlaceVM;
                BindingContext = PViewModel;
                string[] Categories = { "Дом", "Офис", "Склад", "Предприятие", "Кабинет", "Комната", "Другое" };
                foreach (var cat in Categories)
                    CategoryPicker.Items.Add(cat);
                CategoryPicker.SelectedIndex = PViewModel.Category;
            }
            if (viewModel is InventoryObjectVM)
            {
                InvViewModel = viewModel as InventoryObjectVM;
                BindingContext = InvViewModel;
                string[] Categories = { "Еда", "Электроника","Техника","Оборудование","Инструменты","Хозяйственные принадлежности","Спорт", "Строительные материалы",
                                        "Одежда", "Мебель", "Другое" };
                foreach (var cat in Categories)
                    CategoryPicker.Items.Add(cat);
                CategoryPicker.SelectedIndex = InvViewModel.Category;
            }
        }

        private async void ConfirmToolbarItem_Clicked(object sender, System.EventArgs e)
        {
            if (string.IsNullOrEmpty(NameEntry.Text?.Trim()))
                await DisplayAlert("Введите данные", "Вы не ввели название.", "Ок");
        }
    }
}