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
        
        void SetProperties()
        {
            this.Title = "Prijava";

            Uri iconUri = new Uri("../../images/logo1.png", UriKind.RelativeOrAbsolute);
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
            frame.Content = new LoginPage(frame);
        }
       
    }
}
