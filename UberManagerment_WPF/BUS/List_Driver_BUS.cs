using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using UberManagerment_WPF.DAO;

namespace UberManagerment_WPF.BUS
{
    public class List_Driver_BUS
    {
        private static List_Driver_BUS instance;
        public static List_Driver_BUS Instance
        {
            get
            {
                if (instance == null)
                    instance = new List_Driver_BUS();
                return instance;
            }
        }
        public void ShowListAllDriver(DataGrid data)
        {
            data.ItemsSource = List_Driver_DAO.Instance.ShowListDriver();
        }
        public void ShowListDriverMotobike(DataGrid data)
        {
            data.ItemsSource = List_Driver_DAO.Instance.ShowListDriver_Motobike();
        }
        public void ShowListDriverCar(DataGrid data)
        {
            data.ItemsSource = List_Driver_DAO.Instance.ShowListDriver_Car();
        }
        public void ShowListDriverTaxiCar(DataGrid data)
        {
            data.ItemsSource = List_Driver_DAO.Instance.ShowListDriver_taxiCar();
        }
    }
}
