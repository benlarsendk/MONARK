using System;
using System.Collections.Generic;
using System.IO;
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
        private bool CsvLoaded;
        private bool ApiLoaded;
        private string ApiKey;
        private string csvLocation;

        public MainWindow()
        {
            InitializeComponent();
            this.Loaded += new RoutedEventHandler(MainWindow_Loaded);
        }

        void MainWindow_Loaded(object sender, RoutedEventArgs e)
        {
            CsvLoaded = false;
            ApiLoaded = false;
            Send.IsEnabled = false;
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
                csvLocation = filename;
                RecBox.Text="CSV Loaded...";
                RecBox.Background = Brushes.WhiteSmoke;
                RecBox.IsReadOnly = true;
                CsvLoaded = true;
            }
            CsvLoad.Content = "CSV Loaded: " + filename;

        }

        private void LoadApi_Click(object sender, RoutedEventArgs e)
        {
            string ApiLoc = "";
            Microsoft.Win32.OpenFileDialog dlg = new Microsoft.Win32.OpenFileDialog();
            dlg.DefaultExt = ".mapi";
            dlg.Filter = "MAPI Files (*.mapi)|*.mapi";
            Nullable<bool> result = dlg.ShowDialog();
            if (result == true)
            {
                ApiLoc = dlg.FileName;
                var reader = new StreamReader(File.OpenRead(@ApiLoc));
                ApiKey = reader.ReadLine();
                if (ApiKey.Length == 16)
                {
                    ApiLoaded = true;
                    Send.IsEnabled = true;
                    API.Content = "API Key loaded";
                }
                else MessageBox.Show("Wrong API-key");
            }

          
        }


        private void Send_Click(object sender, RoutedEventArgs e)
        {
            if (CsvLoaded == true)
            {
                if (csvLocation != null)
                {
                    MultiSend MS = new MultiSend(csvLocation,ApiKey);
                    if (MS.Send(SenBox.Text, MsgBox.Text))
                    {
                        MessageBox.Show("Success!");
                        MsgBox.Text = "Message...";
                        RecBox.Text = "Reciever...";
                        SenBox.Text = "Sender...";
                        csvLocation = "";
                        RecBox.Text = "CSV Not loaded";
                        RecBox.Background = Brushes.White;
                        RecBox.IsReadOnly = false;
                        CsvLoaded = false;

                    }
                }
            }
            else
            {
                // R S M
                SingleSend SS = new SingleSend();
                if (SS.Send(RecBox.Text, SenBox.Text, MsgBox.Text, ApiKey))
                {
                    MessageBox.Show("Success!");
                    MsgBox.Text = "Message...";
                    RecBox.Text = "Reciever...";
                    SenBox.Text = "Sender...";

                }
            }
        }
    }
}
