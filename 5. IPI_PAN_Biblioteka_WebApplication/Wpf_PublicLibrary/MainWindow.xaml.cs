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
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using Newtonsoft.Json;

namespace Wpf_PublicLibrary
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
        private async void BtnReader_Click(object sender, RoutedEventArgs e)
        {
            await Request("https://localhost:44382/PublicLibraryReader/ListReaders");
        }
        private async void BtnBookRental_Click(object sender, RoutedEventArgs e)
        {
            await Request("https://localhost:44382/PublicLibraryBookRental/Rental/CreateNewBookRental");
        }
        private async void BtnBook_Click(object sender, RoutedEventArgs e)
        {
            await Request("https://localhost:44382/PublicLibraryBook/ListBooks");
        }
        private async Task Request(string uri)
        {
            try
            {
                txb.Clear();
                using (var client = new HttpClient())
                {
                    HttpResponseMessage response = client.GetAsync(uri).Result;
                    if (response.IsSuccessStatusCode)
                    {
                        txb.Text = await response.Content.ReadAsStringAsync();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
