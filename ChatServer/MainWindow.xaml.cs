using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
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

namespace ChatServer
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        TcpListener listener ;

        public MainWindow()
        {
            InitializeComponent();
            IPAddress iPAddress = new IPAddress(new byte[] { 192, 168, 1, 16 });
            DataContext = this;

            listener = new TcpListener(iPAddress,5050);
        }

        private async void Button_Click(object sender, RoutedEventArgs e)
        {

            listener.Start();
            addInfo("connection started\nWaiting for client connection ... ");

           var client = await listener.AcceptTcpClientAsync();

           string clientInfo =  client.Client.RemoteEndPoint.ToString();

            addInfo($"accept connection from : {clientInfo}");


            NetworkStream stream = client.GetStream();
            StreamReader reader = new StreamReader(stream);

            char[] str = new char[100];
            await reader.ReadAsync(str,0,100);
            addInfo($" client say: {new string(str)}");


        }

        private void addInfo(string msg)
        {
            InformationBox.Text += $"{msg}\n";
        }
    }
}
