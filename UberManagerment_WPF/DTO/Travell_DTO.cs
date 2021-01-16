using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UberManagerment_WPF.DTO
{
    public class Travell_DTO : Driver_DTO
    {
        string nameDriver;
        string nameCustomer;
        string location_From;
        string location_To;
        string timeStart;
        string date;
        double moneyTake;
        double moneyGive;

        public string NameDriver { get => nameDriver; set => nameDriver = value; }
        public string NameCustomer { get => nameCustomer; set => nameCustomer = value; }
        public string Location_From { get => location_From; set => location_From = value; }
        public string Location_To { get => location_To; set => location_To = value; }
        public string TimeStart { get => timeStart; set => timeStart = value; }
        public string Date { get => date; set => date = value; }
        public double MoneyTake { get => moneyTake; set => moneyTake = value; }
        public double MoneyGive { get => moneyGive; set => moneyGive = value; }

        public Travell_DTO(string Name, string UserName, string Password, string Telephone, 
            string Status, string Id, string Type_Driver, string Location_Driver, string NameCustomer, 
            string Location_From, string Location_To, string TimeStart, string Date) 
            : base(Name, UserName, Password, Telephone, Status, Id, Type_Driver, Location_Driver) 
        {
            this.NameCustomer = NameCustomer;
            this.location_From = Location_From;
            this.Location_To = Location_To;
            this.TimeStart = TimeStart;
            this.Date = Date;
            MoneyGive = 0;
            MoneyTake = 0;
        }

        public Travell_DTO() 
        {
            NameDriver = "";
            NameCustomer = "";
            Location_From = "0";
            Location_To = "0";
            TimeStart = "0";
            Date = "0";
            MoneyGive = 0;
            MoneyTake = 0;
        }

        public override double MoneyDriverTake(int far)
        {
            throw new NotImplementedException();
        }

        public override double MoneyDriverGive(int far)
        {
            throw new NotImplementedException();
        }
    }
}
