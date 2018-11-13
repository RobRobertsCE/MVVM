using System;

namespace Advantage.MVVM
{
    public interface ICommand
    {
        event EventHandler CanExecuteChanged;

        bool CanExecute(object parameter);
        void Execute(object parameter);
    }
}