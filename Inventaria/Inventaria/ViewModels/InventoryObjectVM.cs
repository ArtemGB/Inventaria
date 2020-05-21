using Inventaria.Models;
using System;
using System.ComponentModel;
using Xamarin.Forms;

namespace Inventaria.ViewModels
{
    public class InventoryObjectVM : IItemVM
    {
        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged(string propName) => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propName));
        private InventoryListVM inventoryListVM;

        public InventoryObjectVM()
        {
            InventoryObject = new InventoryObject();
        }

        public class Buffer
        {
            public string Name { get; set; }
            public string Owner { get; set; }
            public string Description { get; set; }
            public int Category { get; set; }
            public bool IsValid
            {
                get => (!string.IsNullOrEmpty(Name?.Trim()));
            }
        }
        public Buffer PropertiesBuffer { get; set; }

        #region Properties

        public InventoryObject InventoryObject { get; private set; }

        public InventoryListVM ListViewModel
        {
            get => inventoryListVM;
            set
            {
                if (inventoryListVM != value)
                {
                    inventoryListVM = value;
                    OnPropertyChanged("ListViewModel");
                }
            }
        }

        public int InventoryNumber
        {
            get => InventoryObject.InventoryNumber;
            set
            {
                if (InventoryObject.InventoryNumber != value)
                {
                    InventoryObject.InventoryNumber = value;
                    OnPropertyChanged("InventoryNumber");
                }
            }
        }

        public string Owner
        {
            get => InventoryObject.Owner;
            set
            {
                if (InventoryObject.Owner != value)
                {
                    InventoryObject.Owner = value;
                    OnPropertyChanged("Owner");
                }
            }
        }

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
                    OnPropertyChanged("CategoryImage");
                }
            }
        }

        public ImageSource InventoryObjectIcon
        {
            get => CategoryImage;
        }

        public ImageSource CategoryImage
        {
            get
            {
                switch (Category)
                {
                    case 0:
                        return ImageSource.FromFile("Food.png");
                    case 1:
                        return ImageSource.FromFile("Electronics.png");
                    case 2:
                        return ImageSource.FromFile("Technics.png");
                    case 3:
                        return ImageSource.FromFile("Equipment.png");
                    case 4:
                        return ImageSource.FromFile("Tools.png");
                    case 5:
                        return ImageSource.FromFile("HouseholdSupllies.png");
                    case 6:
                        return ImageSource.FromFile("Sport.png");
                    case 7:
                        return ImageSource.FromFile("ConstructMaterials.png");
                    case 8:
                        return ImageSource.FromFile("Clothing.png");
                    case 9:
                        return ImageSource.FromFile("Furniture.png");
                    default:
                        return ImageSource.FromFile("Other.png"); ;
                }
            }
        }

        public bool IsValid => !String.IsNullOrEmpty(Name.Trim());

        #endregion
    }
}
