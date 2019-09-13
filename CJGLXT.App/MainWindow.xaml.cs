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
using CJGLXT.App.Configuration;
using CJGLXT.App.Views.Student;
using CJGLXT.Data;
using CJGLXT.ViewModels.ViewModels;
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
            Startup.ConfigureAsync();
            InitializeComponent();
            Frame = this.frame;
        }

        public static Frame Frame { get; private set; }

        private void ButtonBase_OnClick(object sender, RoutedEventArgs e)
        {

        }

        private async void ButtonBase_OnClick1(object sender, RoutedEventArgs e)
        {
            var vm = ServiceLocator.Current().GetService<StudentDetailsViewModel>();
            var arg=new StudentDetailsArgs();
            arg.StudentId = "221701339";
            await vm.LoadAsync(arg);
            StudentsView.ViewModel = vm;
            Frame.NavigationService.Navigate(new StudentsView());
        }
    }
}
