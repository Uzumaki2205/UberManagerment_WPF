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
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void MoveCursorMenu(int index)
        {
            transition_Content.OnApplyTemplate();
            GridCursor.Margin = new Thickness(0, 50 + (60 * index), 0, 0);
        }

        private void btn_CommandClick(object sender, RoutedEventArgs e)
        {
            Button btnClick = sender as Button;
            if (btnClick.Tag.Equals("btnClose"))
            {
                MessageBoxResult result = MessageBox.Show("Bạn có muốn thoát??", "Warning!!", MessageBoxButton.OKCancel, MessageBoxImage.Warning);
                if (result == MessageBoxResult.OK)
                    this.Close();
            }
            else if (btnClick.Tag.Equals("btnMaximize"))
            {
                if (this.WindowState == WindowState.Maximized)
                {
                    this.WindowState = WindowState.Normal;
                }
                else
                {
                    this.WindowState = WindowState.Maximized;
                }
            }
            else if (btnClick.Tag.Equals("btnMinimize"))
                this.WindowState = WindowState.Minimized;
        }

        private void Menu_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            int index = Menu.SelectedIndex;
            MoveCursorMenu(index);

            switch (index)
            {
                case 0:
                    break;
                case 1:
                    Frame1.Navigate(new Information_Customer());
                    Frame2.Navigate(new Information_Driver());
                    Frame1.Visibility = Visibility.Visible;
                    Frame2.Visibility = Visibility.Visible;
                    Frame3.Visibility = Visibility.Hidden;
                    break;
                case 2:
                    Frame1.Navigate(new Register());
                    Frame1.Visibility = Visibility.Visible;
                    Frame2.Visibility = Visibility.Hidden;
                    Frame3.Visibility = Visibility.Hidden;
                    break;
                case 3:
                    Frame1.Visibility = Visibility.Visible;
                    Frame2.Visibility = Visibility.Visible;
                    Frame3.Visibility = Visibility.Visible;
                    Frame1.Navigate(new ShowDriverMotobike());
                    Frame2.Navigate(new ShowDriverCar());
                    Frame3.Navigate(new ShowDriverTaxiCar());
                    break;
                case 4:
                    Frame1.Navigate(new ShowTravell());
                    Frame1.Visibility = Visibility.Visible;
                    Frame2.Visibility = Visibility.Hidden;
                    Frame3.Visibility = Visibility.Hidden;
                    break;
                case 5:
                    Frame1.Navigate(new Analystic());
                    Frame1.Visibility = Visibility.Visible;
                    Frame2.Visibility = Visibility.Hidden;
                    Frame3.Visibility = Visibility.Hidden;
                    break;
                default:
                    break;
            }
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            //Frame1.Navigate(new Information_Customer());
        }
    }
}
