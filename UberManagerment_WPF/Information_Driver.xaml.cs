using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using UberManagerment_WPF.BUS;

namespace UberManagerment_WPF
{
    /// <summary>
    /// Interaction logic for Information_Driver.xaml
    /// </summary>
    public partial class Information_Driver : Page
    {
        public Information_Driver()
        {
            InitializeComponent();
            LoadInfo();
        }

        void LoadInfo()
        {
            List_Driver_BUS.Instance.ShowListAllDriver(dtgInfoDriver);
        }
    }
}
