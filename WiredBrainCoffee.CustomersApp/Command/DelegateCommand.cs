using System;
using System.Windows.Input;

namespace WiredBrainCoffee.CustomersApp.Command
{
    public class DelegateCommand : ICommand
    {
        private Action<object?> _execute;

        // delegate for the CanExecute() delegate
        private Func<object?, bool>? _canExecute;
        
        public DelegateCommand(Action<object> execute, Func<object?, bool>? canExecute = null)
        {
            // checking that the execute Action is not null
            ArgumentNullException.ThrowIfNull(execute);    
            _execute = execute;

            _canExecute = canExecute;   
        }

        // method that allows to raise the CanExecuteChanged event on 
        // the DelegateCommand instance
        public void RaiseCanExecuteChanged() => CanExecuteChanged?.Invoke(this, EventArgs.Empty);

        public event EventHandler? CanExecuteChanged;

        public bool CanExecute(object? parameter) => _canExecute is null || _canExecute(parameter);        

        public void Execute(object? parameter) => _execute(parameter);        
    }
}
