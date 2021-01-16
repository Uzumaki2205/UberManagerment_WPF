using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using UberManagerment_WPF.DAO;

namespace UberManagerment_WPF.BUS
{
    public class List_Customer_BUS
    {
        private static List_Customer_BUS instance;

        public static List_Customer_BUS Instance
        {
            get
            {
                if (instance == null)
                    instance = new List_Customer_BUS();
                return instance;
            }
        }

        public List_Customer_BUS() { }

        public void ShowListCustomer(DataGrid data)
        {
            data.ItemsSource = List_Customer_DAO.Instance.ShowListCustomer();
        }
        public void ShowListCustomerOnline(DataGrid data)
        {
            data.ItemsSource = List_Customer_DAO.Instance.ShowListCustomerOnline();
        }
    }
}
