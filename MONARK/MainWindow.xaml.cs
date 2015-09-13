using System.IO;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using Microsoft.Win32;

namespace MONARK
{
    /// <summary>
    ///     Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private string ApiKey;
        private bool ApiLoaded;
        private bool CsvLoaded;
        private string csvLocation;

        public MainWindow()
        {
            InitializeComponent();
            Loaded += MainWindow_Loaded;
        }

        private void MainWindow_Loaded(object sender, RoutedEventArgs e)
        {
            CsvLoaded = false;
            ApiLoaded = false;
            Send.IsEnabled = false;
        }


        private void gotFocus(object sender, RoutedEventArgs e)
        {
            var tb = (TextBox) sender;
            tb.Text = string.Empty;
            tb.GotFocus -= gotFocus;
        }

        private void RetGotFocus(object sender, RoutedEventArgs e)
        {
            if (!CsvLoaded)
            {
                var tb = (TextBox) sender;
                tb.Text = string.Empty;
                tb.GotFocus -= RetGotFocus;
            }
        }

        private void MsgGotFocus(object sender, RoutedEventArgs e)
        {
            var tb = (TextBox) sender;
            tb.Text = string.Empty;
            tb.GotFocus -= MsgGotFocus;
        }

        private void Load_Click(object sender, RoutedEventArgs e)
        {
            var filename = "CSV Not loaded.";
            var dlg = new OpenFileDialog();
            dlg.DefaultExt = ".csv";
            dlg.Filter = "CSV Files (*.csv)|*.csv";
            var result = dlg.ShowDialog();
            if (result == true)
            {
                filename = dlg.FileName;
                csvLocation = filename;
                RecBox.Text = "CSV Loaded...";
                RecBox.Background = Brushes.WhiteSmoke;
                RecBox.IsReadOnly = true;
                CsvLoaded = true;
            }
            CsvLoad.Content = "CSV Loaded: " + filename;
        }

        private void LoadApi_Click(object sender, RoutedEventArgs e)
        {
            var ApiLoc = "";
            var dlg = new OpenFileDialog();
            dlg.DefaultExt = ".mapi";
            dlg.Filter = "MAPI Files (*.mapi)|*.mapi";
            var result = dlg.ShowDialog();
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
            if (CsvLoaded)
            {
                if (csvLocation != null)
                {
                    var MS = new MultiSend(csvLocation, ApiKey);
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
                var SS = new SingleSend();
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