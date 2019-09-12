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
using CJGLXT.ViewModels.ViewModels;

namespace CJGLXT.App.Views.Student
{
    /// <summary>
    /// Interaction logic for StudentView.xaml
    /// </summary>
    public partial class StudentView : Page
    {
        public StudentView()
        {
            InitializeComponent();
            ViewModel = null;
        }

        public static StudentDetailsViewModel ViewModel { get; set; }

        private async void ButtonBase_OnClick(object sender, RoutedEventArgs e)
        {
            await Details.ViewModel.LoadAsync(new StudentDetailsArgs());
        }
    }
}
