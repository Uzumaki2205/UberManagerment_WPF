using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using UberManagerment_WPF.DTO;

namespace UberManagerment_WPF.DAO
{
    class List_Travell_DAO
    {
        private static List_Travell_DAO instance;
        string fileName = Static_Instance.directory + "\\XML\\data_Travell.xml";

        public static List_Travell_DAO Instance 
        {
            get
            {
                if (instance == null)
                    instance = new List_Travell_DAO();
                return instance;
            }
        }

        public List_Travell_DAO() { }
        public List<Travell_DTO> ShowListTravell()
        {
            List<Travell_DTO> LstTravell = new List<Travell_DTO>();

            XmlDocument reader = new XmlDocument();
            reader.Load(fileName);

            foreach (XmlNode node in reader.DocumentElement.ChildNodes)
            {
                Travell_DTO travell = new Travell_DTO();

                travell.NameDriver = node["Name_Driver"].InnerText;
                travell.NameCustomer = node["Name_Customer"].InnerText;
                travell.Location_From = node["Location_From"].InnerText;
                travell.Location_To = node["Location_To"].InnerText;
                travell.TimeStart = node["TimeStart"].InnerText;
                travell.Date = node["Date"].InnerText;

                try
                {
                    travell.MoneyTake = Convert.ToDouble(node["MoneyTake"].InnerText);
                    travell.MoneyGive = Convert.ToDouble(node["MoneyGive"].InnerText);
                }
                catch (Exception)
                {
                    node["MoneyTake"].InnerText = "0";
                    node["MoneyGive"].InnerText = "0";
                    travell.MoneyTake = Convert.ToDouble(node["MoneyTake"].InnerText);
                    travell.MoneyGive = Convert.ToDouble(node["MoneyGive"].InnerText);
                }

                LstTravell.Add(travell);
            }

            return LstTravell;
        }

        public void WriteTravell()
        {
            string fileName0 = Static_Instance.directory + "\\XML\\data_DriverReceive.xml";
            XmlDocument reader = new XmlDocument();

            string nameDriver = "";
            string nameCustomer = "";
            string LocationFROM = "";
            string LocationTO = "";

            reader.Load(fileName0);

            foreach (XmlNode node in reader.DocumentElement.ChildNodes)
            {
                if (node["USerName_Customer"].InnerText == Static_Instance.findUserName)
                {
                    nameDriver = node["NameDriver"].InnerText;
                    nameCustomer = node["NameCustomer"].InnerText;
                    LocationFROM = node["Location_From"].InnerText;
                    LocationTO = node["Location_To"].InnerText;

                    break;
                }
            }

            reader.Load(fileName);

            XmlNode Travell = reader.CreateElement("Travell");
            XmlNode NameDriver = reader.CreateElement("Name_Driver");
            XmlNode NameCustomer = reader.CreateElement("Name_Customer");
            XmlNode Location_From = reader.CreateElement("Location_From");
            XmlNode Location_To = reader.CreateElement("Location_To");
            XmlNode TimeStart = reader.CreateElement("TimeStart");
            XmlNode Date = reader.CreateElement("Date");
            XmlNode MoneyTake = reader.CreateElement("MoneyTake");
            XmlNode MoneyGive = reader.CreateElement("MoneyGive");


            NameDriver.InnerText = nameDriver;
            NameCustomer.InnerText = nameCustomer;
            Location_From.InnerText = LocationFROM;
            Location_To.InnerText = LocationTO;
            TimeStart.InnerText = DateTime.Now.ToString("HH", System.Globalization.DateTimeFormatInfo.InvariantInfo);
            Date.InnerText = DateTime.Now.Date.ToString("dd/MM/yyyy");

            foreach (Customer_DTO item in List_Customer_DAO.Instance.ShowListCustomer())
            {
                if(item.UserName == Static_Instance.findUserName)
                {
                    MoneyTake.InnerText = List_Driver_DAO.Instance.ReturnMoneyTake().ToString();
                    MoneyGive.InnerText = List_Driver_DAO.Instance.ReturnMoneyGive().ToString();
                }
            }

            Travell.AppendChild(NameDriver);
            Travell.AppendChild(NameCustomer);
            Travell.AppendChild(Location_From);
            Travell.AppendChild(Location_To);
            Travell.AppendChild(TimeStart);
            Travell.AppendChild(Date);
            Travell.AppendChild(MoneyTake);
            Travell.AppendChild(MoneyGive);

            reader.DocumentElement.AppendChild(Travell);
            reader.Save(fileName);
        }

        public List<Travell_DTO> checkCustomerPayMAX()
        {
            List<Travell_DTO> listMoneyMAX = new List<Travell_DTO>();
            double max = 0;
            for (int i = 0; i < ShowListTravell().Count; i++)
            {
                if (ShowListTravell()[i].MoneyTake >= max)
                {
                    max = ShowListTravell()[i].MoneyTake;
                    listMoneyMAX.Add(ShowListTravell()[i]);
                }
            }
            return listMoneyMAX;
        }
        public List<Travell_DTO> checkDriverPayMax()
        {
            List<Travell_DTO> listMoneyMAX = new List<Travell_DTO>();
            double max = 0;
            for (int i = 0; i < ShowListTravell().Count; i++)
            {
                if (ShowListTravell()[i].MoneyGive >= max)
                {
                    max = ShowListTravell()[i].MoneyGive;
                    listMoneyMAX.Add(ShowListTravell()[i]);
                }
            }
            return listMoneyMAX;
        }

        //public void Update(string UserNameDriver, string UserNameCustomer)
        //{
        //    XmlDocument reader = new XmlDocument();
        //    reader.Load(fileName);

        //    foreach (XmlNode node in reader.DocumentElement.ChildNodes)
        //    {
        //        //if (UserNameDriver)
        //    }

        //    //reader.Save(fileName);
        //}
    }
}
