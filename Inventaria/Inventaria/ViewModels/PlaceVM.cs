using System.ComponentModel;
using Xamarin.Forms;
using Inventaria.Models;
using System.Collections.ObjectModel;

namespace Inventaria.ViewModels
{
    public class PlaceVM : IItemVM
    {
        public event PropertyChangedEventHandler PropertyChanged;
        PlacesListVM placesListVM;
        InventoryListVM inventoryListVM;

        public PlaceVM()
        {
            Place = new Place();
        }

        public PlaceVM(Place place)
        {
            Place = place;
            inventoryListVM = new InventoryListVM();
        }

        #region Properties

        public INavigation Navigation { get; set; }

        public class Buffer
        {
            public string Name { get; set; }
            public string Description { get; set; }
            public string Owner { get; set; }
            public int Category { get; set; }
            public bool IsValid
            {
                get => (!string.IsNullOrEmpty(Name?.Trim()));
            }
        }
        public Buffer PropertiesBuffer { get; set; }
        public Place Place { get; private set; }
        public PlacesListVM ListViewModel
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
        public InventoryListVM InventoryListVM
        {
            get => inventoryListVM;
            set
            {
                if(inventoryListVM!=value)
                {
                    inventoryListVM = value;
                    OnPropertyChanged("InventoryListVM");
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

        public string Owner
        {
            get => Place.Owner;
            set
            {
                if(value!=Place.Owner)
                {
                    Place.Owner = value;
                    OnPropertyChanged("Owner");
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
                        return ImageSource.FromFile("OtherPlace.png");
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
