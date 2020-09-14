using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows;

namespace Shortcut_Launcher_2._0
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            IEnumerable<Button> btnList = ReadCSV();

            foreach (Button b in btnList)
            {
                Console.WriteLine(b.Name + " " + b.Link);
            }
        }

        public IEnumerable<Button> ReadCSV()
        {
            // TODO: Error checking
            string[] lines = File.ReadAllLines("settings.csv");

            // lines.Select allows me to project each line as a Button. 
            // This will give me an IEnumerable<Person> back.
            return lines.Select(line =>
            {
                string[] data = line.Split(',');
                return new Button(data[0], data[1]);
            });
        }
        
        private void Btn01_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Hey");
            Btn01.Visibility = Visibility.Hidden;
        }
    }

    public class Button
    {
        public Button(string N, string L)
        {
            this.Name = N;
            this.Link = L;
        }
        
        public string Name;
        public string Link;
    }
}
