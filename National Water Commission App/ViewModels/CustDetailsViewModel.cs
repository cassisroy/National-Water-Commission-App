using CommunityToolkit.Mvvm.ComponentModel;
using National_Water_Commission_App.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
namespace National_Water_Commission_App.ViewModels
{
    [QueryProperty(nameof(Id),nameof(Id))]
    public partial class CustDetailsViewModel1:BaseViewModel, IQueryAttributable
    {
        [ObservableProperty]
        Customers1 customers1;

        [ObservableProperty]
        int id;

        public void ApplyQueryAttributes(IDictionary<string, object> query)
        {
            Id = Convert.ToInt32(HttpUtility.UrlDecode(query["Id"].ToString()));
            Customers1 = App.CustService.GetCustomers(Id);
        }
    }
}
