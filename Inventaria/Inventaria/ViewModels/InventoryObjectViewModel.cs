using Inventaria.Models;
using System.ComponentModel;
using Xamarin.Forms;

namespace Inventaria.ViewModels
{
    public class InventoryObjectViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged(string propName) => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propName));

        #region Properties

        public InventoryObject InventoryObject { get; private set; }
        public string Name
        {
            get => InventoryObject.Name;
            set
            {
                if (InventoryObject.Name != value)
                {
                    InventoryObject.Name = value;
                    OnPropertyChanged("Name");
                }
            }
        }
        public string Description
        {
            get => InventoryObject.Description;
            set
            {
                if (InventoryObject.Description != value)
                {
                    InventoryObject.Description = value;
                    OnPropertyChanged("Description");
                }
            }
        }

        public int Category
        {
            get => (int)InventoryObject.Category;
            set
            {
                if ((int)InventoryObject.Category != value)
                {
                    InventoryObject.Category = (InventoryCategory)value;
                    OnPropertyChanged("Category");
                }
            }
        }

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
    }
}
