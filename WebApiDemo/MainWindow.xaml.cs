using Microsoft.Owin.Hosting;
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

namespace WebApiDemo
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : Window
    {
        public Models.ComputerModel ComputerModel { get; set; } = new Models.ComputerModel();
        private System.Windows.Threading.DispatcherTimer timer = new System.Windows.Threading.DispatcherTimer();
        private System.Net.Http.HttpClient httpClient = new System.Net.Http.HttpClient();
        public MainWindow()
        {
            InitializeComponent();
            StartOptions options = new StartOptions();
            options.Urls.Add("http://*:8080");
            WebApp.Start<Startup>(options);
            this.sp.DataContext = this.ComputerModel;
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            this.timer.Interval = TimeSpan.FromSeconds(1);
            this.timer.Tick += Timer_Tick;
            this.timer.Start();
        }

        private async void Timer_Tick(object sender, EventArgs e)
        {
            string result = await this.httpClient.GetStringAsync("http://localhost:8080/computer");
            Models.ComputerModel model = Newtonsoft.Json.JsonConvert.DeserializeObject<Models.ComputerModel>(result);
            this.ComputerModel.CPU = model.CPU;
            this.ComputerModel.CPUTem = model.CPUTem;
            this.ComputerModel.RAM = model.RAM;
        }
        protected override void OnMouseLeftButtonDown(MouseButtonEventArgs e)
        {
            try
            {
                this.DragMove();
            }
            catch { }
            base.OnMouseLeftButtonDown(e);
        }

        private void BtnClose_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
