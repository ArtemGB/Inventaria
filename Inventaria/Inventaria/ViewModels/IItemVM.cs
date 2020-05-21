using System.ComponentModel;

namespace Inventaria.ViewModels
{
    public interface IItemVM : INotifyPropertyChanged
    {
        string Name { get; set; }
        bool IsValid { get; }
    }
}
