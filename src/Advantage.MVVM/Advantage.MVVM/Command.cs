using System;

namespace Advantage.MVVM
{
    public class Command : ICommand
    {
        #region events

        public event EventHandler CanExecuteChanged;

        protected virtual void OnCanExecuteChanged()
        {
            CanExecuteChanged?.Invoke(this, EventArgs.Empty);
        }

        #endregion

        #region events

        readonly Action<object> _execute;
        readonly Predicate<object> _canExecute;

        #endregion

        #region ctor

        public Command(Action<object> execute)
           : this(execute, null)
        {

        }

        public Command(Action<object> execute, Predicate<object> canExecute)
        {
            _execute = execute ?? throw new ArgumentNullException(nameof(execute));
            _canExecute = canExecute;
        }

        #endregion

        #region public

        public bool CanExecute(object parameter)
        {
            return _canExecute == null ? true : _canExecute(parameter);
        }

        public void Execute(object parameter)
        {
            _execute(parameter);
        }

        #endregion

    }
}
