using WiredBrainCoffee.CustomersApp.Model;

namespace WiredBrainCoffee.CustomersApp.ViewModel
{
    public class ProductItemViewModel : ViewModelBase
    {
        private Product _model;

        public string? Name
        {
            get => _model.Name;
            set 
            { 
                _model.Name = value;
                RaisePropertyChanged();
            }
        }

        public string? Description
        {
            get => _model.Description;
            set 
            { 
                _model.Description = value;
                RaisePropertyChanged();
            }
        }

        public ProductItemViewModel(Product model)
        {
            _model = model;
            RaisePropertyChanged();
        }
    }
}
