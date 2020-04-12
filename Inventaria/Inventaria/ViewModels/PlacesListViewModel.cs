using System.Collections.ObjectModel;
using System.Windows.Input;
using Xamarin.Forms;
using System.ComponentModel;
using Inventaria.Views.PlacesPages;
using Inventaria.Views.ItemsPages;

namespace Inventaria.ViewModels
{
    public class PlacesListViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        public ObservableCollection<PlaceViewModel> Places { get; set; }

        public ICommand CreatePlaceCommand { get; protected set; }
        public ICommand DeletePlaceCommand { get; protected set; }
        public ICommand SavePlaceCommand { get; private set; }
        public ICommand BackCommand { get; private set; }
        public ICommand SelectPlaceCommand { get; private set; }
        public ICommand ConfirmChangingCommand { get; private set; }
        public ICommand EditPlaceCommand { get; private set; }

        public INavigation Navigation { get; set; }

        public PlacesListViewModel()
        {
            Places = new ObservableCollection<PlaceViewModel>();
            CreatePlaceCommand = new Command(CreatePlace);
            DeletePlaceCommand = new Command(DeletePlace);
            SavePlaceCommand = new Command(SavePlace);
            SelectPlaceCommand = new Command(SelectPlace);
            ConfirmChangingCommand = new Command(ConfirmChanging);
            EditPlaceCommand = new Command(EditPlace);
            BackCommand = new Command(Back);
        }

        protected void OnPropertyChanged(string propName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propName));
        }

        public void SelectPlace(object PlaceObject)
        {
            PlaceViewModel Place = PlaceObject as PlaceViewModel;
            if (Place != null)
                Navigation.PushAsync(new PlacePage(Place));
        }

        private void CreatePlace()
        {
            Navigation.PushAsync(new AddItemPage(new PlaceViewModel() { ListViewModel = this }));
        }
        private void Back()
        {
            Navigation.PopAsync();
        }
        private void SavePlace(object PlaceObject)
        {
            PlaceViewModel Place = PlaceObject as PlaceViewModel;
            if (Place != null && Place.IsValid)
            {
                Places.Add(Place);
                Back();
            }
        }
        private void DeletePlace(object PlaceObject)
        {
            PlaceViewModel Place = PlaceObject as PlaceViewModel;
            Places?.Remove(Place);
            Back();
        }

        private void ConfirmChanging(object PlaceObject)
        {
            PlaceViewModel Place = PlaceObject as PlaceViewModel;
            if (Place != null && Place.PropertiesBuffer.IsValid)
            {
                Place.Name = Place.PropertiesBuffer.Name;
                Place.Description = Place.PropertiesBuffer.Description;
                Place.Category = Place.PropertiesBuffer.Category;
                Place.PropertiesBuffer = null;
                Back();
            }
        }

        private void EditPlace(object PlaceObject)
        {
            PlaceViewModel Place = PlaceObject as PlaceViewModel;
            if (Place != null)
            {
                Place.PropertiesBuffer = new PlaceViewModel.Buffer
                {
                    Name = Place.Name,
                    Description = Place.Description,
                    Category = Place.Category
                };
                Navigation.PushAsync(new EditPlacePage(Place));
            }
        }
    }
}
