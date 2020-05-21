using Inventaria.Views.ItemsPages;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows.Input;
using Xamarin.Forms;
using Inventaria.Views.InventoryObjectsPages;

namespace Inventaria.ViewModels
{
    public class InventoryListVM : IItemsListVM
    {
        public ICommand CreateItemCommand { get; protected set; }

        public ICommand DeleteItemCommand { get; set; }

        public ICommand SaveItemCommand { get; set; }

        public ICommand BackCommand { get; set; }

        public ICommand SelectItemCommand { get; set; }

        public ICommand ConfirmChangingCommand { get; set; }

        public ICommand EditItemCommand { get; set; }

        public INavigation Navigation { get; set; }

        public event PropertyChangedEventHandler PropertyChanged;

        public ObservableCollection<InventoryObjectVM> InventoryObjects { get; set; }

        public InventoryListVM()
        {
            InventoryObjects = new ObservableCollection<InventoryObjectVM>();
            CreateItemCommand = new Command(CreateItem);
            DeleteItemCommand = new Command(DeleteItem);
            SaveItemCommand = new Command(SaveItem);
            SelectItemCommand = new Command(SelectItem);
            ConfirmChangingCommand = new Command(ConfirmChanging);
            EditItemCommand = new Command(EditItem);
            BackCommand = new Command(Back);
        }

        public void Back() => Navigation.PopAsync();

        public void ConfirmChanging(object ItemObject)
        {
            InventoryObjectVM inventoryObject = ItemObject as InventoryObjectVM;
            if (inventoryObject != null && inventoryObject.PropertiesBuffer.IsValid)
            {
                inventoryObject.Name = inventoryObject.PropertiesBuffer.Name;
                inventoryObject.Description = inventoryObject.PropertiesBuffer.Description;
                inventoryObject.Category = inventoryObject.PropertiesBuffer.Category;
                inventoryObject.PropertiesBuffer = null;
                Back();
            }
        }

        public void CreateItem() => Navigation.PushAsync(new AddItemPage(new InventoryObjectVM() { ListViewModel = this }));

        public void DeleteItem(object ItemObject)
        {
            InventoryObjectVM InventoryObject = ItemObject as InventoryObjectVM;
            InventoryObjects?.Remove(InventoryObject);
        }

        public void EditItem(object ItemObject)
        {
            InventoryObjectVM InventoryObject = ItemObject as InventoryObjectVM;
            if (InventoryObject != null)
            {
                InventoryObject.PropertiesBuffer = new InventoryObjectVM.Buffer
                {
                    Name = InventoryObject.Name,
                    Description = InventoryObject.Description,
                    Category = InventoryObject.Category,
                    Owner = InventoryObject.Owner
                };
                Navigation.PushAsync(new EditItemPage(InventoryObject));
            }
        }

        public void OnPropertyChanged(string propName) => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propName));
        public void SaveItem(object ItemObject)
        {
            InventoryObjectVM InventoryObject = ItemObject as InventoryObjectVM;
            if (InventoryObject != null && InventoryObject.IsValid)
            {
                InventoryObjects.Add(InventoryObject);
                Back();
            }
        }

        public void SelectItem(object ItemObject)
        {
            InventoryObjectVM InventoryObject = ItemObject as InventoryObjectVM;
            if (InventoryObject != null)
                Navigation.PushAsync(new InventoryObjectPage(InventoryObject));
        }
    }
}
