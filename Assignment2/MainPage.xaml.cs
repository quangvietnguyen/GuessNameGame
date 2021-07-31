using System;
using System.Windows;
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

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace Assignment2
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    /// 
    public sealed partial class MainPage : Page
    {
        int i = 0;
        string value, display, g = "";
        string[] line = new string[100];
        int count;
        List<Movie> movies = new List<Movie>();
        public MainPage()
        {
            this.InitializeComponent();
            System.IO.StreamReader file = new System.IO.StreamReader(@"Assets\Data\movies.txt");
            while ((line[i] = file.ReadLine()) != null)
            {
                i++;
            }
            file.Close();
            movies.Add(new Movie("-----Select one items below-----"));
            for (int j = 0; j < i; j++)
            {
                movies.Add(new Movie(line[j]));
            }
        }


    private void Submit_Click(object sender, RoutedEventArgs e)
        {
            Submit.IsEnabled = false;
            value = tb.Text;
            display = value;
            tb.Text = "";
            value = value.Trim();
            value = value.ToUpper();
            count = 3;
            Combo.Visibility = Visibility.Collapsed;
        }

        private void Reset_Click(object sender, RoutedEventArgs e)
        {
            Guess.IsEnabled = true;
            count = 3;
            result.Text = "";
            back.Background = new SolidColorBrush(Windows.UI.Colors.Orange);
            Combo.Visibility = Visibility.Visible;
            tb.IsEnabled = true;
            Submit.IsEnabled = true;
        }

        private void tb_TextChanged(object sender, TextChangedEventArgs e)
        {
            Submit.IsEnabled = true;
        }

        private void Combo_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            value = Combo.SelectedItem.ToString();
            display = value;
            value = value.Trim();
            value = value.ToUpper();
            count = 3;
            Guess.IsEnabled = true;
            Combo.Visibility = Visibility.Collapsed;
            tb.IsEnabled = false;
            Submit.IsEnabled = false;
        }

        private void Guess_Click(object sender, RoutedEventArgs e)
        {
            Submit.IsEnabled = false;
            count--;
            g = guess.Text;
            guess.Text = "";
            g = g.Trim();
            g = g.ToUpper();
            if ((count >= 0) && (value.Equals(g)))
            {
                result.Text = "Correct!, Well done!, Please press RESET to play again.";
                back.Background = new SolidColorBrush(Windows.UI.Colors.Green);
                Guess.IsEnabled = false;
                Combo.Visibility = Visibility.Visible;
                Submit.IsEnabled = true;
                tb.IsEnabled = true;
            } else if ((count >= 0) && (!value.Equals(g)))
            {
                result.Text = "Wrong, you have " + count.ToString() + " time(s) left.";
                back.Background = new SolidColorBrush(Windows.UI.Colors.Red);
                if (count == 0)
                {
                    Guess.IsEnabled = false;
                    tb.IsEnabled = true;
                    Submit.IsEnabled = true;
                    Combo.Visibility = Visibility.Visible;
                    result.Text = "Game Over!, The answer is \"" + display + "\", please press RESET to play again.";
                    back.Background = new SolidColorBrush(Windows.UI.Colors.Orange);
                }
            }
        }
    }
}
