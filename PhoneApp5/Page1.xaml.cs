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

namespace PhoneApp5
{
    public partial class Page1 : PhoneApplicationPage
    {
        public IsolatedStorageSettings settings = IsolatedStorageSettings.ApplicationSettings;
        protected override void OnNavigatedTo(System.Windows.Navigation.NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);

            string location = "";

            if (NavigationContext.QueryString.TryGetValue("location", out location))
                textBlock1.Text = location;
            String score = location;
            
            StreamWriter writer;
            String text = "";
            String line = "";

            int val;
            if (!settings.Contains("score"))
            {
                settings.Add("score", 0);
            }


            if (Convert.ToInt32(score) > Convert.ToInt32(settings["score"]))
            {
                highscore.Text = "You have achieved a new high score !! ";
                settings["score"] = Convert.ToInt32(score);
            }
            else
            {
                highscore.Text = "High Score is " + Convert.ToString(settings["score"]);
            }
            
          /*  if(!File.Exists("highscore1.txt"))
            {
                using (var store = IsolatedStorageFile.GetUserStoreForApplication())
                {
                Stream stream = store.OpenFile("highscore1.txt", FileMode.Create);
                writer = new StreamWriter(stream);
                if (stream.Length == 0)
                    writer.Write("0");
                settings.Contains("score");
                settings.Add("score", 0);
                settings["score"] = score;
                settings.Save();
                writer.Close();
                //stream.Position = stream.Length;
                //writer.Write(Convert.ToString(text) + "\n");
                //writer.Close();
                }
            }
            using (StreamReader sr = new StreamReader(IsolatedStorageFile.GetUserStoreForApplication().OpenFile("highscore1.txt", FileMode.Open)))
            {
                line = sr.ReadLine();
                val = Convert.ToInt32(line);
                sr.Close();
            }

            using (var store = IsolatedStorageFile.GetUserStoreForApplication())
            {
                Stream stream = store.OpenFile("highscore1.txt", FileMode.Open);
                writer = new StreamWriter(stream);
                stream.Position = stream.Length;
                //writer.Write(Convert.ToString(text) + "\n");
                //writer.Close();

                if (Convert.ToInt32(score) > val)
                {
                    highscore.Text = "You have achieved a new high score !! ";
                    writer.Write(score);
                }
                else
                {
                    writer.Write(Convert.ToString(val));
                }
                writer.Close();
            }*/

        }
        public Page1()
        {
            InitializeComponent();
        }

        private void textBox1_TextChanged(object sender, TextChangedEventArgs e)
        {
            ;
        }

        private void button1_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.GoBack();
        }
    }
}