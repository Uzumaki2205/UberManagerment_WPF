using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UberManagerment_WPF.Interface;

namespace UberManagerment_WPF.DTO
{
    public class Driver_TaxiCar_DTO : Driver_DTO
    {
        int weight;

        public int Weight {  get => weight; set => weight = value; }

        public Driver_TaxiCar_DTO(string Name, string UserName, string Password, string Telephone, string Status, 
            string Id, string Type_Driver, string Location_Driver, int Weight) 
            : base(Name, UserName, Password, Telephone, Status, Id, Type_Driver, Location_Driver)
        {
            this.Weight = Weight;
        }

        public Driver_TaxiCar_DTO(){}

        //public double MoneyTake(int far)
        //{
        //    double result;
        //    if (weight <= 3)
        //    {
        //        if (far <= 5)
        //            result = 5 * 60000;
        //        else if (far <= 10)
        //            result = (5 * 60000) + (far - 5) * 50000;
        //        else result = (5 * 60000) + (far - 5) * 50000 + (far - 10) * 30000;
        //    }
        //    else
        //    {
        //        if (far <= 5)
        //            result = 5 * 70000;
        //        else if (far <= 10)
        //            result = (5 * 70000) + (far - 5) * 60000;
        //        else result = (5 * 70000) + (far - 5) * 60000 + (far - 10) * 40000;
        //    }
        //    return result + (far * 5000);
        //}

        //public double MoneyGive(int far)
        //{
        //    return MoneyTake(far) * 0.15;
        //}

        public override double MoneyDriverTake(int far)
        {
            double result;
            if (weight <= 3)
            {
                if (far <= 5)
                    result = 5 * 60000;
                else if (far <= 10)
                    result = (5 * 60000) + (far - 5) * 50000;
                else result = (5 * 60000) + (far - 5) * 50000 + (far - 10) * 30000;
            }
            else
            {
                if (far <= 5)
                    result = 5 * 70000;
                else if (far <= 10)
                    result = (5 * 70000) + (far - 5) * 60000;
                else result = (5 * 70000) + (far - 5) * 60000 + (far - 10) * 40000;
            }
            return result + (far * 5000);
        }

        public override double MoneyDriverGive(int far)
        {
            return MoneyDriverTake(far) * 0.15;
        }
    }
}
