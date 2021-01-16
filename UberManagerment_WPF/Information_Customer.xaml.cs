using System;
using System.Collections.Generic;
using System.Data;
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
using System.Windows.Navigation;
using System.Windows.Shapes;
using UberManagerment_WPF.BUS;
using UberManagerment_WPF.DAO;
using UberManagerment_WPF.DTO;
using UberManagerment_WPF.Interface;

namespace UberManagerment_WPF
{
    /// <summary>
    /// Interaction logic for Information_Customer.xaml
    /// </summary>
    public partial class Information_Customer : Page
    {
        public Information_Customer()
        {
            InitializeComponent();
            LoadInfo();
            //checkHaveReceive();
        }

        void LoadInfo()
        {
            List_Customer_BUS.Instance.ShowListCustomer(dtgInfoCustomer);
        }

        private void btnCallBike_Click(object sender, RoutedEventArgs e)
        {
            if (dtgInfoCustomer.SelectedCells.Count <= 0)
            {
                MessageBox.Show("Chưa bấm vào tài khoản mà", "FBI Warning", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            else if (checkStatus() == "0")
            {
                MessageBox.Show("Bạn chưa đăng nhập!!", "Thân =)))", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            else
            {
                ChooseTypeCar_PopUp form_ChooseCar = new ChooseTypeCar_PopUp();
                form_ChooseCar.ShowDialog();
            }
            Static_Instance.validateStatus = null;
        }

        string checkStatus()
        {
            foreach (Customer_DTO item in List_Customer_DAO.Instance.ShowListCustomer())
            {
                if ((item.UserName == Static_Instance.findUserName) && item.Status == "Offline")
                {
                    Static_Instance.validateStatus = "0";
                }
            }
            return Static_Instance.validateStatus;
        }

        private void dtgInfoCustomer_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            foreach (Customer_DTO customer in e.AddedItems)
            {
                Static_Instance.findUserName = customer.UserName;
                Static_Instance.findName = customer.Name;
            }
        }
        void checkHaveReceive() //kiểm tra đã nhận được trả lời từ tài xế chưa
        {
            if (Static_Instance.findName != null && Static_Instance.findUserName != null)
                MessageBox.Show("Đã có tài xế " + Static_Instance.findNameDriver + " cho khách hàng " 
                    + Static_Instance.findName, "Thông báo", MessageBoxButton.OK);

            Static_Instance.findName = null;
            Static_Instance.findUserName = null;
            Static_Instance.findNameDriver = null;
        }
    }
}
