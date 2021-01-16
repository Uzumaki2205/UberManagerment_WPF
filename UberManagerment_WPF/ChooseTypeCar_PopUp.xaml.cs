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
    /// Interaction logic for ChooseTypeCar_PopUp.xaml
    /// </summary>
    public partial class ChooseTypeCar_PopUp : Window
    {
        static int location;
        //static string typeCar;
        public ChooseTypeCar_PopUp()
        {
            InitializeComponent();
        }

        private void btnGetLocation_Click(object sender, RoutedEventArgs e)
        {
            location = Customer_DTO.GetLocation();

            Static_Instance.GetLocation = location.ToString();

            btnGetLocation.Content = location.ToString();
        }

        private void btnAccept_Click(object sender, RoutedEventArgs e)
        {
            if (tbxLocation_To.Text == string.Empty)
            {
                MessageBox.Show("Không có địa chỉ thì chở sang biên giới nhá :)))", 
                    "Thông Báo", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            else
            {
                if (checkLocationTo() == false)
                {
                    MessageBox.Show("Nhập địa chỉ lại đi 3", "Sai địa chỉ đến!!", MessageBoxButton.OK,MessageBoxImage.Error);
                }
                else
                {
                    //Ghi vào file địa chỉ và khách hàng đặt xe

                    //Static_Instance.GetLocationTo = tbxLocation_To.Text;
                    //typeCar = Static_Instance.checkTypeCar_Converted(cbbxCar.Text);
                    WriteLocation();

                    MessageBox.Show("Bạn đã đặt thành công!! \n Loại xe: " + cbbxCar.Text
                        + "\n Địa chỉ: " + location, "Thông Báo!!", MessageBoxButton.OK);

                    List_Customer_DAO.Instance.Update(Static_Instance.findUserName, 
                        Static_Instance.checkTypeCar_Converted(cbbxCar.Text), location.ToString());
                    
                    this.Close();
                }
            }
        }

        void WriteLocation() //ghi file lưu thông tin tạm
        {
            string fileName = Static_Instance.directory + "\\XML\\data_Address.xml";
            XmlDocument reader = new XmlDocument();
            reader.Load(fileName);

            XmlNode Address = reader.CreateElement("Address");
            XmlNode UserNameCustomer = reader.CreateElement("UserName_Customer");
            XmlNode NameCustomer = reader.CreateElement("Name_Customer");
            XmlNode Location_From = reader.CreateElement("Location_From");
            XmlNode Location_To = reader.CreateElement("Location_To");
            XmlNode TimeCall = reader.CreateElement("TimeCall");
            XmlNode DateCall = reader.CreateElement("DateCall");
            XmlNode Type_Car = reader.CreateElement("Type_Car");

            UserNameCustomer.InnerText = Static_Instance.findUserName;
            NameCustomer.InnerText = Static_Instance.findName;
            Location_From.InnerText = Static_Instance.GetLocation;
            Location_To.InnerText = tbxLocation_To.Text;
            TimeCall.InnerText = DateTime.Now.ToString("hh");
            DateCall.InnerText = DateTime.Today.ToString("dd/MM/yyyy");
            Type_Car.InnerText = Static_Instance.checkTypeCar_Converted(cbbxCar.Text);

            Address.AppendChild(UserNameCustomer);
            Address.AppendChild(NameCustomer);
            Address.AppendChild(Location_From);
            Address.AppendChild(Location_To);
            Address.AppendChild(TimeCall);
            Address.AppendChild(DateCall);
            Address.AppendChild(Type_Car);

            reader.DocumentElement.AppendChild(Address);
            reader.Save(fileName);
        }

        bool checkLocationTo()
        {
            try
            {
                int.Parse(tbxLocation_To.Text);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
