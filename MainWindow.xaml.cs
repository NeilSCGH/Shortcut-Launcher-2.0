using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows;
using System.Diagnostics;
using System.Windows.Input;
using System.Net;

namespace Shortcut_Launcher_2._0
{
    public partial class MainWindow : Window
    {
        bool dieIfDeactivated;
        List<Button> btnList = new List<Button>();
        string setupFilePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"settings.csv");

        public MainWindow()
        {
            StopIfAlreadyRunning();
            InitializeComponent();

            dieIfDeactivated = false;

            btnList = ReadCSV();

            refreshButton();

            disableBtns();
            dieIfDeactivated = true;
        }

        public List<Button> ReadCSV()
        {
            // TODO: Error checking
            List<Button> list = new List<Button>();
            string name, link;

            if (!File.Exists(setupFilePath))
            {
                msgBox("Settings.csv not found !");
                Die();
            }
            using (var reader = new StreamReader(setupFilePath))
            {
                while (!reader.EndOfStream)
                {
                    var line = reader.ReadLine();
                    var data = line.Split(',');
                    name = data[0];
                    link = data[1];

                    if (name == "0")
                    {
                        name = "";
                    }

                    if (name != "" && link == "")
                    {
                        msgBox("No link for" + name);
                        Die();
                    }

                    list.Add(new Button(name, link));
                }
            }

            return list;
        }

        private void run(string url)
        {
            if (Keyboard.IsKeyDown(Key.RightShift)) //Edit this program
            {
                Process.Start(@"D:\GIT\Shortcut - Launcher - 2.0\Shortcut - Launcher - 2.0.sln");
                Die();
            }
            else if (Keyboard.IsKeyDown(Key.LeftShift)) //Edit this program
            {
                Process.Start(@"D:\GIT\Shortcut - Launcher - 2.0\bin\Debug");
                Die();
            }
            else if (Keyboard.IsKeyDown(Key.LeftCtrl)) //force button availability
            { enableBtns(); }
            else if (!(url.Contains("http") || File.Exists(url) || Directory.Exists(url)))
            {
                msgBox("Invalid path: " + url);
                //Process.Start(@"C:/Users/Neil/source/repos/Shortcut Launcher/Shortcut Launcher.sln");
                Die();
            }
            else
            {
                Process.Start(@url);
                Die();
            }
        }

        private void Die()
        { Application.Current.Shutdown(); }

        private void Window_Activated(object sender, System.EventArgs e)
        { if (Internet()) enableBtns(); }

        private bool Internet()
        {
            string URL = "http://www.google.com";
            try
            {
                HttpWebRequest request = (HttpWebRequest)WebRequest.Create(URL);
                request.Timeout = 5000;
                request.Credentials = CredentialCache.DefaultNetworkCredentials;
                HttpWebResponse response = (HttpWebResponse)request.GetResponse();

                return (response.StatusCode == HttpStatusCode.OK);
            }
            catch
            {
                return false;
            }
        }

        private void msgBox(string txt)
        {
            dieIfDeactivated = false;
            MessageBox.Show(txt);
            dieIfDeactivated = true;
        }
        private void Window_Deactivated(object sender, System.EventArgs e)
        { if (dieIfDeactivated) Die(); }

        private void StopIfAlreadyRunning()
        {
            string procName = Process.GetCurrentProcess().ProcessName;
            Process[] processes = Process.GetProcessesByName(procName);
            if (processes.Length > 1)
            {
                foreach (Process proc in processes)
                {
                    proc.CloseMainWindow();
                }

                Die();
            }
        }

        private void enableBtns()
        {
            //todo
        }

        private void disableBtns()
        {
            //todo
        }

        private void refreshButton()
        {
            Btn01.Content = btnList[0].Name;
            Btn02.Content = btnList[1].Name;
            Btn03.Content = btnList[2].Name;
            Btn04.Content = btnList[3].Name;
            Btn05.Content = btnList[4].Name;
            Btn06.Content = btnList[5].Name;
            Btn07.Content = btnList[6].Name;
            Btn08.Content = btnList[7].Name;
            Btn09.Content = btnList[8].Name;
            Btn10.Content = btnList[9].Name;
            Btn11.Content = btnList[10].Name;
            Btn12.Content = btnList[11].Name;
            Btn13.Content = btnList[12].Name;
            Btn14.Content = btnList[13].Name;
            Btn15.Content = btnList[14].Name;
            Btn16.Content = btnList[15].Name;
            Btn17.Content = btnList[16].Name;
            Btn18.Content = btnList[17].Name;
            Btn19.Content = btnList[18].Name;
            Btn20.Content = btnList[19].Name;
            Btn21.Content = btnList[20].Name;
            Btn22.Content = btnList[21].Name;
            Btn23.Content = btnList[22].Name;
            Btn24.Content = btnList[23].Name;
            Btn25.Content = btnList[24].Name;

            Btn01.Visibility = btnList[0].Name == "" ? Visibility.Hidden : Visibility.Visible;
            Btn02.Visibility = btnList[1].Name == "" ? Visibility.Hidden : Visibility.Visible;
            Btn03.Visibility = btnList[2].Name == "" ? Visibility.Hidden : Visibility.Visible;
            Btn04.Visibility = btnList[3].Name == "" ? Visibility.Hidden : Visibility.Visible;
            Btn05.Visibility = btnList[4].Name == "" ? Visibility.Hidden : Visibility.Visible;
            Btn06.Visibility = btnList[5].Name == "" ? Visibility.Hidden : Visibility.Visible;
            Btn07.Visibility = btnList[6].Name == "" ? Visibility.Hidden : Visibility.Visible;
            Btn08.Visibility = btnList[7].Name == "" ? Visibility.Hidden : Visibility.Visible;
            Btn09.Visibility = btnList[8].Name == "" ? Visibility.Hidden : Visibility.Visible;
            Btn10.Visibility = btnList[9].Name == "" ? Visibility.Hidden : Visibility.Visible;
            Btn11.Visibility = btnList[10].Name == "" ? Visibility.Hidden : Visibility.Visible;
            Btn12.Visibility = btnList[11].Name == "" ? Visibility.Hidden : Visibility.Visible;
            Btn13.Visibility = btnList[12].Name == "" ? Visibility.Hidden : Visibility.Visible;
            Btn14.Visibility = btnList[13].Name == "" ? Visibility.Hidden : Visibility.Visible;
            Btn15.Visibility = btnList[14].Name == "" ? Visibility.Hidden : Visibility.Visible;
            Btn16.Visibility = btnList[15].Name == "" ? Visibility.Hidden : Visibility.Visible;
            Btn17.Visibility = btnList[16].Name == "" ? Visibility.Hidden : Visibility.Visible;
            Btn18.Visibility = btnList[17].Name == "" ? Visibility.Hidden : Visibility.Visible;
            Btn19.Visibility = btnList[18].Name == "" ? Visibility.Hidden : Visibility.Visible;
            Btn20.Visibility = btnList[19].Name == "" ? Visibility.Hidden : Visibility.Visible;
            Btn21.Visibility = btnList[20].Name == "" ? Visibility.Hidden : Visibility.Visible;
            Btn22.Visibility = btnList[21].Name == "" ? Visibility.Hidden : Visibility.Visible;
            Btn23.Visibility = btnList[22].Name == "" ? Visibility.Hidden : Visibility.Visible;
            Btn24.Visibility = btnList[23].Name == "" ? Visibility.Hidden : Visibility.Visible;
            Btn25.Visibility = btnList[24].Name == "" ? Visibility.Hidden : Visibility.Visible;


        }


        private void Btn01_Click(object sender, RoutedEventArgs e) { run(btnList[0].Link); }
        private void Btn02_Click(object sender, RoutedEventArgs e) { run(btnList[1].Link); }
        private void Btn03_Click(object sender, RoutedEventArgs e) { run(btnList[2].Link); }
        private void Btn04_Click(object sender, RoutedEventArgs e) { run(btnList[3].Link); }
        private void Btn05_Click(object sender, RoutedEventArgs e) { run(btnList[4].Link); }
        private void Btn06_Click(object sender, RoutedEventArgs e) { run(btnList[5].Link); }
        private void Btn07_Click(object sender, RoutedEventArgs e) { run(btnList[6].Link); }
        private void Btn08_Click(object sender, RoutedEventArgs e) { run(btnList[7].Link); }
        private void Btn09_Click(object sender, RoutedEventArgs e) { run(btnList[8].Link); }
        private void Btn10_Click(object sender, RoutedEventArgs e) { run(btnList[9].Link); }
        private void Btn11_Click(object sender, RoutedEventArgs e) { run(btnList[10].Link); }
        private void Btn12_Click(object sender, RoutedEventArgs e) { run(btnList[11].Link); }
        private void Btn13_Click(object sender, RoutedEventArgs e) { run(btnList[12].Link); }
        private void Btn14_Click(object sender, RoutedEventArgs e) { run(btnList[13].Link); }
        private void Btn15_Click(object sender, RoutedEventArgs e) { run(btnList[14].Link); }
        private void Btn16_Click(object sender, RoutedEventArgs e) { run(btnList[15].Link); }
        private void Btn17_Click(object sender, RoutedEventArgs e) { run(btnList[16].Link); }
        private void Btn18_Click(object sender, RoutedEventArgs e) { run(btnList[17].Link); }
        private void Btn19_Click(object sender, RoutedEventArgs e) { run(btnList[18].Link); }
        private void Btn20_Click(object sender, RoutedEventArgs e) { run(btnList[19].Link); }
        private void Btn21_Click(object sender, RoutedEventArgs e) { run(btnList[20].Link); }
        private void Btn22_Click(object sender, RoutedEventArgs e) { run(btnList[21].Link); }
        private void Btn23_Click(object sender, RoutedEventArgs e) { run(btnList[22].Link); }
        private void Btn24_Click(object sender, RoutedEventArgs e) { run(btnList[23].Link); }
        private void Btn25_Click(object sender, RoutedEventArgs e) { run(btnList[24].Link); }
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
