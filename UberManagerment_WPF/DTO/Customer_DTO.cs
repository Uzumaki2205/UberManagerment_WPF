using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UberManagerment_WPF.Interface;

namespace UberManagerment_WPF.DTO
{
    public class Customer_DTO : Account
    {
        string typeCustomer;
        string typeCar;
        string location_Customer;

        public string TypeCustomer { get => typeCustomer; set => typeCustomer = value; }
        public string TypeCar { get => typeCar; set => typeCar = value; }
        public string Location_Customer { get => location_Customer; set => location_Customer = value; }

        public Customer_DTO() : base()
        {
            Name = "";
            UserName = "";
            PassWord = "";
            Telephone = "";
            TypeCustomer = "0";
            TypeCar = "";
            Location_Customer = "";
        }

        public Customer_DTO(string Name, string UserName, string Password, string Telephone, string Status,
            string TypeCustomer, string TypeCar, string Location_Customer)
            : base(Name, UserName, Password, Telephone, Status)
        {
            this.TypeCustomer = TypeCustomer;
            this.TypeCar = TypeCar;
            this.Location_Customer = Location_Customer;
        }

        public static int GetLocation()
        {
            Random random = new Random();
            return random.Next(0, 999);
        }
    }
}
