using CommunityToolkit.Mvvm.Input;
using National_Water_Commission_App.Models;
using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace National_Water_Commission_App.Services
{
    public class CustService
    {
        SQLiteConnection conn;
        string _dbPath;
        public string StatusMessage;
        int result = 0;

        public CustService(string dbPath)
        { 
            _dbPath = dbPath;
        }
        private void Init() 
        {
            if (conn != null)
                return;

            conn = new SQLiteConnection(_dbPath);
            conn.CreateTable<Customers1>();

        }

        public List<Customers1> GetCustomers1()
        {
            try 
            {
                Init();
                return conn.Table<Customers1>().ToList();
            }
            catch (Exception)
            {
                StatusMessage = "Failed to retrieve data.";
            }
            return new List<Customers1>();
        }

        public Customers1 GetCustomers(int id)
        {
            try 
            {
                Init();
                return conn.Table<Customers1>().FirstOrDefault(q => q.Id == id);
            }    
            catch (Exception)
            {
                StatusMessage = "Error";
            }
            return null;
        }

        public void UpdateCustomer(Customers1 customers1)
        {
            try
            {
                Init();
                if (customers1 == null)
                    throw new Exception("Invalid");
                result = conn.Update(customers1);
                StatusMessage = result == 0 ? "Failed" : "Success";
            }
            catch(Exception ex)
            {
                StatusMessage = "Error";
            }
        }
        public int DeleteCustomer(int id)
        {
            try
            {
                Init();
                return conn.Table<Customers1>().Delete(q=> q.Id == id);
            }
            catch (Exception)
            {
                StatusMessage = "Failed to Delete.";
            }
            return 0;
        }
        public void AddCustomer(Customers1 customers1)
        {
            try
            {
                Init();
                if (customers1 == null)
                    throw new Exception("Not Valid");

                result = conn.Insert(customers1);
                StatusMessage = result == 0 ? "Try Again" : "Successfully Added";
            }
            catch (Exception ex)
            {
                StatusMessage = "Failed to Insert data.";
            }
        }
    }
}
