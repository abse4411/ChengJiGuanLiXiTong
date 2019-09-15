using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
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
using CJGLXT.App.Configuration;
using CJGLXT.App.Views.Score;
using CJGLXT.App.Views.Student;
using CJGLXT.Data;
using CJGLXT.ViewModels.ViewModels;
using CJGLXT.ViewModels.ViewModels.Common;
using Microsoft.Extensions.DependencyInjection;

namespace CJGLXT.App
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            Frame = this.frame;
        }

        public static Frame Frame { get; private set; }

        public static void CloseCurrent()
        {
            Frame = null;
            try
            {
                var current = Application.Current.MainWindow;
                var login = new LoginWindow();
                Application.Current.MainWindow = login;
                current?.Close();
                login.Show();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, "意外错误,即将关闭程序");
                Application.Current.Shutdown();
            }
        }
    }

}
