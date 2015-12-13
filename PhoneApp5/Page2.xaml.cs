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
using Microsoft.Phone.Controls;

namespace PhoneApp5
{
    public partial class Page2 : PhoneApplicationPage
    {
        public Page2()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Uri("/MainPage.xaml", UriKind.RelativeOrAbsolute));
//            String text = "About Me:The game which enhances your typing speed." + "\n" + "It starts with sentences of one word each and" + "\n" + "proceeds to 2,3,etc each having ten sentences." + "\n" + "As of now, the app requires you to switch your" + "\n" + "autocorrect off for ultimate fun." + "\n" + "The game rules are simple:" + "\n" + "1) You have to type the sentence you see above" + "\n" + "on the textbox." + "\n" + "2) For each correct sentence typed 5 seconds" + "\n" + "get added to the timer.";
            String text = "About Me:The game which enhances your typing speed."+
            "It starts with sentences of one word each and       "+
                " proceeds to 2,3,etc each having ten sentences." + "\n" + "As of now, the app requires you to switch your" + "\n" + "autocorrect off for ultimate fun." + "\n" + "The game rules are simple:" + "\n" + "1) You have to type the sentence you see above" + "\n" + "on the textbox." + "\n" + "2) For each correct sentence typed 5 seconds" + "\n" + "get added to the timer.";

            textBlock1.Text = text;
        }
    }
}