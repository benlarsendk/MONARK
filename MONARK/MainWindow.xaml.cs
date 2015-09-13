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

namespace MONARK
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private bool CsvLoaded = true;
        public MainWindow()
        {
            InitializeComponent();
        }

        private void gotFocus(object sender, RoutedEventArgs e)
        {
            TextBox tb = (TextBox)sender;
            tb.Text = string.Empty;
            tb.GotFocus -= gotFocus;
        }

        private void RetGotFocus(object sender, RoutedEventArgs e)
        {
            if (!CsvLoaded)
            {
                TextBox tb = (TextBox)sender;
                tb.Text = string.Empty;
                tb.GotFocus -= RetGotFocus;
            }

        }

        private void MsgGotFocus(object sender, RoutedEventArgs e)
        {
            TextBox tb = (TextBox)sender;
            tb.Text = string.Empty;
            tb.GotFocus -= MsgGotFocus;
        }

        private void Load_Click(object sender, RoutedEventArgs e)
        {
            string filename = "CSV Not loaded.";
            Microsoft.Win32.OpenFileDialog dlg = new Microsoft.Win32.OpenFileDialog();
            dlg.DefaultExt = ".csv";
            dlg.Filter = "CSV Files (*.csv)|*.csv";
            Nullable<bool> result = dlg.ShowDialog();
            if (result == true)
            {
                filename = dlg.FileName;
                RecBox.Text="CSV Loaded...";
                RecBox.Background = Brushes.WhiteSmoke;
                RecBox.IsReadOnly = true;
            }
            CsvLoad.Content = "CSV Loaded: " + filename;

        }
    }
}
