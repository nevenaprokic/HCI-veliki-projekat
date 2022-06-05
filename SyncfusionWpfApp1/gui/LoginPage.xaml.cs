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
using SyncfusionWpfApp1.Model;
using SyncfusionWpfApp1.repo;
using SyncfusionWpfApp1.service;

namespace SyncfusionWpfApp1.gui
{
    public partial class LoginPage : Page
    {
        private UserService userService;
        private Frame frame;

        public LoginPage(Frame f)
        {
            InitializeComponent();
            ImageBrush myBrush = new ImageBrush();
            myBrush.ImageSource = new BitmapImage(new Uri("../../../images/ReservationBackground.png", UriKind.Relative));
            this.Background = myBrush;
            Uri iconUriMail = new Uri("../../../images/mail.png", UriKind.RelativeOrAbsolute);
            mailIcon.Source = BitmapFrame.Create(iconUriMail);
            Uri iconUriPassword = new Uri("../../../images/password.png", UriKind.RelativeOrAbsolute);
            passwordIcon.Source = BitmapFrame.Create(iconUriPassword);
            userService = new UserService();
            frame = f;
        }

        private void ButtonLogIn(object sender, RoutedEventArgs e)
        {
            string name = userNameTxt.Text;
            string password = passwordTxt.Password.ToString();
            UserType type = userService.logIn(name, password);
            if (type == UserType.NO_TYPE)
            {
                //neka poruka
            }
            else if (type == UserType.CLIENT)
            {
                MainRepository.setLoggedUser(name);
                frame.Content = new WelcomePageClient(frame);
            }
            else
            {
                MainRepository.setLoggedUser(name);
                frame.Content = new WelcomePageManager(frame);
            }

        }

    }
}
