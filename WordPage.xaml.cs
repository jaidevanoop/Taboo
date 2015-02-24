using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.Storage;
using Windows.Storage.Streams;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;


// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkID=390556
namespace Taboo
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    ///
    public sealed partial class WordPage : Page
    {
        //String[] x={"Pirate","Memory","Magazine","God","Wisdom","Vodka","Kangaroo","Watch","Kite","Unicorn","Exhilarating","Gandhi","Jungle","Gossip","Airport","Tokyo","Paris","The-Beatles","Python","A/C","Weed","Dolphin","Chips","Pizza","Facebook","Alcatraz", "T-Rex", "Willy Wonka", "Taboo", "Apple", "Doctor"};
        //String[] y = { "Treasure", "Forget", "Article", "Pray", "Teeth", "Russian", "Pouch", "Look", "Fly", "Myth", "Exciting", "Mahatama", "Forest", "Chat", "Customs", "Japan", "Eiffel-Tower", "John-Lennon", "Language", "Cool", "Mud", "Fish", "Potato", "Cheese","Website","Jail", "Jurassic", "Candy", "Game", "Steve Jobs", "Sick" };
        //String[] z = { "Hook", "Remember", "Press", "Religion","Sage", "Alcohol", "Australia", "Time", "Wind", "Horse", "Thrilling", "Mohandas-Karamchand", "Tree", "Talk", "Baggage", "Sushi", "Pyramid", "Paul-McCartny", "Snake", "Hot", "Mud", "Mammal", "Pringles", "Bread","Internet","Prison", "Dinosaur", "Factory", "Forbidden", "Fruit", "Shot" };
        //String[] a = { "Ship", "Computer", "News", "Believe", "Old", "Bitter", "Animal", "Clock", "Tail", "Forehead", "Fast", "India", "Wild", "Phone", "Departure", "Ninja", "France", "Music", "Programming", "Hot", "Ganja", "Water", "Masala", "Italian", "Photos","Island", "Meat", "Charlie", "Secret", "Red", "Disease"};
        //String[] b = { "Caribbean", "Disc", "Page3", "Universe", "Virtue", "Liquid", "Captain", "Wear", "Paper", "White", "Alive", "Freedom", "Amazon", "Girls", "Arrivals", "Capital", "French", "A-Day-in-the-life", "Reptile", "Humid", "Marijuana", "Shows", "Salt", "Margarita", "Chat", "Al Capone", "Killer", "Cocoa", "Fun", "Tree", "White Coat" };
        int score1 = 0;
        int score2 = 0;
        //string[] count = new string[24];
        //string[] count1 = new string[7];
        public WordPage()
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

            if (timesTicked == 0)
            {
                Globalclass.team_num--;
                if (Globalclass.team_num > 0)
                {

                    this.Frame.Navigate(typeof(FinalScore));
                    if (Globalclass.flag == 0)
                    {
                        Globalclass.flag = 1;
                        Globalclass.score1 = Globalclass.score1 + score1;
                    }
                    else
                    {
                        Globalclass.flag = 0;
                        Globalclass.score2 = Globalclass.score2 + score2;
                    }
                    this.Frame.Navigate(typeof(ScorePage));
           }
          else
                    this.Frame.Navigate(typeof(FinalScore));
                
            
            }
        }
        /// <summary>
        /// Invoked when this page is about to be displayed in a Frame.
        /// </summary>
        /// <param name="e">Event data that describes how this page was reached.
        /// This parameter is typically used to configure the page.</param>
       protected override async void OnNavigatedTo(NavigationEventArgs e)
        {
                
           Random random = new Random();
            Globalclass.randi = random.Next(0, 24);
            var folder = await Windows.ApplicationModel.Package.Current.InstalledLocation.GetFileAsync("Wordlist.txt");
            IRandomAccessStream stream = await folder.OpenAsync(FileAccessMode.Read);
            string res = await FileIO.ReadTextAsync(folder);
            Globalclass.count = res.Split(';');
            int num = 24,x;
            while(num>=0)
            {
                Globalclass.count1=Globalclass.count[num].Split(' ');
                x=Convert.ToInt32(Globalclass.count1[0]);
                if(x==Globalclass.randi)
                {
                    txtb1.Text = Globalclass.count1[1];
                    txtb2.Text = Globalclass.count1[2];
                    txtb3.Text = Globalclass.count1[3];
                    txtb4.Text = Globalclass.count1[4];
                    txtb5.Text = Globalclass.count1[5];
                    txtb6.Text = Globalclass.count1[6];
                    break;
                }
                num--;
            }
           
         
           // Random random = new Random();
          //  Globalclass.randi = random.Next(0, 28);
           // txtb1.Text = x[Globalclass.randi];
           //// txtb2.Text = y[Globalclass.randi];
          //  txtb3.Text = z[Globalclass.randi];
          //  txtb4.Text = a[Globalclass.randi];
          //  txtb5.Text = b[Globalclass.randi];
            tb5.Text = "Score:\tTeam 1: " + Globalclass.score1 + "\tTeam 2: " + Globalclass.score2;
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
            Random random = new Random();
            Globalclass.randi = random.Next(0, 24);
            int num = 24, x;
            while (num >= 0)
            {
                Globalclass.count1 = Globalclass.count[num].Split(' ');
                x = Convert.ToInt32(Globalclass.count1[0]);
                if (x == Globalclass.randi)
                {
                    txtb1.Text = Globalclass.count1[1];
                    txtb2.Text = Globalclass.count1[2];
                    txtb3.Text = Globalclass.count1[3];
                    txtb4.Text = Globalclass.count1[4];
                    txtb5.Text = Globalclass.count1[5];
                    txtb6.Text = Globalclass.count1[6];
                    break;
                }
                num--;
            }
            
            //txtb1.Text = x[Globalclass.randi];
            ////txtb2.Text = y[Globalclass.randi];
           // txtb3.Text = z[Globalclass.randi];
           // txtb4.Text = a[Globalclass.randi];
         //   txtb5.Text = b[Globalclass.randi];
            if(Globalclass.flag==0)
            {
                score1 = score1 + 2;
                tb5.Text = "Your Round's Score:\tTeam 1: " + score1 ;
            }
            else
            {
                score2 = score2 + 2;
                tb5.Text = "Your Round's Score:\tTeam 2: " + score2;
            }
            
        }
        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            Random random = new Random();
            Globalclass.randi = random.Next(0, 24);
            int num = 24, x;
            while (num >= 0)
            {
                Globalclass.count1 = Globalclass.count[num].Split(' ');
                x = Convert.ToInt32(Globalclass.count1[0]);
                if (x == Globalclass.randi)
                {
                    txtb1.Text = Globalclass.count1[1];
                    txtb2.Text = Globalclass.count1[2];
                    txtb3.Text = Globalclass.count1[3];
                    txtb4.Text = Globalclass.count1[4];
                    txtb5.Text = Globalclass.count1[5];
                    txtb6.Text = Globalclass.count1[6];
                    break;
                }
                num--;
            }
         //   txtb1.Text = x[Globalclass.randi];           
         //   txtb2.Text = y[Globalclass.randi];
          //  txtb3.Text = z[Globalclass.randi];
         //   txtb4.Text = a[Globalclass.randi];
          //  txtb5.Text = b[Globalclass.randi];
            if (Globalclass.flag == 0)
            {
                score1 = score1 - 1;
                tb5.Text = "Your Round's Score:\tTeam 1: " + score1;
            }
            else
            {
                score2 = score2 - 1;
                tb5.Text = "Your Round's Score:\tTeam 2: " + score2;
            }
 
        }
    }
}
