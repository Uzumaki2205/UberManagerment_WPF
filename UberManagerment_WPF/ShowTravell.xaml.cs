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
using UberManagerment_WPF.DAO;

namespace UberManagerment_WPF
{
    /// <summary>
    /// Interaction logic for ShowTravell.xaml
    /// </summary>
    public partial class ShowTravell : Page
    {
        public ShowTravell()
        {
            InitializeComponent();
            LoadInfo();
        }
        void LoadInfo()
        {
            List_Travell_BUS.Instance.ShowListTravell(dtgInfoTravel);
        }

        private void btnShow_Click(object sender, RoutedEventArgs e)
        {
            
        }
    }
}
