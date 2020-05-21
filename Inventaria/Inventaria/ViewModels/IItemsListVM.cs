using System.ComponentModel;
using System.Windows.Input;
using Xamarin.Forms;

namespace Inventaria.ViewModels
{
    interface IItemsListVM : INotifyPropertyChanged
    {
        ICommand CreateItemCommand { get; }
        ICommand DeleteItemCommand { get; }
        ICommand SaveItemCommand { get; }
        ICommand BackCommand { get; }
        ICommand SelectItemCommand { get; }
        ICommand ConfirmChangingCommand { get; }
        ICommand EditItemCommand { get; }
        INavigation Navigation { get; }

        void OnPropertyChanged(string propName);
        void CreateItem();
        void DeleteItem(object ItemObject);
        void SaveItem(object ItemObject);
        void Back();
        void SelectItem(object ItemObject);
        void ConfirmChanging(object ItemObject);
        void EditItem(object ItemObject);
    }
}
