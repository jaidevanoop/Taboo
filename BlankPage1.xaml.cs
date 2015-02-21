using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkID=390556

namespace App1
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    /// 
    

    public sealed partial class BlankPage1 : Page
    {
        int score = 0;




        public BlankPage1()
        {
            this.InitializeComponent();
            Windows.Phone.UI.Input.HardwareButtons.BackPressed += HardwareButtons_BackPressed;
        }
        DispatcherTimer dispatcherTimer;
        int timesTicked = 60;
        public void dispatcherTimerSetup()
        {
            dispatcherTimer = new DispatcherTimer();
            dispatcherTimer.Tick += dispatcherTimer_Tick;
            dispatcherTimer.Interval = new TimeSpan(0, 0, 1);
            dispatcherTimer.Start();
        }
        void dispatcherTimer_Tick(object sender, object e)
        {
            Countdown.Text = timesTicked.ToString();
            timesTicked--;
            if(timesTicked==0)
            {
                this.Frame.Navigate(typeof(MainPage));
            }
        }
        /// <summary>
        /// Invoked when this page is about to be displayed in a Frame.
        /// </summary>
        /// <param name="e">Event data that describes how this page was reached.
        /// This parameter is typically used to configure the page.</param>
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            dispatcherTimerSetup();
        }
        
        private void HardwareButtons_BackPressed(object sender, Windows.Phone.UI.Input.BackPressedEventArgs e)
        {
            Frame rootFrame = Window.Current.Content as Frame;
            if (rootFrame != null && rootFrame.CanGoBack)
            {
                e.Handled = true;
                rootFrame.GoBack();
            }

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            score = score + 5;
            tb5.Text="Score: " + score;
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            score = score - 2;
            tb5.Text = "Score: " + score;
        }
        //----
        /*
        DispatcherTimer timer1 = new DispatcherTimer();
        private void button1_Click(object sender, RoutedEventArgs e)
        {
            timer1.Interval = new TimeSpan(0, 0, 0, 1);
            timer1.Tick += new EventHandler(timer1_Tick);
            timer1.Start();
        }

        int tik = 60;
        private void timer1_Tick(object sender, EventArgs e)
        {
            Countdown.Text = tik + " Seconds Remaining";
            if (tik > 0)
                tik--;
            else
                Countdown.Text = "Times Up";
        }
         */
        
    }
}
