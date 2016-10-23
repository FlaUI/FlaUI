using System;
using System.Diagnostics;
using System.Windows.Input;

namespace WpfApplication.Infrastructure
{
    public class RelayCommand : ICommand
    {
        private readonly Action<object> _methodToExecute;
        readonly Func<object, bool> _canExecuteEvaluator;

        public RelayCommand(Action<object> methodToExecute)
            : this(methodToExecute, null) { }

        public RelayCommand(Action<object> methodToExecute, Func<object, bool> canExecuteEvaluator)
        {
            _methodToExecute = methodToExecute;
            _canExecuteEvaluator = canExecuteEvaluator;
        }

        [DebuggerStepThrough]
        public bool CanExecute(object parameter)
        {
            return _canExecuteEvaluator == null || _canExecuteEvaluator.Invoke(parameter);
        }

        public event EventHandler CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }

        public void Execute(object parameter)
        {
            _methodToExecute.Invoke(parameter);
        }
    }
}
