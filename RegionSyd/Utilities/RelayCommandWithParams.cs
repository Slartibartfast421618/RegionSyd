﻿using System.Windows.Input;

namespace RegionSyd.Utilities
{
    public class RelayCommandWithParams : ICommand
    {
        // CLASS NOTE: Using two RelayCommands, one for simple, one for added parameters
        private Action<object> _execute;
        private Func<object, bool> _canExecute;

        event EventHandler? ICommand.CanExecuteChanged
        {
            add
            {
                CommandManager.RequerySuggested += value;
            }

            remove
            {
                CommandManager.RequerySuggested -= value;
            }
        }

        public RelayCommandWithParams(Action<object> execute, Func<object, bool> canExecute = null)
        {
            _execute = execute;
            _canExecute = canExecute;
        }

        bool ICommand.CanExecute(object? parameter)
        {
            return _canExecute == null || _canExecute(parameter);
        }

        void ICommand.Execute(object? parameter)
        {
            _execute(parameter);
        }
    }
}
