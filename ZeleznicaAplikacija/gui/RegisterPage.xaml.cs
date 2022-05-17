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
using ZeleznicaAplikacija.model;

namespace ZeleznicaAplikacija.gui
{
    /// <summary>
    /// Interaction logic for RegisterPage.xaml
    /// </summary>
    public partial class RegisterPage : Page
    {
        private Frame frame;
        private User user;

        public RegisterPage(Frame f)
        {
            InitializeComponent();
            frame = f;
            this.DataContext = this;
        }

        private void RegisterHandler(object sender, RoutedEventArgs e) 
        {
            string email = userNameTxt.Text;
            string firstName = firstNameTxt.Text;
            string lastName = lastNameTxt.Text;
            string password1 = passwordTxt1.Password.ToString();
            string password2 = passwordTxt2.Password.ToString();
            string phone = phoneTxt.Text;

            DateTime? dateOfBirth = datePicker1.SelectedDate;
            if (dateOfBirth.HasValue)
            {
                string formatted = dateOfBirth.Value.ToString("dd.MM.yyyy", System.Globalization.CultureInfo.InvariantCulture);
            }

            

        }

        private void LoginLinkCommand(object sender, RoutedEventArgs e)
        {
            frame.Content = new LoginPage(frame);
        }
    }
}
