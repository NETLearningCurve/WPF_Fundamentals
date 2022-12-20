using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;

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
        
        protected void AddError(string error, string propertyName)
        {
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

        protected void ClearErrors(string propertyName)
        {
            if (_errorsByPropertyName.ContainsKey(propertyName))
            {
                _errorsByPropertyName[propertyName].Remove(propertyName);
                OnErrorsChanged(new DataErrorsChangedEventArgs(propertyName));
                RaisePropertyChanged(nameof(HasErrors));
            }
        }
    }
}
