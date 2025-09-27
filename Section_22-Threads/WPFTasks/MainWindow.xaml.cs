using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading;
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

namespace WPFTasks
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public static readonly DependencyProperty HtmlProperty = DependencyProperty.RegisterAttached(
            "Html",
            typeof(string),
            typeof(MainWindow),
            new FrameworkPropertyMetadata(OnHtmlChanged));

        public MainWindow()
        {
            InitializeComponent();
        }

        private void MyButton_Click(object sender, RoutedEventArgs e)
        {
            Task.Run(() =>
            {
                Debug.WriteLine($"Thread: {Thread.CurrentThread.ManagedThreadId}");
                HttpClient httpClient = new HttpClient();
                string html = httpClient.GetStringAsync("https://google.com").Result;

                MyButton.Dispatcher.Invoke(() => 
                {
                    Debug.WriteLine($"Thread: {Thread.CurrentThread.ManagedThreadId}");
                    MyButton.Content = "Done";
                }); 
            });
        }

        private async void MyButton2_Click(object sender, RoutedEventArgs e)
        {
            string myHtml = string.Empty;

            await Task.Run(async () =>
            {
                Debug.WriteLine($"Thread: {Thread.CurrentThread.ManagedThreadId}");
                HttpClient httpClient = new HttpClient();
                string html = httpClient.GetStringAsync("https://google.com").Result;
                myHtml = html;
            });

            MyButton2.Content = "Done";
            Debug.WriteLine($"Thread: {Thread.CurrentThread.ManagedThreadId}");

            MyWebBrowser.SetValue(HtmlProperty, myHtml);
        }

        static void OnHtmlChanged(DependencyObject dependencyObject, DependencyPropertyChangedEventArgs e)
        {
            WebBrowser webBrowser = dependencyObject as WebBrowser;
            if (webBrowser != null)
            {
                webBrowser.NavigateToString(e.NewValue as string);
            }
        }
    }
}
