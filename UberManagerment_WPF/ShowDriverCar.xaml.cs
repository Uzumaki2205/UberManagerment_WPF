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
using System.Windows.Navigation;
using System.Windows.Shapes;
using UberManagerment_WPF.BUS;
using UberManagerment_WPF.DAO;
using UberManagerment_WPF.DTO;

namespace UberManagerment_WPF
{
    /// <summary>
    /// Interaction logic for ShowDriverCar.xaml
    /// </summary>
    public partial class ShowDriverCar : Page
    {
        string tieude = "Car";
        public ShowDriverCar()
        {
            InitializeComponent();
            LoadInfo();
        }
        void LoadInfo()
        {
            List_Driver_BUS.Instance.ShowListDriverCar(dtgInfoDriverCar);
        }

        private void btnShow_Click(object sender, RoutedEventArgs e)
        {
            if (Static_Instance.findNameDriver == null || tieude != Static_Instance.tempTitile)
            {
                MessageBox.Show("Chọn tài xế đi cha nội", "FBI Warning", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            else
            {
                Receive_CallCar receive = new Receive_CallCar();

                List<Customer_DTO> lstCustomerOnline = new List<Customer_DTO>();

                foreach (Customer_DTO item in List_Customer_DAO.Instance.ShowListCustomer_Car())
                {
                    if (item.Status == "Online")
                    {
                        lstCustomerOnline.Add(item);
                    }
                }

                //receive.dtgShowInfoCustomer.ItemsSource = List_Customer_DAO.Instance.ShowListCustomer_Car();
                receive.dtgShowInfoCustomer.ItemsSource = lstCustomerOnline;
                receive.ShowDialog();
            }

            dtgInfoDriverCar.UnselectAllCells();
        }

        private void dtgInfoDriverCar_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            foreach (Driver_Car_DTO driver in e.AddedItems)
            { 
                Static_Instance.findUserNameDriver = driver.UserName; //lấy username tài xế
                Static_Instance.findNameDriver = driver.Name;
                Static_Instance.tempTitile = "Car";
            }
        }
    }
}
