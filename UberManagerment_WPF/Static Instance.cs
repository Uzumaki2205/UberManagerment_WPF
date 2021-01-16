using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UberManagerment_WPF
{
    class Static_Instance
    {
        public static string directory = Directory.GetParent(Directory.GetParent(Environment.CurrentDirectory).ToString()).ToString();
        public static string checkTypeCustomer (string type)
        {
            string result = "";
            if (type == "1")
                result = "VIP";
            else result = "Normal";

            return result;
        }
        public static string checkTypeCar (string type)
        {
            string result = "";
            if (type == "0")
                result = "Xe máy";
            else if (type == "1")
                result = "Xe ô tô";
            else if (type == "2")
                result = "Xe ô tô tải";
            else result = "Not Choose";
            return result;
        }
        public static string checkTypeCar_Converted(string type)
        {
            string result = "";
            if (type.ToLower() == "xe máy")
                result = "0";
            else if (type.ToLower() == "xe ô tô")
                result = "1";
            else if (type.ToLower() == "xe ô tô tải")
                result = "2";

            return result;
        }
        public static string findUserName;
        public static string findName;
        public static string findNameDriver;
        public static string findUserNameDriver;
        public static string tempTitile;
        public static string GetLocation;
        public static string GetLocationTo;
        public static string checkStatus(string status)
        {
            if (status == "0")
                return "Offline";
            else if (status == "1")
                return "Online";
            else return "received";
        }
        public static string validateStatus;
        public static string check_CallBike_TypeCustomer(string num)
        {
            if (num == string.Empty)
                num = "0";

            int x = int.Parse(num);
            string result = "";

            if (x > 15)
                result = "1";
            else result = "0";

            return result;
        }
        public static string Count_CallCar(string count)
        {
            if (count == string.Empty)
                count = "0";

            int result = int.Parse(count);
            result++;

            return result.ToString();
        }
    }
}
