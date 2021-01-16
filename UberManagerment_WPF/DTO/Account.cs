using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UberManagerment_WPF.DTO
{
    public class Account
    {
        string name;
        string userName;
        string passWord;
        string telephone;
        string status;

        public string Name { get => name; set => name = value; }
        public string UserName { get => userName; set => userName = value; }
        public string PassWord { get => passWord; set => passWord = value; }
        public string Telephone { get => telephone; set => telephone = value; }
        public string Status { get => status; set => status = value; }

        public Account()
        {
            Name = "";
            UserName = "";
            PassWord = "";
            Telephone = "";
            Status = "0";
        }
        public Account(string Name, string UserName, string Password, string Telephone, string Status)
        {
            this.Name = Name;
            this.UserName = UserName;
            this.PassWord = Password;
            this.Telephone = Telephone;
            this.Status = Status;
        }
    }
}
