using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;
using System.IO;
using System.IO.IsolatedStorage;
using Microsoft.Phone.Controls;
using System.Text.RegularExpressions;
using System.Windows.Threading;
using System.Windows.Media.Imaging;

namespace PhoneApp5
{
    public partial class MainPage : PhoneApplicationPage
    {

      

        public static void playAudio()
        {
            
        } 
        
        FileStream file;
        int length;
        StreamWriter writer;
        String test;
        int line_number;
        String[] quotes;
        int min;
        int sec;
        int score;
        int m=0;
        DispatcherTimer timer;
        int started;
        Random rnd;
        // Constructor
        public MainPage()
        {
            InitializeComponent();
            VisualStateManager.GoToState(this, "PortraitLayoutState", true);
            rnd = new Random();
            score = 0;
            length = 0;
            started = 0;
            line_number = 0;
            sec = 10;
            time.Text = Convert.ToString(sec);
            quotes = new String[] { "hi", "this is", "Stype run", "will it so", "believe achieve receive.", "live and learn.", "get over yourself", "love conquers all", "yes i can", "shine your light", "live learn love", "success breeds success",
                        "sometimes the questions are", "complicated and the answers",  "are simple", "everything you can imagine is real", "tomorrow is another day", "live and let live.", "life teaches, love reveals", "reach for the stars.", "nothing ventured,nothing gained.",
"hi","bellow","lollypop","wealth","information","jelly","plumber","plutonium","jobless",
"computer","awesome","pause","haywire","beast","over","game","loop","killer","rooster","kinetic","let live","burrow into","majestic federer","symbolic differentiation","rectilinear motion","never fear","processing unit",
"cherry app","collective effort","current affairs","jubiliant time","useless item","stype run","code fun do","hack your mind","shopping at mall","i am in","quora for windows","lumia is nokia",
"how to play","application binary interface","world wide web","jurassic park three","power rangers spd",
"timon and pumba"
,
"dino thunder power up","ninja storm ranger form","debug code just so","vintage coke studio for","version seven point nine",
"now you see me","data structures and algorithms","crucial time for you","finish it off then",
"mary tried to have lamb","supporting team india to win","type your name to win","five words are being typed",
"it takes time to finish","generally morning bath goes awry","boy boos big cloud sky","collect coins for speed up","generating functions suitable for generations","this is the last one"};
;
            mainblock.Text = quotes[line_number];
            timer = new DispatcherTimer();
            timer.Interval = new TimeSpan(0, 0, 1);
            timer.Tick += new EventHandler(timer_Tick);
            timer.Start();

        }

        void timer_Tick(object sender, EventArgs e)
        {
            if (started == 1 && sec > 0)
            {
                time.Text = Convert.ToString(--sec);
            }
            if (sec == 0)
            {
                started = 0;
                length = 0;
                line_number = 0;
                mainblock.Text = quotes[0];
                typebox.Text = "";
                sec = 10;
                time.Text = Convert.ToString(sec);
                NavigationService.Navigate(new Uri("/Page1.xaml?location=" + score, UriKind.RelativeOrAbsolute));
                //NavigationService.Navigate(new Uri("/Page1.xaml", UriKind.Relative));
            }

        }

        /*private void button1_Click(object sender, RoutedEventArgs e)
        {
            double text;
            text = Convert.ToDouble(textBox1.Text);
            textBlock1.Text = Convert.ToString(text);
            using (var store = IsolatedStorageFile.GetUserStoreForApplication())
            {
                Stream stream = store.OpenFile("Expenditure.txt", FileMode.Append);
                writer = new StreamWriter(stream);
                stream.Position = stream.Length;
                writer.Write(Convert.ToString(text)+"\n");
                writer.Close();
            }
        }*/

        private void textBox1_TextChanged(object sender, TextChangedEventArgs e)
        {

            //String hi = "cool";
        }

        /*private void button2_Click(object sender, RoutedEventArgs e)
        {
            using (StreamReader sr = new StreamReader(IsolatedStorageFile.GetUserStoreForApplication().OpenFile("Expenditure.txt", FileMode.Open)))
            {
                    String line = sr.ReadLine();
                    textBlock1.Text = line;
            }
        }*/

        private void typebox_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (typebox.Text.Length == 1 && line_number == 0)
            {
                DateTime start = DateTime.Now;
                mainblock.Text = quotes[line_number];
                started = 1;
            }
            else if (typebox.Text == mainblock.Text || typebox.Text == (" "+mainblock.Text))
            {
                DateTime end = DateTime.Now;
                line_number = (line_number + 1);
                mainblock.Text = quotes[rnd.Next(1,quotes.Length)];
                typebox.Text = "";
                sec += 5;
                score = line_number * 3 * 108;
                return;
            }

            String reg = typebox.Text + ".*";
            if (Regex.IsMatch(mainblock.Text, reg))
            {
                //textBlock1.Text = "Yes";
                //image1.Source = RandomAccessStreamReference.CreateFromUri(new Uri("Resources/thumbsup.jpg"));
                BitmapImage image = new BitmapImage(new Uri("thumbsup.jpg", UriKind.Relative));
                image1.Source = image;
                length = typebox.Text.Length;
            }
            else
            {
                //textBlock1.Text = "No";
                //ImageBrush img= new ImageBrush();
                BitmapImage image = new BitmapImage(new Uri("thumbsdown.jpg", UriKind.Relative));
                image1.Source = image;
                if (!(length >= typebox.Text.Length))
                me1.Play();
                length = typebox.Text.Length;
                //image1.Source = img;
                //image1.Source = (@"Resources/thumbsup.jpg");

            }
        }

        private void image1_ImageFailed(object sender, ExceptionRoutedEventArgs e)
        {
            ;
        }

        private void aboutme_Click(object sender, RoutedEventArgs e)
        {
            started = 0;
            line_number = 0;
            mainblock.Text = quotes[0];
            typebox.Text = "";
            sec = 10;
            length = 0;
            time.Text = Convert.ToString(sec);
            NavigationService.Navigate(new Uri("/Page2.xaml" , UriKind.RelativeOrAbsolute));
        }

        protected override void OnOrientationChanged(OrientationChangedEventArgs e)
        {
            if (e.Orientation == PageOrientation.Landscape || e.Orientation == PageOrientation.LandscapeLeft || e.Orientation == PageOrientation.LandscapeRight)
                VisualStateManager.GoToState(this, "LandscapeLayoutState", true);
            else
                VisualStateManager.GoToState(this, "PortraitLayoutState", true);
            base.OnOrientationChanged(e);
        }
       
    }
}