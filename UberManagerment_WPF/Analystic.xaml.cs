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
using System.Xml;
using UberManagerment_WPF.DAO;
using UberManagerment_WPF.DTO;
using UberManagerment_WPF.RESULT;

namespace UberManagerment_WPF
{
    /// <summary>
    /// Interaction logic for Analystic.xaml
    /// </summary>
    public partial class Analystic : Page
    {
        public Analystic()
        {
            InitializeComponent();
        }

        private void btnCountAccount_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Có " + List_Customer_DAO.Instance.ShowListCustomer().Count
                + List_Driver_DAO.Instance.ShowListDriver().Count + "tài khoản", "Số tài khoản", MessageBoxButton.OK, MessageBoxImage.Information);
        }

        private void btnShowVip_Click(object sender, RoutedEventArgs e)
        {
            PopUp_Customer_Vip fr = new PopUp_Customer_Vip();
            fr.LoadInfo();
            fr.ShowDialog();
        }

        private void btnShow5Customer_Click(object sender, RoutedEventArgs e)
        {
            PopUp_5_Customer_Max fr = new PopUp_5_Customer_Max();
            fr.dtgInfoCustomer.ItemsSource = List_Travell_DAO.Instance.checkCustomerPayMAX();
            fr.ShowDialog();
        }

        private void btnTongDoanhThu_Click(object sender, RoutedEventArgs e)
        {
            string fileName = Static_Instance.directory + "\\XML\\data_Analysis.xml";
            XmlDocument doc = new XmlDocument();
            doc.Load(fileName);

            foreach (XmlNode node in doc.DocumentElement.ChildNodes)
            {
                MessageBox.Show("Xe May = " + node["Motobike"].InnerText
                + "\nXe ô tô = " + node["Car"].InnerText
                + "\nXe ô tô tải = " + node["TaxiCar"].InnerText);
            }
        }

        private void btnCountTypeCar_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Xe Máy = " + List_Driver_DAO.Instance.ShowListAllDriver().Count
                + "\nXe Ô Tô = " + List_Driver_DAO.Instance.ShowListAllDriver().Count
                + "\nXe Ô Tô Tải = " + List_Driver_DAO.Instance.ShowListAllDriver().Count, 
                "Số xe mỗi loại", MessageBoxButton.OK, MessageBoxImage.Information);
        }

        private void btnShowListDriverMaxVAT_Click(object sender, RoutedEventArgs e)
        {
            //Popup_Driver_Max_VAT fr = new Popup_Driver_Max_VAT();
            //fr.dtgDriver.ItemsSource = List_Travell_DAO.Instance.checkDriverPayMax();
            //fr.ShowDialog();
        }

        private void btnShowCustomerMaxGo_Click(object sender, RoutedEventArgs e)
        {
            string fileName = Static_Instance.directory + "\\XML\\data_Travell.xml";
            XmlDocument doc = new XmlDocument();
            doc.Load(fileName);

            string tempName;

            int max = 0;
            int count = 0;
            string maxCustomer = "";
            foreach (XmlNode node in doc.DocumentElement.ChildNodes)
            {
                tempName = node["Name_Customer"].InnerText;

                if (node["Name_Customer"].InnerText == tempName)
                    count++;
                if (count > max)
                {
                    max = count;
                    maxCustomer = node["Name_Customer"].InnerText;
                }
                   
            }

            MessageBox.Show(maxCustomer, "Khách hàng đi nhiều nhất", MessageBoxButton.OK, MessageBoxImage.Information);
        }

        private void btnDriverMax_Click(object sender, RoutedEventArgs e)
        {
            string nameDriver = "";
            double max = 0;
            for (int i = 0; i < List_Travell_DAO.Instance.ShowListTravell().Count; i++)
            {
                if (List_Travell_DAO.Instance.ShowListTravell()[i].MoneyGive > max)
                {
                    max = List_Travell_DAO.Instance.ShowListTravell()[i].MoneyGive;
                    nameDriver = List_Travell_DAO.Instance.ShowListTravell()[i].NameDriver;
                } 
            }

            MessageBox.Show(nameDriver, "Tài xế doanh thu cao nhất", MessageBoxButton.OK, MessageBoxImage.Information);
        }

        private void btnShowDriverCarReward_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnShowDriverTaxiCarReward_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
