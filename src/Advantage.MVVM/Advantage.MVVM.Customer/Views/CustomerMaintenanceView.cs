using Advantage.MVVM.Customers.ViewModels;
using Advantage.MVVM.Views;
using System;
using System.Windows.Forms;

namespace Advantage.MVVM.Customers.Views
{
    public partial class CustomerMaintenanceView : ViewBase
    {
        #region fields

        private CustomerMaintenanceViewModel _viewModel;

        #endregion

        #region ctor

        public CustomerMaintenanceView()
        {
            InitializeComponent();
        }

        public CustomerMaintenanceView(CustomerMaintenanceViewModel viewModel)
            : this()
        {
            _viewModel = viewModel;
        }

        #endregion

        #region load

        private void CustomerMaintenanceView_Load(object sender, EventArgs e)
        {
            if (_viewModel == null)
            {
                _viewModel = new CustomerMaintenanceViewModel();
            }

            InitializeViewBase(_viewModel);

            SetBindings();

            _viewModel.LoadCustomersCommand.Execute(null);
        }

        #endregion

        #region bindings

        protected virtual void SetBindings()
        {
            try
            {
                // customers list
                cboCustomers.DataSource = _viewModel.Customers;
                cboCustomers.DisplayMember = "Name";
                cboCustomers.ValueMember = "Id";
                cboCustomers.DataSource = _viewModel.Customers;
                cboCustomers.DataBindings.Add(new Binding("SelectedValue", _viewModel, "SelectedCustomerId"));
                cboCustomers.DataBindings.Add(new Binding("Enabled", _viewModel, "CanSelectCustomer"));
                cboCustomers.SelectedIndex = -1;

                // customer properties
                txtId.DataBindings.Add(new Binding("Text", _viewModel, "Id", true, DataSourceUpdateMode.OnPropertyChanged, string.Empty));
                txtName.DataBindings.Add(new Binding("Text", _viewModel, "Name"));
                txtAge.DataBindings.Add(new Binding("Text", _viewModel, "Age", true, DataSourceUpdateMode.OnPropertyChanged, string.Empty));

                // form state buttons
                btnCancel.DataBindings.Add(new Binding("Text", _viewModel, "CancelCloseButtonText"));
                btnCancel.DataBindings.Add(new Binding("Enabled", _viewModel, "CanCancelOrCloseForm"));

                btnEdit.DataBindings.Add(new Binding("Text", _viewModel, "SaveEditButtonText"));
                btnEdit.DataBindings.Add(new Binding("Enabled", _viewModel, "CanSaveOrEditCustomer"));

                btnAdd.DataBindings.Add(new Binding("Enabled", _viewModel, "CanAddCustomer"));
                btnCopy.DataBindings.Add(new Binding("Enabled", _viewModel, "CanCopyCustomer"));
                btnDelete.DataBindings.Add(new Binding("Enabled", _viewModel, "CanDeleteCustomer"));

                // form state
                pnlList.DataBindings.Add(new Binding("Enabled", _viewModel, "CanSelectCustomer"));
                pnlDetails.DataBindings.Add(new Binding("Enabled", _viewModel, "CanEditDetails"));

            }
            catch (Exception ex)
            {
                ExceptionHandler("Error setting form bindings", ex);
            }
        }

        #endregion

        #region UI events

        private void cboCustomers_SelectedIndexChanged(object sender, EventArgs e)
        {
            _viewModel.SelectCustomerCommand.Execute(cboCustomers.SelectedValue);
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            _viewModel.AddCustomerCommand.Execute(null);
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            _viewModel.SaveEditCustomerCommand.Execute(cboCustomers.SelectedValue);
        }

        private void btnCopy_Click(object sender, EventArgs e)
        {
            _viewModel.CopyCustomerCommand.Execute(cboCustomers.SelectedValue);
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            _viewModel.DeleteCustomerCommand.Execute(cboCustomers.SelectedValue);
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            _viewModel.CancelCloseCommand.Execute(cboCustomers.SelectedValue);
        }

        #endregion
    }
}
