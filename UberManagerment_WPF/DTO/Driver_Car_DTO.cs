using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UberManagerment_WPF.Interface;

namespace UberManagerment_WPF.DTO
{
    public class Driver_Car_DTO : Driver_DTO
    {
        int slot;

        public int Slot 
        { 
            get => slot; 
            set
            {
                if (value != 4 && value != 6)
                    slot = 4;
                else slot = value;
            }
        }

        public Driver_Car_DTO() : base()
        {
            Slot = 4;
        }

        public Driver_Car_DTO(string Name, string UserName, string Password, string Telephone, string Status, 
            string Id, string Type_Driver, string Location_Driver, int Slot)
            : base(Name, UserName, Password, Telephone, Status, Id, Type_Driver, Location_Driver)
        {
            this.Slot = Slot;
        }

        //public double MoneyGive(int far)
        //{
        //    return MoneyTake(far) * 0.1;
        //}

        //public double MoneyTake(int far)
        //{
        //    double result;
        //    if (slot == 4)
        //    {
        //        if (far <= 2)
        //            result = 2 * 1500;
        //        else if (far <= 7)
        //            result = (2 * 1500) + (far - 2) * 1200;
        //        else result = (2 * 1500) + (far - 2) * 1200 + (far - 7) * 8000;
        //    }
        //    else
        //    {
        //        if (far <= 2)
        //            result = 2 * 1700;
        //        else if (far <= 7)
        //            result = (2 * 1700) + (far - 2) * 1500;
        //        else result = (2 * 1700) + (far - 2) * 1500 + (far - 7) * 10000;
        //    }
        //    return result + (far * 500);
        //}

        public override double MoneyDriverTake(int far)
        {
            double result;
            if (slot == 4)
            {
                if (far <= 2)
                    result = 2 * 1500;
                else if (far <= 7)
                    result = (2 * 1500) + (far - 2) * 1200;
                else result = (2 * 1500) + (far - 2) * 1200 + (far - 7) * 8000;
            }
            else
            {
                if (far <= 2)
                    result = 2 * 1700;
                else if (far <= 7)
                    result = (2 * 1700) + (far - 2) * 1500;
                else result = (2 * 1700) + (far - 2) * 1500 + (far - 7) * 10000;
            }
            return result + (far * 500);
        }

        public override double MoneyDriverGive(int far)
        {
            return MoneyDriverTake(far) * 0.1;
        }
    }
}
