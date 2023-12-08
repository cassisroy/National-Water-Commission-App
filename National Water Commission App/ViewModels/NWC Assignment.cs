using CommunityToolkit.Mvvm.ComponentModel;
using SQLite;
using CommunityToolkit.Mvvm.Input;
using National_Water_Commission_App.Models;
using National_Water_Commission_App.Services;
using National_Water_Commission_App.Views;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace National_Water_Commission_App.ViewModels
{
    public partial class CustListViewModel1 : BaseViewModel
    {
        const string editButtonText = "Update";
        const string createButtonText = "Add";
        public ObservableCollection<Customers1> Customer1 { get; private set; } = new();
        public CustListViewModel1() 
        {
            Title = "National Water Commission";
            AddEditButtonText1 = createButtonText;
            GetCustList().Wait();
        }

        [ObservableProperty]
        string firstName1;
        [ObservableProperty]
        string lastName1;
        [ObservableProperty]
        string address1;
        [ObservableProperty]
        string telephone1;
        [ObservableProperty]
        string emailAddress1;
        [ObservableProperty]
        string tRN1;
        [ObservableProperty]
        string addEditButtonText1;
        [ObservableProperty]
        int customerId;


        [RelayCommand]
        async Task GetCustList()
        {
            if (IsLoading) return;
            try
            {
                IsLoading = true;
                if (Customer1.Any()) Customer1.Clear();

                var customer = App.CustService.GetCustomers1();
                foreach (var customers1 in Customer1) Customer1.Add(customers1);

            }
            catch (Exception ex)
            {
                Debug.WriteLine($"Unable to get customers: {ex.Message}");
                await Shell.Current.DisplayAlert("Error", "Failed to retrieve customer list.", "Ok");
            }
            finally 
            {
                IsLoading = false;
            }
        }
        [RelayCommand]
        async Task GetCustDetails(int id)
        {
            if (id == 0) return;
            await Shell.Current.GoToAsync($"{nameof(CustDetailsPage)}?Id={id}", true);
        }

        [RelayCommand]
        async Task SaveCustomer()
        {
            if (string.IsNullOrEmpty(FirstName1) || string.IsNullOrEmpty(LastName1) || string.IsNullOrEmpty(Address1) ||
                string.IsNullOrEmpty(Telephone1) || string.IsNullOrEmpty (EmailAddress1) || string.IsNullOrEmpty(TRN1))
            {
                await Shell.Current.DisplayAlert("Error", "Please try again", "Ok");
                return;
            }

            var customers1 = new Customers1
            {
                FirstName1 = FirstName1,
                LastName1 = LastName1,
                Address1 = Address1,
                Telephone1 = Telephone1,
                EmailAddress1 = EmailAddress1,
                TRN1 = TRN1
            };
            if (CustomerId != 0)
            {
                customers1.Id = CustomerId;
                App.CustService.UpdateCustomer(customers1);
            }
        }

        [RelayCommand]
        async Task SetEditMode(int id)
        {
            AddEditButtonText1 = editButtonText;
            CustomerId = id;
            var customers1 = App.CustService.GetCustomers(id);
            FirstName1 = customers1.FirstName1;
            LastName1 = customers1.LastName1;
            Address1 = customers1.Address1;
            Telephone1 = customers1.Telephone1;
            EmailAddress1 = customers1.EmailAddress1;
            TRN1 = customers1.TRN1;
        }

        [RelayCommand]
        async Task AddCustomer()
        {
            if (string.IsNullOrEmpty(FirstName1) || string.IsNullOrEmpty(LastName1) || string.IsNullOrEmpty(Address1) ||
                string.IsNullOrEmpty(Telephone1) || string.IsNullOrEmpty(EmailAddress1) || string.IsNullOrEmpty(TRN1))
            {
                await Shell.Current.DisplayAlert("Invalid Data", "Please try again", "Ok");
                return;
            }
            var Customers1 = new Customers1
            {
                FirstName1 = FirstName1,
                LastName1 = LastName1,
                Address1 = Address1,
                Telephone1 = Telephone1,
                EmailAddress1 = EmailAddress1,
                TRN1 = TRN1
            };
            if (CustomerId == 0)
            {
                Customers1.Id = CustomerId;
                App.CustService.AddCustomer(Customers1);
                await Shell.Current.DisplayAlert("Success", App.CustService.StatusMessage, "Ok");
            }
            await GetCustList();
            await DeleteCustomer1();
        }

        [RelayCommand]
        async Task DeleteCustomer1()
        {
            AddEditButtonText1 = createButtonText;
            CustomerId = 0;
            FirstName1 = string.Empty;
            LastName1 = string.Empty;
            Address1 = string.Empty;
            Telephone1 = string.Empty;
            EmailAddress1 = string.Empty;
            TRN1 = string.Empty;
        }
    }
}
