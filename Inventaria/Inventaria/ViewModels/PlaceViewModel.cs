using System.ComponentModel;
using Xamarin.Forms;
using Inventaria.Models;
using System.Collections.ObjectModel;

namespace Inventaria.ViewModels
{
    public class PlaceViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        PlacesListViewModel placesListVM;

        public PlaceViewModel()
        {
            Place = new Place();
        }

        public PlaceViewModel(Place place)
        {
            Place = place;
        }

        #region Properties

        public class Buffer
        {
            public string Name { get; set; }
            public string Description { get; set; }
            public int Category { get; set; }
            public bool IsValid
            {
                get => (!string.IsNullOrEmpty(Name?.Trim()));
            }
        }
        public Buffer PropertiesBuffer { get; set; }
        public Place Place { get; private set; }
        public PlacesListViewModel ListViewModel
        {
            get { return placesListVM; }
            set
            {
                if (placesListVM != value)
                {
                    placesListVM = value;
                    OnPropertyChanged("ListViewModel");
                }
            }
        }
        public string Name
        {
            get => Place.Name;
            set
            {
                if (Place.Name != value)
                {
                    Place.Name = value;
                    OnPropertyChanged("Name");
                }
            }
        }
        public string Description
        {
            get => Place.Description;
            set
            {
                if (Place.Description != value)
                {
                    Place.Description = value;
                    OnPropertyChanged("Description");
                }
            }
        }
        public int Category
        {
            get => (int)Place.Category;
            set
            {
                if ((int)Place.Category != value)
                {
                    Place.Category = (PlaceCategory)value;
                    OnPropertyChanged("Category");
                    OnPropertyChanged("CategoryImage");
                }
            }
        }
        public ObservableCollection<InventoryObject> InventoryObjects
        {
            get => Place.InventoryObjects;
        }
        public int ID { get => Place.ID; }
        public ImageSource CategoryImage
        {
            get
            {
                switch (Category)
                {
                    case 0:
                        return ImageSource.FromFile("Home.png");
                    case 1:
                        return ImageSource.FromFile("Warehouse.png");
                    case 2:
                        return ImageSource.FromFile("Office.png");
                    case 3:
                        return ImageSource.FromFile("Factory.png");
                    case 4:
                        return ImageSource.FromFile("Cabinet.png");
                    case 5:
                        return ImageSource.FromFile("LivingRoom.png");
                    default:
                        return null;
                }
            }
        }

        #endregion
        public bool IsValid
        {
            get => (!string.IsNullOrEmpty(Name?.Trim()));
        }

        protected void OnPropertyChanged(string propName) => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propName));
    }
}
