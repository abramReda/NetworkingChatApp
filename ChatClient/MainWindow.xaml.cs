using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Sockets;
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

namespace ChatClient
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

        private async void start_Click(object sender, RoutedEventArgs e)
        {
            TcpClient client = new TcpClient("192.168.1.16",5050);
            NetworkStream stream = client.GetStream();

            addInfo("connected to the server correctly");

            StreamWriter Writer = new StreamWriter(stream);

            await Writer.WriteLineAsync("hallo from client");
            await Writer.FlushAsync();
        }

        private void addInfo(string msg)
        {
            InformationBox.Text += $"{msg}\n";
        }
    }
}
