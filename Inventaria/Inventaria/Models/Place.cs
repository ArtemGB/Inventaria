using System;
using System.Collections.ObjectModel;
using System.Linq;

namespace Inventaria.Models
{
    public class Place : Item
    {
        #region Propreties
        private static int count = 0;
        public int ID { get; }
        public PlaceCategory Category { get; set; }
        public readonly ObservableCollection<InventoryObject> InventoryObjects;
        #endregion 

        public Place() : this("", "", PlaceCategory.Other) { }

        public Place(string PlName, string PlDiscr, PlaceCategory placeCategory) : base(PlName, PlDiscr)
        {
            ID = ++count;
            Category = placeCategory;
            InventoryObjects = new ObservableCollection<InventoryObject>();
        }

        public void AddInventoryObject(InventoryObject inventoryObject)
        {
            InventoryObjects.Add(inventoryObject);
        }

        /// <summary>
        /// Удаляет предмет по ID, если предмета с таким ID нет, то генерирует исключение.
        /// </summary>
        /// <param name="Id"></param>
        public void RemoveInventoryObjectByID(int Id)
        {
            InventoryObjects.Remove(InventoryObjects?.Single(invObj => invObj.ID == Id) ?? throw new ArgumentException($"There is no object with id = {Id}"));
        }
    }
}
