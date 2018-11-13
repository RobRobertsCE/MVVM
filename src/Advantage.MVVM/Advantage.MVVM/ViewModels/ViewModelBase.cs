using System;

namespace Advantage.MVVM.ViewModels
{
    public abstract class ViewModelBase : BindableBase
    {
        #region delegates

        public delegate bool ConfirmationPromptDelegate(string prompt);
        protected virtual bool OnConfirmationPrompt(string prompt)
        {
            if (ConfirmationPromptHandler != null)
            {
                return ConfirmationPromptHandler.Invoke(prompt);
            }
            else
            {
                return false;
            }
        }

        public delegate void DisplayMessageDelegate(string message);
        protected virtual void OnDisplayMessage(string message)
        {
            DisplayMessageHandler?.Invoke(message);
        }

        public delegate void DisplayExceptionDelegate(string message, Exception ex);
        protected virtual void OnDisplayException(string message, Exception ex)
        {
            DisplayExceptionHandler?.Invoke(message, ex);
        }

        #endregion

        #region events

        public event EventHandler CloseFormRequested;
        protected virtual void OnCloseFormRequested()
        {
            CloseFormRequested?.Invoke(this, EventArgs.Empty);
        }

        #endregion

        #region properties

        public ConfirmationPromptDelegate ConfirmationPromptHandler { get; set; }
        public DisplayMessageDelegate DisplayMessageHandler { get; set; }
        public DisplayExceptionDelegate DisplayExceptionHandler { get; set; }

        #endregion

        #region ctor

        protected ViewModelBase()
        {

        }

        #endregion
    }
}
