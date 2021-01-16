using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UberManagerment_WPF.DTO
{
    public abstract class Driver_DTO : Account
    {
        string id;
        string type_Driver;
        string location_Driver;

        public string Id { get => id; set => id = value; }
        public string Type_Driver { get => type_Driver; set => type_Driver = value; }
        public string Location_Driver { get => location_Driver; set => location_Driver = value; }

        public Driver_DTO() : base()
        {
            Id = "";
            Type_Driver = "0";
        }
        public Driver_DTO(string Name, string UserName, string Password, string Telephone, string Status, 
            string Id, string Type_Driver, string Location_Driver)
            : base (Name, UserName, Password, Telephone, Status)
        {
            this.Id = Id;
            this.Type_Driver = Type_Driver;
            this.Location_Driver = Location_Driver;
        }

        public static int GetLocation()
        {
            Random random = new Random();
            return random.Next(0, 999);
        }

        public abstract double MoneyDriverTake(int far);
        public abstract double MoneyDriverGive(int far);
    }
}
