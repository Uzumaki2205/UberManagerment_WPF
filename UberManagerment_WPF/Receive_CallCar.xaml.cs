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
using System.Xml;
using UberManagerment_WPF.DAO;
using UberManagerment_WPF.DTO;

namespace UberManagerment_WPF
{
    /// <summary>
    /// Interaction logic for Receive_CallCar.xaml
    /// </summary>
    public partial class Receive_CallCar : Window
    {
        public Receive_CallCar()
        {
            InitializeComponent();
        }

        private void btnReceive_Click(object sender, RoutedEventArgs e)
        {
            MessageBoxResult result = MessageBox.Show("Bạn có muốn nhận cuốc này không??", "Thông báo", 
                MessageBoxButton.YesNo, MessageBoxImage.Question);

            if (result == MessageBoxResult.Yes)
            {
                MessageBox.Show("Bạn đã nhận thành công!!", "Thông báo", MessageBoxButton.OK);
                
                //Update status khach hang da co nguoi nhan chuyen xe
                List_Customer_DAO.Instance.UpdateStatus(Static_Instance.findUserName);

                List_Driver_DAO.Instance.GhiFileTaiXeDaNhanXe(); //ghi file tai xe da nhan xe

                List_Travell_DAO.Instance.WriteTravell(); //ghi thông tin chuyến đi vào file

                List_Driver_DAO.Instance.GhiFileTongDoanhThu();
            }
            else MessageBox.Show("Không làm mà đòi có ăn thì ăn đb =))", "Thông báo", MessageBoxButton.OK);

            //Đặt lại các thuộc tính về default
            Static_Instance.findUserName = null;
            Static_Instance.findNameDriver = null;
            Static_Instance.findName = null;
            
        }

        public void ResetStatus()
        {
            string fileName = Static_Instance.directory + "\\XML\\data_Customer.xml";
            XmlDocument doc = new XmlDocument();
            doc.Load(fileName);

            foreach (XmlNode node in doc.DocumentElement.ChildNodes)
            {
                if (node["UserName"].InnerText == Static_Instance.findUserName)
                {
                    node["Status"].InnerText = "1";
                }
            }

            doc.Save(fileName);
        }

        private void dtgShowInfoCustomer_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            foreach (Customer_DTO customer in e.AddedItems)
            {
                Static_Instance.findUserName = customer.UserName;
                Static_Instance.findName = customer.Name;
            }
        } 
    }
}
