using Advantage.MVVM.Customers.Models;
using Advantage.MVVM.ViewModels;
using System;
using System.ComponentModel;
using System.Linq;

namespace Advantage.MVVM.Customers.ViewModels
{
    public class CustomerMaintenanceViewModel : ViewModelBase
    {
        #region enums

        protected enum FormStates
        {
            Loading,
            NoneSelected,
            ViewingSelected,
            Adding,
            Editing,
            Deleting,
            Saving
        }

        #endregion

        #region fields

        private FormStates _formState = FormStates.Loading;

        #endregion

        #region properties

        /* List of customers */
        private BindingList<CustomerModel> _customers;
        public BindingList<CustomerModel> Customers
        {
            get
            {
                return _customers;
            }
            protected set
            {
                SetProperty(ref _customers, value);
            }
        }

        /* Selected customer identifier */
        private Guid? _selectedCustomerId = null;
        public Guid? SelectedCustomerId
        {
            get
            {
                return _selectedCustomerId;
            }
            protected set
            {
                SetProperty(ref _selectedCustomerId, value);
            }
        }

        /* Customer properties */
        private Guid? _id;
        public Guid? Id
        {
            get
            {
                return _id;
            }
            set
            {
                SetProperty(ref _id, value);
            }
        }

        private String _name;
        public String Name
        {
            get
            {
                return _name;
            }
            set
            {
                SetProperty(ref _name, value);
            }
        }

        private Int32? _age;
        public Int32? Age
        {
            get
            {
                return _age;
            }
            set
            {
                SetProperty(ref _age, value);
            }
        }

        /* UI properties */
        private bool _canSelectCustomer = false;
        public bool CanSelectCustomer
        {
            get
            {
                return _canSelectCustomer;
            }
            set
            {
                SetProperty(ref _canSelectCustomer, value);
            }
        }

        private bool _canEditDetails = false;
        public bool CanEditDetails
        {
            get
            {
                return _canEditDetails;
            }
            set
            {
                SetProperty(ref _canEditDetails, value);
            }
        }

        private bool _canAddCustomer = false;
        public bool CanAddCustomer
        {
            get
            {
                return _canAddCustomer;
            }
            set
            {
                SetProperty(ref _canAddCustomer, value);
            }
        }

        private bool _canDeleteCustomer = false;
        public bool CanDeleteCustomer
        {
            get
            {
                return _canDeleteCustomer;
            }
            set
            {
                SetProperty(ref _canDeleteCustomer, value);
            }
        }

        private bool _canCopyCustomer = false;
        public bool CanCopyCustomer
        {
            get
            {
                return _canCopyCustomer;
            }
            set
            {
                SetProperty(ref _canCopyCustomer, value);
            }
        }

        private String _saveEditButtonText = "Edit";
        public string SaveEditButtonText
        {
            get
            {
                return _saveEditButtonText;
            }
            set
            {
                SetProperty(ref _saveEditButtonText, value);
            }
        }

        private bool _canSaveOrEditCustomer = false;
        public bool CanSaveOrEditCustomer
        {
            get
            {
                return _canSaveOrEditCustomer;
            }
            set
            {
                SetProperty(ref _canSaveOrEditCustomer, value);
            }
        }

        private String _cancelCloseButtonText = "Close";
        public string CancelCloseButtonText
        {
            get
            {
                return _cancelCloseButtonText;
            }
            set
            {
                SetProperty(ref _cancelCloseButtonText, value);
            }
        }

        private bool _canCancelOrCloseForm = false;
        public bool CanCancelOrCloseForm
        {
            get
            {
                return _canCancelOrCloseForm;
            }
            set
            {
                SetProperty(ref _canCancelOrCloseForm, value);
            }
        }

        /* Commands */
        public ICommand LoadCustomersCommand { get; set; }
        public ICommand SelectCustomerCommand { get; set; }
        public ICommand AddCustomerCommand { get; set; }
        public ICommand CopyCustomerCommand { get; set; }
        public ICommand DeleteCustomerCommand { get; set; }
        public ICommand SaveEditCustomerCommand { get; set; }
        public ICommand CancelCloseCommand { get; set; }

        #endregion

        #region ctor

        public CustomerMaintenanceViewModel()
        {
            Customers = new BindingList<CustomerModel>();

            LoadCustomersCommand = new Command(LoadCustomers, param => true);

            SelectCustomerCommand = new Command(SelectCustomer, param => CanSelectCustomer);

            AddCustomerCommand = new Command(AddCustomer, param => CanAddCustomer);
            CopyCustomerCommand = new Command(CopyCustomer, param => CanCopyCustomer);
            DeleteCustomerCommand = new Command(DeleteCustomer, param => CanDeleteCustomer);

            SaveEditCustomerCommand = new Command(SaveEditRequest, param => CanSaveOrEditCustomer);
            CancelCloseCommand = new Command(CancelCloseRequest, param => CanCancelOrCloseForm);
        }

        #endregion

        #region protected

        /* command handlers */
        protected virtual void LoadCustomers(object obj)
        {
            SetFormState(FormStates.Loading);

            Customers.Clear();

            Customers.Add(new CustomerModel()
            {
                Id = Guid.NewGuid(),
                Name = "John Smith",
                Age = 27
            });
            Customers.Add(new CustomerModel()
            {
                Id = Guid.NewGuid(),
                Name = "Jane Doe",
                Age = 42
            });
            Customers.Add(new CustomerModel()
            {
                Id = Guid.NewGuid(),
                Name = "Frank Rizzo",
                Age = 22
            });

            SelectFirstCustomer();
        }

        protected virtual void SelectCustomer(object obj)
        {
            SelectedCustomerId = Guid.Parse(obj.ToString());

            DisplayCustomer(SelectedCustomerId);
        }

        protected virtual void AddCustomer(object obj)
        {
            SetFormState(FormStates.Adding);

            Id = null;
            Name = $"Customer {Customers.Count}";
            Age = 22 + Customers.Count;
        }

        protected virtual void CopyCustomer(object obj)
        {
            SetFormState(FormStates.Adding);

            Id = null;
            Name = $"Copy of {Name}";
            Age = Age.Value;
        }

        protected virtual void DeleteCustomer(object obj)
        {
            var deleteConfirmed = OnConfirmationPrompt("Delete this customer?");

            if (deleteConfirmed)
            {
                SetFormState(FormStates.Deleting);

                var id = Guid.Parse(obj.ToString());

                DeleteCustomer(id);

                SelectFirstCustomer();
            }
        }

        protected virtual void SaveEditRequest(object obj)
        {
            if (_formState == FormStates.ViewingSelected)
            {
                // Edit current customer record
                SetFormState(FormStates.Editing);
            }
            else
            {
                Guid customerId = Guid.Empty;

                if (_formState == FormStates.Adding)
                {
                    // Save new customer
                    customerId = SaveNewCustomer();
                }
                else if (_formState == FormStates.Editing)
                {
                    // Save changes to existing customer
                    customerId = Id.Value;

                    SaveEditedCustomer(customerId);
                }

                SelectCustomer(customerId);
            }
        }

        protected virtual void CancelCloseRequest(object obj)
        {
            if (_formState == FormStates.Adding || _formState == FormStates.Editing)
            {
                var cancelConfirmed = OnConfirmationPrompt("Cancel without saving changes?");

                if (cancelConfirmed)
                {
                    // Reload currently selected customer
                    SelectCustomer(SelectedCustomerId);
                }
            }
            else
            {
                // Close the form.
                OnCloseFormRequested();
            }
        }
        /* end command handlers */

        protected virtual void SetFormState(FormStates newFormState)
        {
            switch (newFormState)
            {
                case FormStates.Loading:
                    {
                        CanSelectCustomer = false;
                        CanEditDetails = false;

                        CanAddCustomer = false;
                        CanCopyCustomer = false;
                        CanDeleteCustomer = false;

                        CanSaveOrEditCustomer = false;
                        SaveEditButtonText = "Edit";

                        CanCancelOrCloseForm = true;
                        CancelCloseButtonText = "Close";
                        break;
                    }
                case FormStates.NoneSelected:
                    {
                        CanSelectCustomer = true;
                        CanEditDetails = false;

                        CanAddCustomer = true;
                        CanCopyCustomer = false;
                        CanDeleteCustomer = false;

                        CanSaveOrEditCustomer = false;
                        SaveEditButtonText = "Edit";

                        CanCancelOrCloseForm = true;
                        CancelCloseButtonText = "Close";
                        break;
                    }
                case FormStates.ViewingSelected:
                    {
                        CanSelectCustomer = true;
                        CanEditDetails = false;

                        CanAddCustomer = true;
                        CanCopyCustomer = true;
                        CanDeleteCustomer = true;

                        CanSaveOrEditCustomer = true;
                        SaveEditButtonText = "Edit";

                        CanCancelOrCloseForm = true;
                        CancelCloseButtonText = "Close";
                        break;
                    }
                case FormStates.Adding:
                    {
                        CanSelectCustomer = false;
                        CanEditDetails = true;

                        CanAddCustomer = false;
                        CanCopyCustomer = false;
                        CanDeleteCustomer = false;

                        CanSaveOrEditCustomer = true;
                        SaveEditButtonText = "Save";

                        CanCancelOrCloseForm = true;
                        CancelCloseButtonText = "Cancel";
                        break;
                    }
                case FormStates.Editing:
                    {
                        CanSelectCustomer = false;
                        CanEditDetails = true;

                        CanAddCustomer = false;
                        CanCopyCustomer = false;
                        CanDeleteCustomer = false;

                        CanSaveOrEditCustomer = true;
                        SaveEditButtonText = "Save";

                        CanCancelOrCloseForm = true;
                        CancelCloseButtonText = "Cancel";
                        break;
                    }
                case FormStates.Deleting:
                    {
                        CanEditDetails = false;
                        CanSelectCustomer = false;

                        CanAddCustomer = false;
                        CanCopyCustomer = false;
                        CanDeleteCustomer = false;

                        CanSaveOrEditCustomer = false;
                        SaveEditButtonText = "Edit";

                        CanCancelOrCloseForm = false;
                        CancelCloseButtonText = "Close";
                        break;
                    }
                case FormStates.Saving:
                    {
                        CanSelectCustomer = false;
                        CanEditDetails = false;

                        CanAddCustomer = false;
                        CanCopyCustomer = false;
                        CanDeleteCustomer = false;

                        CanSaveOrEditCustomer = false;
                        SaveEditButtonText = "Edit";

                        CanCancelOrCloseForm = false;
                        CancelCloseButtonText = "Cancel";
                        break;
                    }
                default:
                    {
                        throw new InvalidOperationException($"Invalid form state: {newFormState.ToString()}");
                    }
            }

            _formState = newFormState;
        }

        protected virtual void DisplayCustomer(object obj)
        {
            if (obj.Equals(Guid.Empty))
                return;

            var id = Guid.Parse(obj.ToString());

            var customer = Customers.FirstOrDefault(c => c.Id.Equals(id));

            if (customer != null)
            {
                Id = customer.Id;
                Name = customer.Name;
                Age = customer.Age;
            }

            SetFormState(FormStates.ViewingSelected);
        }

        protected virtual void SelectFirstCustomer()
        {
            var firstCustomer = Customers.FirstOrDefault();

            if (firstCustomer != null)
            {
                SelectCustomer(firstCustomer.Id);
            }
        }

        protected virtual void SaveEditedCustomer(Guid id)
        {
            var existingCustomer = Customers.FirstOrDefault(c => c.Id.Equals(id));

            if (existingCustomer != null)
            {
                existingCustomer.Name = Name;
                existingCustomer.Age = Age.Value;
            }

            Customers.ResetBindings();
        }

        protected virtual Guid SaveNewCustomer()
        {
            var newCustomer = new CustomerModel()
            {
                Id = Guid.NewGuid(),
                Name = Name,
                Age = Age.Value
            };

            Customers.Add(newCustomer);

            Customers.ResetBindings();

            return newCustomer.Id;
        }

        protected virtual void DeleteCustomer(Guid id)
        {
            var customer = Customers.FirstOrDefault(c => c.Id.Equals(id));

            if (customer != null)
            {
                Customers.Remove(customer);
            }
        }

        #endregion
    }
}
