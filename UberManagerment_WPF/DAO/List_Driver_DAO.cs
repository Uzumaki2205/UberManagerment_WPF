using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using UberManagerment_WPF.DTO;

namespace UberManagerment_WPF.DAO
{
    class List_Driver_DAO
    {
        private static List_Driver_DAO instance;
        public static List_Driver_DAO Instance
        {
            get
            {
                if (instance == null)
                    instance = new List_Driver_DAO();
                return instance;
            }
        }

        public List<Driver_Motobike_DTO> LstDriver_Motobike { get => lstDriver_Motobike; set => lstDriver_Motobike = value; }
        public List<Driver_Car_DTO> LstDriver_Car { get => lstDriver_Car; set => lstDriver_Car = value; }
        public List<Driver_TaxiCar_DTO> LstDriver_TaxiCar { get => lstDriver_TaxiCar; set => lstDriver_TaxiCar = value; }
        public List<Travell_DTO> LstTravel { get => lstTravel; set => lstTravel = value; }
        public double DoanhThuXeMay1 { get => DoanhThuXeMay; set => DoanhThuXeMay = value; }
        public double DoanhThuXeOTo1 { get => DoanhThuXeOTo; set => DoanhThuXeOTo = value; }
        public double DoanhThuXeTaxi1 { get => DoanhThuXeTaxi; set => DoanhThuXeTaxi = value; }
        public List<Driver_DTO> LstDriver { get => lstDriver; set => lstDriver = value; }

        public List_Driver_DAO() { }

        double DoanhThuXeMay;
        double DoanhThuXeOTo;
        double DoanhThuXeTaxi;
        List<Driver_DTO> lstDriver;
        List<Travell_DTO> lstTravel;
        private List<Driver_Motobike_DTO> lstDriver_Motobike;
        private List<Driver_Car_DTO> lstDriver_Car;
        private List<Driver_TaxiCar_DTO> lstDriver_TaxiCar;

        public List<Driver_DTO> ShowListDriver()
        {
            string fileName = Static_Instance.directory + "\\XML\\data_Driver.xml";

            LstDriver = new List<Driver_DTO>();
            LstDriver_Motobike = new List<Driver_Motobike_DTO>();
            LstDriver_Car = new List<Driver_Car_DTO>();
            LstDriver_TaxiCar = new List<Driver_TaxiCar_DTO>();
            LstTravel = new List<Travell_DTO>();

            XmlDocument reader = new XmlDocument();
            reader.Load(fileName);

            foreach (XmlNode node in reader.DocumentElement.ChildNodes)
            {
                //Driver_DTO driver = new Driver_DTO();

                //driver.Id = node["ID"].InnerText;
                //driver.Name = node["Name"].InnerText;
                //driver.UserName = node["UserName"].InnerText;
                //driver.PassWord = node["Password"].InnerText;
                //driver.Telephone = node["Telephone"].InnerText;
                //driver.Type_Driver = Static_Instance.checkTypeCar(node["Type_Driver"].InnerText);
                //driver.Location_Driver = node["Location"].InnerText;
                //driver.Status = Static_Instance.checkStatus(node["Status"].InnerText);

                string id = node["ID"].InnerText;
                string name = node["Name"].InnerText;
                string username = node["UserName"].InnerText;
                string pass = node["Password"].InnerText;
                string telephone = node["Telephone"].InnerText;
                string typedriver = Static_Instance.checkTypeCar(node["Type_Driver"].InnerText);
                string type = node["Type_Driver"].InnerText;
                string location = node["Location"].InnerText;
                string status = Static_Instance.checkStatus(node["Status"].InnerText);


                Travell_DTO travell = new Travell_DTO(name, username,
                    pass, telephone, status, id, 
                    typedriver, location, "", "", "", 
                    DateTime.Now.ToString(), DateTime.Today.ToString());

                LstTravel.Add(travell);

                if (type == "0")
                {
                    Driver_Motobike_DTO driver = new Driver_Motobike_DTO(name, username, pass,
                        telephone, status, id, typedriver, location);

                    LstDriver_Motobike.Add(driver);
                    LstDriver.Add(driver);
                }
                else if (type == "1")
                {
                    Driver_Car_DTO driver = (new Driver_Car_DTO(name, username, pass,
                        telephone, status, id, typedriver, location,
                        int.Parse(node["Slot"].InnerText)));

                    LstDriver_Car.Add(driver);
                    LstDriver.Add(driver);
                }
                else
                {
                    Driver_TaxiCar_DTO driver = new Driver_TaxiCar_DTO(name, username, 
                        pass, telephone, status, id, typedriver, location,
                        int.Parse(node["Weight"].InnerText));

                    LstDriver_TaxiCar.Add(driver);
                    LstDriver.Add(driver);
                }
            }

            return LstDriver;
        }

        //public double ReturnMoneyTake(string type)
        //{
        //    int far = Math.Abs(int.Parse(Static_Instance.GetLocation) - int.Parse(Static_Instance.GetLocationTo));
        //    double result = 0;
        //    string tempU = Static_Instance.findNameDriver;
        //    string tempCustomer = Static_Instance.findUserName;

        //    if (type == "Xe máy")
        //    {
        //        foreach (Driver_Motobike_DTO item in LstDriver_Motobike)
        //        {
        //            if (tempU == item.Name)
        //            {
        //                foreach (Customer_DTO customer in List_Customer_DAO.Instance.ShowListCustomer_Motobike())
        //                {
        //                    if (customer.UserName == tempCustomer)
        //                    {
        //                        if (customer.TypeCustomer == "VIP" && item.MoneyDriverTake(far) >= 200000)
        //                            result = 0.1f * item.MoneyDriverTake(far);
        //                        else result = item.MoneyDriverTake(far);
        //                    }
        //                } 
        //            } 
        //        }
        //    }
        //    else if (type == "Xe ô tô")
        //    {
        //        foreach (Driver_Car_DTO item in LstDriver_Car)
        //        {
        //            if (tempU == item.Name)
        //            {
        //                foreach (Customer_DTO customer in List_Customer_DAO.Instance.ShowListCustomer_Car())
        //                {
        //                    if (customer.UserName == tempCustomer)
        //                    {
        //                        if (customer.TypeCustomer == "VIP" && item.MoneyDriverTake(far) >= 200000)
        //                            result = 0.1f * item.MoneyDriverTake(far);
        //                        else result = item.MoneyDriverTake(far);
        //                    }
        //                }
        //            }

        //        }
        //    }
        //    else
        //    {
        //        foreach (Driver_TaxiCar_DTO item in LstDriver_TaxiCar)
        //        {
        //            if (tempU == item.Name)
        //            {
        //                foreach (Customer_DTO customer in List_Customer_DAO.Instance.ShowListCustomer_taxiCar())
        //                {
        //                    if (customer.UserName == tempCustomer)
        //                    {
        //                        if (customer.TypeCustomer == "VIP" && item.MoneyDriverTake(far) >= 200000)
        //                            result = 0.1f * item.MoneyDriverTake(far);
        //                        else result = item.MoneyDriverTake(far);
        //                    }
        //                }
        //            }
        //        }
        //    }
        //    return result;
        //}
        public double ReturnMoneyTake()
        {
            double result = 0;
            XmlDocument reader = new XmlDocument();
            reader.Load(Static_Instance.directory + "\\XML\\data_Address.xml");

            foreach (XmlNode node in reader.DocumentElement.ChildNodes)
            {
                int far = Math.Abs(int.Parse(node["Location_From"].InnerText) - 
                    int.Parse(node["Location_To"].InnerText));

                if (node["Type_Car"].InnerText == "0")
                {
                    foreach (Driver_Motobike_DTO item in LstDriver_Motobike)
                    {
                        if (item.UserName == Static_Instance.findUserNameDriver)
                        {
                            foreach (Customer_DTO customer in List_Customer_DAO.Instance.ShowListCustomer_Motobike())
                            {
                                if (customer.UserName == node["UserName_Customer"].InnerText) 
                                {
                                    if (customer.TypeCustomer == "VIP" && item.MoneyDriverTake(far) >= 200000)
                                        result = 0.1f * item.MoneyDriverTake(far);
                                    else result = item.MoneyDriverTake(far);
                                }
                            }
                        }
                    }
                }
                else if (node["Type_Car"].InnerText == "1")
                {
                    foreach (Driver_Car_DTO item in LstDriver_Car)
                    {
                        if (item.UserName == Static_Instance.findUserNameDriver)
                        {
                            foreach (Customer_DTO customer in List_Customer_DAO.Instance.ShowListCustomer_Car())
                            {
                                if (customer.UserName == node["UserName_Customer"].InnerText)
                                {
                                    if (customer.TypeCustomer == "VIP" && item.MoneyDriverTake(far) >= 200000)
                                        result = 0.1f * item.MoneyDriverTake(far);
                                    else result = item.MoneyDriverTake(far);
                                }
                            }
                        }
                    }
                }
                else
                {
                    foreach (Driver_TaxiCar_DTO item in LstDriver_TaxiCar)
                    {
                        if (item.UserName == Static_Instance.findUserNameDriver)
                        {
                            foreach (Customer_DTO customer in List_Customer_DAO.Instance.ShowListCustomer_taxiCar())
                            {
                                if (customer.UserName == node["UserName_Customer"].InnerText)
                                {
                                    if (customer.TypeCustomer == "VIP" && item.MoneyDriverTake(far) >= 200000)
                                        result = 0.1f * item.MoneyDriverTake(far);
                                    else result = item.MoneyDriverTake(far);
                                }
                            }
                        }
                    }
                }
            }

            return result;
        }
        //public double ReturnMoneyGive()
        //{
        //    DoanhThuXeMay1 = 0;
        //    DoanhThuXeOTo1 = 0;
        //    DoanhThuXeTaxi1 = 0;
        //    double RESULT = ReturnMoneyTake();

        //    int far = Math.Abs(int.Parse(Static_Instance.GetLocation) - int.Parse(Static_Instance.GetLocationTo));
        //    double result = 0;
        //    string tempU = Static_Instance.findNameDriver;

        //    string type = "";

        //    if (type == "Xe máy")
        //    {
        //        //foreach (Driver_Motobike_DTO item in LstDriver_Motobike)
        //        //{
        //        //    if (tempU == item.Name)
        //        //        result = item.MoneyGive(far);
        //        //}
        //        result = RESULT * 0.05f;
        //        DoanhThuXeMay1 = DoanhThuXeMay1 + result;
        //    }
        //    else if (type == "Xe ô tô")
        //    {
        //        //foreach (Driver_Car_DTO item in LstDriver_Car)
        //        //{
        //        //    if (tempU == item.Name)
        //        //        result = item.MoneyGive(Math.Abs(int.Parse(Static_Instance.GetLocation) - int.Parse(Static_Instance.GetLocationTo)));
        //        //}
        //        result = RESULT * 0.1f;
        //        DoanhThuXeOTo1 = DoanhThuXeOTo1 + result;
        //    }
        //    else
        //    {
        //        //foreach (Driver_TaxiCar_DTO item in LstDriver_TaxiCar)
        //        //{
        //        //    if (tempU == item.Name)
        //        //        result = item.MoneyGive(Math.Abs(int.Parse(Static_Instance.GetLocation) - int.Parse(Static_Instance.GetLocationTo)));
        //        //}
        //        result = RESULT * 0.15f;
        //        DoanhThuXeTaxi1 = DoanhThuXeTaxi1 + result;
        //    }
        //    return result;
        //}

        public double ReturnMoneyGive()
        {
            double result = 0;
            XmlDocument reader = new XmlDocument();
            reader.Load(Static_Instance.directory + "\\XML\\data_Address.xml");

            foreach (XmlNode node in reader.DocumentElement.ChildNodes)
            {
                int far = Math.Abs(int.Parse(node["Location_From"].InnerText) -
                    int.Parse(node["Location_To"].InnerText));

                if (node["Type_Car"].InnerText == "0")
                {
                    result = ReturnMoneyTake() * 0.05f;
                    DoanhThuXeMay1 = DoanhThuXeMay1 + result;
                }
                else if (node["Type_Car"].InnerText == "1")
                {
                    result = ReturnMoneyTake() * 0.1f;
                    DoanhThuXeOTo1 = DoanhThuXeOTo1 + result;
                }
                else
                {
                    result = ReturnMoneyTake() * 0.15f;
                    DoanhThuXeTaxi1 = DoanhThuXeTaxi1 + result;
                }
            }

            return result;
        }
        

        public void GhiFileTongDoanhThu()
        {
            string fileName = Static_Instance.directory + "\\XML\\data_Analysis.xml";
            XmlDocument d = new XmlDocument();
            d.Load(fileName);

            //XmlNode Analysis = reader.CreateElement("Analysis");
            //XmlNode Motobike = reader.CreateElement("Motobike");
            //XmlNode Car = reader.CreateElement("Car");
            //XmlNode TaxiCar = reader.CreateElement("TaxiCar");
            
            foreach (XmlNode node in d.DocumentElement.ChildNodes)
            {
                double moto = Convert.ToDouble(node["Motobike"].InnerText);
                double car = Convert.ToDouble(node["Car"].InnerText);
                double taxi = Convert.ToDouble(node["TaxiCar"].InnerText);

                foreach (Customer_DTO item in List_Customer_DAO.Instance.ShowListCustomer())
                {
                    if (item.UserName == Static_Instance.findUserName && item.TypeCar == "Xe máy")
                        moto = moto + ReturnTongDoanhThuXeMay();
                    else if (item.UserName == Static_Instance.findUserName && item.TypeCar == "Xe ô tô")
                        car = car + ReturnTongDoanhThuXeOTo();
                    else if (item.UserName == Static_Instance.findUserName && item.TypeCar == "Xe ô tô tải")
                        taxi = taxi + ReturnTongDoanhThuXeTaxi();
                }

                node["Motobike"].InnerText = moto.ToString();
                node["Car"].InnerText = car.ToString();
                node["TaxiCar"].InnerText = taxi.ToString();
            }

            //Analysis.AppendChild(Motobike);
            //Analysis.AppendChild(Car);
            //Analysis.AppendChild(TaxiCar);

            //reader.DocumentElement.AppendChild(Analysis);
            d.Save(fileName);
        }

        public void GhiFileTaiXeDaNhanXe()
        {
            string fileName0 = Static_Instance.directory + "\\XML\\data_Address.xml";
            string fileName = Static_Instance.directory + "\\XML\\data_DriverReceive.xml";
            XmlDocument d = new XmlDocument();
            string locationFROM;
            string locationTO;

            d.Load(fileName0);

            foreach (XmlNode node in d.DocumentElement.ChildNodes)
            {
                if(node["UserName_Customer"].InnerText == Static_Instance.findUserName)
                {
                    locationFROM = node["Location_From"].InnerText;
                    locationTO = node["Location_To"].InnerText;

                    d.Load(fileName);

                    XmlNode Receive = d.CreateElement("Receive");
                    XmlNode UserName_Driver = d.CreateElement("UserName_Driver");
                    XmlNode NameDriver = d.CreateElement("NameDriver");
                    XmlNode UserName_Customer = d.CreateElement("USerName_Customer");
                    XmlNode Name_Customer = d.CreateElement("NameCustomer");
                    XmlNode Location_From = d.CreateElement("Location_From");
                    XmlNode Location_To = d.CreateElement("Location_To");

                    UserName_Driver.InnerText = Static_Instance.findUserNameDriver;
                    NameDriver.InnerText = Static_Instance.findNameDriver;
                    UserName_Customer.InnerText = Static_Instance.findUserName;
                    Name_Customer.InnerText = Static_Instance.findName;
                    Location_From.InnerText = locationFROM;
                    Location_To.InnerText = locationTO;

                    Receive.AppendChild(UserName_Driver);
                    Receive.AppendChild(NameDriver);
                    Receive.AppendChild(UserName_Customer);
                    Receive.AppendChild(Name_Customer);
                    Receive.AppendChild(Location_From);
                    Receive.AppendChild(Location_To);

                    d.DocumentElement.AppendChild(Receive);

                    d.Save(fileName);

                    break;
                }
            }

            
        }

        public double ReturnTongDoanhThuXeMay()
        {
            return DoanhThuXeMay1;
        }
        public double ReturnTongDoanhThuXeOTo()
        {
            return DoanhThuXeOTo1;
        }
        public double ReturnTongDoanhThuXeTaxi()
        {
            return DoanhThuXeTaxi1;
        }

        public List<Travell_DTO> ShowListTravell()
        {
            return LstTravel;
        }

        public List<Driver_DTO> ShowListAllDriver()
        {
            return LstDriver;
        }

        public List<Driver_Motobike_DTO> ShowListDriver_Motobike()
        {
            return LstDriver_Motobike;
        }
        public List<Driver_Car_DTO> ShowListDriver_Car()
        {
            return LstDriver_Car;
        }
        public List<Driver_TaxiCar_DTO> ShowListDriver_taxiCar()
        {
            return LstDriver_TaxiCar;
        }
    }
}
