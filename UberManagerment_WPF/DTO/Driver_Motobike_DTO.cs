using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UberManagerment_WPF.Interface;

namespace UberManagerment_WPF.DTO
{
    public class Driver_Motobike_DTO : Driver_DTO
    {
        public Driver_Motobike_DTO() : base() { }
        public Driver_Motobike_DTO(string Name, string UserName, string Password, string Telephone, string Status, 
            string Id, string Type_Driver, string Location_Driver)
            : base(Name, UserName, Password, Telephone, Status, Id, Type_Driver, Location_Driver) { }

        public override double MoneyDriverGive(int far)
        {
            return MoneyDriverTake(far) * 0.05;
        }

        public override double MoneyDriverTake(int far)
        {
            double result;
            if (far <= 2)
                result = 2 * 8000;
            else result = (2 * 8000) + (far - 2) * 5000;

            return result;
        }

        //public double MoneyGive(int far)
        //{
        //    return MoneyTake(far) * 0.05;
        //}

        //public double MoneyTake(int far)
        //{
        //    double result;
        //    if (far <= 2)
        //        result = 2 * 8000;
        //    else result = (2 * 8000) + (far - 2) * 5000;

        //    return result;
        //}
    }
}
