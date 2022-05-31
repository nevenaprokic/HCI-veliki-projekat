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

namespace SyncfusionWpfApp1.gui
{
    public partial class NetworkTrainLine : Page
    {
        private Frame frame;
        Point startPoint = new Point();
        public NetworkTrainLine(Frame f)
        {
            InitializeComponent();
            frame = f;
            ImageBrush myBrush = new ImageBrush();
            myBrush.ImageSource = new BitmapImage(new Uri("../../../images/ReservationBackground.png", UriKind.Relative));
            this.Background = myBrush;
        }
        private void ListView_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            startPoint = e.GetPosition(null);
        }
        private void Image_MouseMove(object sender, MouseEventArgs e)
        {
            Point mousePos = e.GetPosition(null);
            Vector diff = startPoint - mousePos;

            if (e.LeftButton == MouseButtonState.Pressed &&
                (Math.Abs(diff.X) > SystemParameters.MinimumHorizontalDragDistance ||
                Math.Abs(diff.Y) > SystemParameters.MinimumVerticalDragDistance))
            {
                Image image = e.Source as Image;
                DataObject data = new DataObject(typeof(ImageSource), image.Source);
                DragDrop.DoDragDrop(image, data, DragDropEffects.Move);
            }
        }
        private void ListView_DragEnter(object sender, DragEventArgs e)
        {
            if (!e.Data.GetDataPresent("myFormat") || sender == e.Source)
            {
                e.Effects = DragDropEffects.None;
            }
        }

        private void ListView_Drop(object sender, DragEventArgs e)
        {
           /* Image imageControl = (Image)sender;
            if ((e.Data.GetData(typeof(ImageSource)) != null))
            {
                img1.Source = (ImageSource)e.Data.GetData(typeof(ImageSource));
                img1 = imageControl;
            }*/
            /*if (e.Data.GetDataPresent("myFormat"))
            {
                Console.WriteLine(e.Data.GetData("myFormat"));
            }*/
        }


        private void ListViewItem_MouseEnter(object sender, MouseEventArgs e)
        {
            // Set tooltip visibility

            if (Tg_Btn.IsChecked == true)
            {
                tt_ticket.Visibility = Visibility.Collapsed;
                tt_schedule.Visibility = Visibility.Collapsed;
                tt_trainLine.Visibility = Visibility.Collapsed;
                tt_maps.Visibility = Visibility.Collapsed;
                tt_trainLineReport.Visibility = Visibility.Collapsed;
                tt_train.Visibility = Visibility.Collapsed;
                tt_report_monthly.Visibility = Visibility.Collapsed;
                tt_signout.Visibility = Visibility.Collapsed;
            }
            else
            {
                tt_ticket.Visibility = Visibility.Visible;
                tt_schedule.Visibility = Visibility.Visible;
                tt_trainLine.Visibility = Visibility.Visible;
                tt_maps.Visibility = Visibility.Visible;
                tt_trainLineReport.Visibility = Visibility.Visible;
                tt_train.Visibility = Visibility.Visible;
                tt_report_monthly.Visibility = Visibility.Visible;
                tt_signout.Visibility = Visibility.Visible;
            }
        }

        private void TicketReport_Handler(object sender, RoutedEventArgs e)
        {

        }
        private void TicketReservation_Handler(object sender, RoutedEventArgs e)
        {

        }
        private void MonthlyReport_Handler(object sender, RoutedEventArgs e)
        {
            frame.Content = new MonthlyReport(frame);
        }
        private void TrainLineReport_Handler(object sender, RoutedEventArgs e)
        {
            frame.Content = new TrainLineReport(frame);
        }
        private void Schedule_Handler(object sender, RoutedEventArgs e)
        {
            frame.Content = new ScheduleUpdateDelete(frame);
        }
        private void NetworkTrainLine_Handler(object sender, RoutedEventArgs e)
        {
            frame.Content = new NetworkTrainLine(frame);
        }
        private void TrainLine_Handler(object sender, RoutedEventArgs e)
        {
            frame.Content = new TrainLineCRUD(frame);
        }
        private void Train_Handler(object sender, RoutedEventArgs e)
        {
            frame.Content = new TrainUpdateDelete(frame);
        }

        private void Tg_Btn_Unchecked(object sender, RoutedEventArgs e)
        {
            // img_bg.Opacity = 1;
        }

        private void Tg_Btn_Checked(object sender, RoutedEventArgs e)
        {
            //img_bg.Opacity = 0.3;
        }

        private void BG_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            Tg_Btn.IsChecked = false;
        }

    }
}
