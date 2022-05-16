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
using ZeleznicaAplikacija.gui;

namespace ZeleznicaAplikacija
{
  
    public partial class MainWindow : Window
    {
        private UserService userService;
        public WelcomeWindowClient welcomeWindowClient;
        
        void SetProperties()
        {
            this.Title = "Prijava";

            Uri iconUri = new Uri("../../images/logo.png", UriKind.RelativeOrAbsolute);
            this.Icon = BitmapFrame.Create(iconUri);
        }
        public MainWindow()
        {
            InitializeComponent();
            SetProperties();
            Uri iconUri = new Uri("../../images/train.png", UriKind.RelativeOrAbsolute);
            //imegePicture.Source = BitmapFrame.Create(iconUri);
            MainRepository mainRepository = new MainRepository();
            userService = new UserService();
        }
        
        private void ButtonLogIn(object sender, RoutedEventArgs e)
        {
            string name = userNameTxt.Text;
            string password = passwordTxt.Text;
            UserType type = userService.logIn(name, password);
            if (type == UserType.NO_TYPE)
            {
                //neka poruka
            }else if (type == UserType.CLIENT)
            {
                MainRepository.setLoggedUser(name);
                //prozor klijenta
            }
            else
            {
                MainRepository.setLoggedUser(name);
                //prozor menadzera
            }

        }
    }
}
