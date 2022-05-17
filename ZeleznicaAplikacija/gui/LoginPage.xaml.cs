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
using ZeleznicaAplikacija.repo;
using ZeleznicaAplikacija.service;

namespace ZeleznicaAplikacija.gui
{
    /// <summary>
    /// Interaction logic for LoginPage.xaml
    /// </summary>
    public partial class LoginPage : Page
    {
        private UserService userService;
        private Frame frame;

        public LoginPage(Frame f)
        {
            InitializeComponent();
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

        private void RegisterLinkCommand(object sender, RoutedEventArgs e)
        {
            frame.Content = new RegisterPage(frame);
        }
    }
}
