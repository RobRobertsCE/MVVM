using Advantage.MVVM.ViewModels;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Advantage.MVVM.Views
{
    public partial class ViewBase : Form
    {
        public ViewBase()
        {
            InitializeComponent();
        }

        protected virtual void InitializeViewBase(ViewModelBase viewModel)
        {
            viewModel.CloseFormRequested += _viewModel_CloseFormRequested;

            viewModel.DisplayExceptionHandler = ExceptionHandler;
            viewModel.ConfirmationPromptHandler = ConfirmAction;
            viewModel.DisplayMessageHandler = DisplayMessage;
        }

        #region viewmodel event handlers

        protected void _viewModel_CloseFormRequested(object sender, EventArgs e)
        {
            Close();
        }

        protected void ExceptionHandler(string message, Exception ex)
        {
            // Logging goes here
            Console.WriteLine(ex.ToString());
            DisplayMessage(message);
        }

        protected bool ConfirmAction(string prompt)
        {
            var dialogResult = MessageBox.Show(this, prompt, "Confirm Action", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            return (dialogResult == DialogResult.Yes);
        }

        protected void DisplayMessage(string message)
        {
            MessageBox.Show(message);
        }

        #endregion
    }
}
