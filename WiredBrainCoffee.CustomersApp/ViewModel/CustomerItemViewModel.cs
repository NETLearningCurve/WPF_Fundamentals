﻿using WiredBrainCoffee.CustomersApp.Model;

namespace WiredBrainCoffee.CustomersApp.ViewModel
{
    public class CustomerItemViewModel : ViewModelBase
    {
        private Customer _model;

        public int Id => _model.Id;

        public string? FirstName
        {
            get => _model.FirstName;
            set 
            { 
                _model.FirstName = value;
                RaisePropertyChanged();
            }
        }

        public string? LastName
        {
            get => _model.LastName;
            set 
            { 
                _model.LastName = value;
                RaisePropertyChanged();
            }
        }

        public bool IsDeveloper
        {
            get => _model.IsDeveloper;
            set 
            { 
                _model.IsDeveloper = (bool)value;
                RaisePropertyChanged();
            }
        }

        public CustomerItemViewModel(Customer model)
        {
            _model = model;
            RaisePropertyChanged();
        }
    }
}