using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using UberManagerment_WPF.DAO;

namespace UberManagerment_WPF.RESULT
{
    /// <summary>
    /// Interaction logic for PopUp_Customer_Vip.xaml
    /// </summary>
    public partial class PopUp_Customer_Vip : Window
    {
        public PopUp_Customer_Vip()
        {
            InitializeComponent();
        }

        public void LoadInfo()
        {
            dtgInfoCustomer.ItemsSource = List_Customer_DAO.Instance.ShowListCustomerVip();
        }
    }
}
