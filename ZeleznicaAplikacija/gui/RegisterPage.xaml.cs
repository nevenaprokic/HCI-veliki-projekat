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
using ZeleznicaAplikacija.validators;

namespace ZeleznicaAplikacija.gui
{
    /// <summary>
    /// Interaction logic for RegisterPage.xaml
    /// </summary>
    public partial class RegisterPage : Page
    {
        private Frame frame;

        public RegisterPage(Frame f)
        {
            InitializeComponent();
            ImageBrush myBrush = new ImageBrush();
            myBrush.ImageSource = new BitmapImage(new Uri("../../images/back.jpg", UriKind.Relative));
            this.Background = myBrush;
            mailIcon.Source = BitmapFrame.Create(new Uri("../../images/username.png", UriKind.RelativeOrAbsolute));
            nameIcon.Source = BitmapFrame.Create(new Uri("../../images/name.png", UriKind.RelativeOrAbsolute));
            lastNameIcon.Source = BitmapFrame.Create(new Uri("../../images/name.png", UriKind.RelativeOrAbsolute));
            passwordIcon.Source = BitmapFrame.Create(new Uri("../../images/password.png", UriKind.RelativeOrAbsolute));
            password1Icon.Source = BitmapFrame.Create(new Uri("../../images/password.png", UriKind.RelativeOrAbsolute));
            phoneIcon.Source = BitmapFrame.Create(new Uri("../../images/phone.png", UriKind.RelativeOrAbsolute));
            dateIcon.Source = BitmapFrame.Create(new Uri("../../images/date.png", UriKind.RelativeOrAbsolute));
            typeIcon.Source = BitmapFrame.Create(new Uri("../../images/type.png", UriKind.RelativeOrAbsolute));
            frame = f;
        }

        private void RegisterHandler(object sender, RoutedEventArgs e) 
        {
            string email = userNameTxt.Text;
            string firstName = firstNameTxt.Text;
            string lastName = lastNameTxt.Text;
            string password1 = passwordTxt1.Password.ToString();
            string password2 = passwordTxt2.Password.ToString();
            string phone = phoneTxt.Text;

            // datum je po default-u danasnji tako da ne moze biti nevalidan u sustini
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

        private void onPasswordChanged1(object sender, RoutedEventArgs e)
        {
            (DataContext as UserValidation).SetPassword1((sender as PasswordBox).SecurePassword);
        }

        private void onPasswordChanged2(object sender, RoutedEventArgs e)
        {
            (DataContext as UserValidation).SetPassword2((sender as PasswordBox).SecurePassword);
        }
    }
}
