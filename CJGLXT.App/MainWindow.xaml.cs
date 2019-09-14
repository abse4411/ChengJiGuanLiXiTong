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
            Startup.ConfigureAsync();
            User = new UserInfo();
            User.UserType = UserType.Teacher;
            User.UserId = "1";
            this.DataContext = this;
            InitializeComponent();
            Frame = this.frame;
        }


        public Oj1 Test {get; set; }=new Oj1();
        public static Frame Frame { get; private set; }

        public static UserInfo User { get; set; }

        private void ButtonBase_OnClick(object sender, RoutedEventArgs e)
        {

        }

        private void ButtonBase_OnClick1(object sender, RoutedEventArgs e)
        {
            //var vm = ServiceLocator.Current().GetService<StudentDetailsViewModel>();
            //var arg=new StudentDetailsArgs();
            //arg.StudentId = "221701339";
            //await vm.LoadAsync(arg);
            //StudentsView.ViewModel = vm;
            Frame.NavigationService.Navigate(new StudentsView());
        }

        private void LoadText(object sender, RoutedEventArgs e)
        {
            this.Result.Text = Test.Oj2.Oj3.Text;
        }

        private void ChangeRef(object sender, RoutedEventArgs e)
        {
            this.Test.Oj2=new Oj2();
        }
    }

    public class Oj1:ObservableObject
    {
        private Oj2 _oj2=new Oj2();
        public Oj2 Oj2
        {
            get => _oj2;
            set => Set(ref _oj2, value);
        }
    }
    public class Oj2
    {
        public Oj3 Oj3 { get; set; }=new Oj3();
    }
    public class Oj3
    {
        public string Text { get; set; } = Guid.NewGuid().ToString();
    }
}
