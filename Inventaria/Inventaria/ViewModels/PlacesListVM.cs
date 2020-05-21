using Inventaria.Views.ItemsPages;
using Inventaria.Views.PlacesPages;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows.Input;
using Xamarin.Forms;

namespace Inventaria.ViewModels
{
    public class PlacesListVM : IItemsListVM
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
        public ObservableCollection<PlaceVM> Places { get; set; }

        public PlacesListVM()
        {
            Places = new ObservableCollection<PlaceVM>();
            CreateItemCommand = new Command(CreateItem);
            DeleteItemCommand = new Command(DeleteItem);
            SaveItemCommand = new Command(SaveItem);
            SelectItemCommand = new Command(SelectItem);
            ConfirmChangingCommand = new Command(ConfirmChanging);
            EditItemCommand = new Command(EditItem);
            BackCommand = new Command(Back);
        }

        public void OnPropertyChanged(string propName) => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propName));

        public void Back() => Navigation.PopAsync();

        public void ConfirmChanging(object ItemObject)
        {
            PlaceVM Place = ItemObject as PlaceVM;
            if (Place != null && Place.PropertiesBuffer.IsValid)
            {
                Place.Name = Place.PropertiesBuffer.Name;
                Place.Description = Place.PropertiesBuffer.Description;
                Place.Category = Place.PropertiesBuffer.Category;
                Place.Owner = Place.PropertiesBuffer.Owner;
                Place.PropertiesBuffer = null;
                Back();
            }
        }

        public void CreateItem() => Navigation.PushAsync(new AddItemPage(new PlaceVM() { ListViewModel = this }));

        public void DeleteItem(object ItemObject)
        {
            PlaceVM Place = ItemObject as PlaceVM;
            Places?.Remove(Place);
        }

        public void EditItem(object ItemObject)
        {
            PlaceVM Place = ItemObject as PlaceVM;
            if (Place != null)
            {
                Place.PropertiesBuffer = new PlaceVM.Buffer
                {
                    Name = Place.Name,
                    Description = Place.Description,
                    Category = Place.Category,
                    Owner = Place.Owner
                };
                Navigation.PushAsync(new EditItemPage(Place));
            }
        }

        public void SaveItem(object ItemObject)
        {
            PlaceVM Place = ItemObject as PlaceVM;
            if (Place != null && Place.IsValid)
            {
                Places.Add(Place);
                Back();
            }
        }

        public void SelectItem(object ItemObject)
        {
            PlaceVM Place = ItemObject as PlaceVM;
            if (Place != null)
                Navigation.PushAsync(new PlacePage(Place));
        }
    }
}
