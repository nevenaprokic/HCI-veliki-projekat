using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Text.RegularExpressions;
using SyncfusionWpfApp1.Model;

namespace SyncfusionWpfApp1.gui
{
    public partial class CreatePoint : Window
    {
        private string Latitude;
        private string Longitude;
        private string BingMapsKey = "AusVMyYktKC6acBY2olTotz0tcbvBRx6Oal5XaWYcP-lXLpvW2Ejy162U2hIubv6";
        private string State;
        private string Street;
        private string City;
        public delegate void someDelegate();
        public delegate void saveDelegate(string street, string city, string state, double price, int minute);
        private bool IsFirst;
        public AddNewTrainLine Parent { get; set; }
        public CreatePoint(string latitude, string longitude, AddNewTrainLine parent, bool isFirst)
        {
            InitializeComponent();
            Latitude = latitude;
            Longitude = longitude;
            Parent = parent;
            sendRequest();
            addressLabel.Content = Street + ", " + City + ", " + State;
            IsFirst = isFirst;
            if (IsFirst)
            {
                price.Visibility = Visibility.Hidden;
                intervalTextBox.Visibility = Visibility.Hidden;
                priceLbl.Visibility = Visibility.Hidden;
                intervalLbl.Visibility = Visibility.Hidden;
            }

        }
        private void sendRequest()
        {
            HttpWebRequest req = (HttpWebRequest)WebRequest.Create("http://" + $@"dev.virtualearth.net/REST/v1/Locations/{Latitude}, {Longitude}?includeEntityTypes=Address, Neighborhood, CountryRegion&includeNeighborhood=1&include=ciso2&key={BingMapsKey}");

            HttpWebResponse res = (HttpWebResponse)req.GetResponse();
            StreamReader sr = new StreamReader(res.GetResponseStream());

            string temp = sr.ReadToEnd();
            if (temp.Contains("locality"))
            {
                string[] formattedAddress = temp.Split("formattedAddress")[1].Split(',');
                Street = formattedAddress[0].Substring(3, formattedAddress[0].Length-3);
                City = formattedAddress[1].Substring(6, formattedAddress[1].Length-6).Trim();
                State = formattedAddress[2].Substring(0, formattedAddress[2].Length-1).Trim();
            }
            
        }
        private void GoBack_Handler(object sender, RoutedEventArgs e)
        {
            someDelegate p = new someDelegate(Parent.DeleteLast);
            p.Invoke();
            this.Close();
        }
        private void NumberValidationTextBox(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^0-9]+");
            e.Handled = regex.IsMatch(e.Text);
        }
        private bool ValidateInput()
        {
            intervalValidationLabel.Content = "";
            priceValidationLabel.Content = "";

            if (price.Text == "")
            {
                priceValidationLabel.Content = "Cena je obavezana.";
                return false;
            }
            if (intervalTextBox.Text == "")
            {
                intervalValidationLabel.Content = "Vremenski period je obavezan.";
                return false;
            }
            
            return true;
        }

        private void Save_Handler(object sender, RoutedEventArgs e)
        {
            if (IsFirst)
            {
                saveDelegate p = new saveDelegate(Parent.SaveLast); 
                p.Invoke(Street, City, State, 0, 0);
                this.Close();
            }
            else {
                if (ValidateInput())
                {
                    saveDelegate p = new saveDelegate(Parent.SaveLast);
                    p.Invoke(Street, City, State, double.Parse(price.Text), int.Parse(intervalTextBox.Text));
                    this.Close();
                }
            }
            
        }
    }
}
