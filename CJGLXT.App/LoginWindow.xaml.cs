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
using CJGLXT.ViewModels.Models;
using CJGLXT.ViewModels.ViewModels;

namespace CJGLXT.App
{
    /// <summary>
    /// Interaction logic for LoginWindow.xaml
    /// </summary>
    public partial class LoginWindow : Window
    {
        public LoginViewModel ViewModel { get; }

        public LoginWindow()
        {
            //Startup.ConfigureAsync();
            ViewModel = ServiceLocator.Current().GetService<LoginViewModel>();
            this.DataContext = this;
            InitializeComponent();
        }

        private async void LoginClicked(object sender, RoutedEventArgs e)
        {
            var userType= (this.Student.IsChecked ?? false) ? UserType.Student : UserType.Teacher;
            ViewModel.User.UserType = userType;
            ViewModel.User.Password = String.IsNullOrEmpty(this.Password.Password)?null: this.Password.Password;
            if (await ViewModel.Login())
            {
                var user = new UserInfo
                {
                    UserType = userType,
                    UserName = ViewModel.User.UserName,
                    UserId = ViewModel.User.UserId,
                };
                MainPage.User = user;
                OnLogin();
            }
        }

        private void OnLogin()
        {
            try
            {
                var current = Application.Current.MainWindow;
                var main = new MainWindow();
                Application.Current.MainWindow = main;
                current?.Close();
                main.Show();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, "意外错误,即将关闭程序");
                Application.Current.Shutdown();
            }

        }

        private void Password_OnKeyDown(object sender, KeyEventArgs e)
        {
            if(e.Key==Key.Enter)
                LoginClicked(null, null);
        }
    }
}
