using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using UberManagerment_WPF.DTO;

namespace UberManagerment_WPF.DAO
{
    class List_Customer_DAO
    {
        List<Customer_DTO> listCustomerVip;
        List<Customer_DTO> lstCustomerOnline;
        List<Customer_DTO> lstCustomer_Motobike;
        List<Customer_DTO> lstCustomer_Car;
        List<Customer_DTO> lstCustomer_taxiCar;
        private static List_Customer_DAO instance;

        public static List_Customer_DAO Instance 
        { 
            get
            {
                if (instance == null)
                    instance = new List_Customer_DAO();
                return instance;
            }
        }

        public List<Customer_DTO> LstCustomer_Motobike { get => lstCustomer_Motobike; set => lstCustomer_Motobike = value; }
        public List<Customer_DTO> LstCustomer_Car { get => lstCustomer_Car; set => lstCustomer_Car = value; }
        public List<Customer_DTO> LstCustomer_taxiCar { get => lstCustomer_taxiCar; set => lstCustomer_taxiCar = value; }
        public List<Customer_DTO> LstCustomerOnline { get => lstCustomerOnline; set => lstCustomerOnline = value; }
        public List<Customer_DTO> ListCustomerVip { get => listCustomerVip; set => listCustomerVip = value; }

        public List_Customer_DAO() { }

        public List<Customer_DTO> ShowListCustomer()
        {
            string fileName = Static_Instance.directory + "\\XML\\data_Customer.xml";

            List<Customer_DTO> lstCustomer = new List<Customer_DTO>();
            ListCustomerVip = new List<Customer_DTO>();
            LstCustomerOnline = new List<Customer_DTO>();
            LstCustomer_Motobike = new List<Customer_DTO>();
            LstCustomer_Car = new List<Customer_DTO>();
            LstCustomer_taxiCar = new List<Customer_DTO>();

            XmlDocument reader = new XmlDocument();
            reader.Load(fileName);

            foreach (XmlNode node in reader.DocumentElement.ChildNodes)
            {
                Customer_DTO customer = new Customer_DTO();

                customer.Name = node["Name"].InnerText;
                customer.UserName = node["UserName"].InnerText;
                customer.PassWord = node["Password"].InnerText;
                customer.Telephone = node["Telephone"].InnerText;
                customer.TypeCustomer = Static_Instance.checkTypeCustomer(Static_Instance.check_CallBike_TypeCustomer(node["Num_CallCar"].InnerText));
                customer.TypeCar = Static_Instance.checkTypeCar(node["Type_Car"].InnerText);
                customer.Location_Customer = node["Location"].InnerText;
                customer.Status = Static_Instance.checkStatus(node["Status"].InnerText);

                if (customer.TypeCar == "Xe máy")
                    LstCustomer_Motobike.Add(customer);
                else if (customer.TypeCar == "Xe ô tô")
                    LstCustomer_Car.Add(customer);
                else 
                    LstCustomer_taxiCar.Add(customer);

                if (customer.Status == "Online")
                    LstCustomerOnline.Add(customer);

                if (customer.TypeCustomer == "VIP")
                    ListCustomerVip.Add(customer);

                lstCustomer.Add(customer); 
            }

            return lstCustomer;
        }

        public List<Customer_DTO> ShowListCustomerVip()
        {
            return ListCustomerVip;
        }
        public List<Customer_DTO> ShowListCustomerOnline()
        {
            return LstCustomerOnline;
        }
        public List<Customer_DTO> ShowListCustomer_Motobike()
        {
            return LstCustomer_Motobike;
        }
        public List<Customer_DTO> ShowListCustomer_Car()
        {
            return LstCustomer_Car;
        }
        public List<Customer_DTO> ShowListCustomer_taxiCar()
        {
            return LstCustomer_taxiCar;
        }

        public void Update(string UserName, string typeCar, string location)
        {
            string fileName = Static_Instance.directory + "\\XML\\data_Customer.xml";
            XmlDocument doc = new XmlDocument();
            doc.Load(fileName);
          
            foreach (XmlNode node in doc.DocumentElement.ChildNodes)
            {
                if (node["UserName"].InnerText == UserName)
                {
                    node["Type_Car"].InnerText = typeCar;
                    node["Location"].InnerText = location;
                    node["Num_CallCar"].InnerText = Static_Instance.Count_CallCar(node["Num_CallCar"].InnerText);
                    Static_Instance.checkTypeCustomer(node["Num_CallCar"].InnerText);
                }
            }

            doc.Save(fileName);
        }

        public void UpdateStatus(string UserName)
        {
            UserName = Static_Instance.findUserName;
            string fileName = Static_Instance.directory + "\\XML\\data_Customer.xml";
            XmlDocument doc = new XmlDocument();
            doc.Load(fileName);

            foreach (XmlNode node in doc.DocumentElement.ChildNodes)
            {
                if (node["UserName"].InnerText == UserName)
                {
                    node["Status"].InnerText = "Hoa đã có chủ";
                }
            }

            doc.Save(fileName);
        }
    }
}
