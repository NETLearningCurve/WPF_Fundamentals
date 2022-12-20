using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;

namespace WiredBrainCoffee.CustomersApp.ViewModel
{
    public class ValidationViewModelBase : ViewModelBase, INotifyDataErrorInfo
    {
        private readonly Dictionary<string, List<string>> _errorsByPropertyName = new();
        
        // it returns true if the object has errors
        public bool HasErrors => _errorsByPropertyName.Any();

        // it can be raised, and the the data binding will call again the GetErrors() method
        public event EventHandler<DataErrorsChangedEventArgs>? ErrorsChanged;

        // it returns a collection of errors for specific properties
        public IEnumerable GetErrors(string? propertyName)
        {
            return propertyName is not null && _errorsByPropertyName.ContainsKey(propertyName)
                ? _errorsByPropertyName[propertyName]
                : Enumerable.Empty<string>();
        }

        // to raise the ErrorsChanged event
        protected virtual void OnErrorsChanged(DataErrorsChangedEventArgs e) => ErrorsChanged?.Invoke(this, e);

        // using the [CallerMemberName] attribute, the compiler pass in 
        // the name of the property automatically
        protected void AddError(string error, [CallerMemberName] string? propertyName = null)
        {
            if (propertyName is null)
            {
                return;
            }

            if (!_errorsByPropertyName.ContainsKey(propertyName))
            {
                _errorsByPropertyName[propertyName] = new List<string>();
            }

            if (!_errorsByPropertyName.ContainsKey(error))
            {
                _errorsByPropertyName[propertyName].Add(error);
                OnErrorsChanged(new DataErrorsChangedEventArgs(propertyName));
                RaisePropertyChanged(nameof(HasErrors));
            }
        }

        protected void ClearErrors([CallerMemberName] string? propertyName = null)
        {
            if (propertyName is null)
            {
                return;
            }

            if (_errorsByPropertyName.ContainsKey(propertyName))
            {
                _errorsByPropertyName[propertyName].Remove(propertyName);
                OnErrorsChanged(new DataErrorsChangedEventArgs(propertyName));
                RaisePropertyChanged(nameof(HasErrors));
            }
        }
    }
}
