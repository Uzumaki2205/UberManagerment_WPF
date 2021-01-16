using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using UberManagerment_WPF.DAO;

namespace UberManagerment_WPF.BUS
{
    public class List_Travell_BUS
    {
        private static List_Travell_BUS instance;

        public static List_Travell_BUS Instance 
        { 
            get
            {
                if (instance == null)
                    instance = new List_Travell_BUS();
                return instance;
            }
        }
        public void ShowListTravell(DataGrid data)
        {
            data.ItemsSource = List_Travell_DAO.Instance.ShowListTravell();
        }
    }
}
