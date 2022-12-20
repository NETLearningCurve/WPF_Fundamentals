using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;

namespace WiredBrainCoffee.CustomersApp.ViewModel
{
    public class ViewModelBase : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler? PropertyChanged;

        // This method can be called from the status of
        // the properties to raise the PropertyChanged event.
        protected virtual void RaisePropertyChanged([CallerMemberName] string? propertyName = null)
        {
            // invoking the PropertyChanged event for this ViewModel instance
            // and passing a PropertyChangedEventArgs instance. It requires
            // a property name.
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public virtual Task LoadAsync() => Task.CompletedTask;
    }
}
