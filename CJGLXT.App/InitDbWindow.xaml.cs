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
using System.Windows.Shapes;
using CJGLXT.App.Configuration;
using CJGLXT.ViewModels.ViewModels;

namespace CJGLXT.App
{
    /// <summary>
    /// Interaction logic for InitDbWindow.xaml
    /// </summary>
    public partial class InitDbWindow : Window
    {
        public InitDbWindow()
        {
            Startup.ConfigureAsync();
            ViewModel = ServiceLocator.Current().GetService<InitDatabaseViewMode>();
            this.DataContext = this;
            InitializeComponent();
        }

        public InitDatabaseViewMode ViewModel { get; }

        private void EnterApp(object sender, RoutedEventArgs e)
        {
            var current = Application.Current.MainWindow;
            var login = new LoginWindow();
            Application.Current.MainWindow = login;
            current?.Close();
            login.Show();
        }
    }
}
