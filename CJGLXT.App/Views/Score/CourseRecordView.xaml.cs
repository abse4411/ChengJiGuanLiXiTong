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

namespace CJGLXT.App.Views.Score
{
    /// <summary>
    /// Interaction logic for CourseRecordView.xaml
    /// </summary>
    public partial class CourseRecordView : Page
    {
        public CourseRecordView()
        {
            CourseRecordViewModel = ServiceLocator.Current().GetService<CourseRecordViewModel>();
            NewItem(null, null);
            //CourseRecordViewModel = ViewModel.CourseRecordViewModel;
            this.DataContext = this;
            InitializeComponent();
            //CourseRecordViewModel = null;
        }

        public static CourseRecordViewModel CourseRecordViewModel { get; private set; }

        public CourseRecordArgs Args { get; set; } = new CourseRecordArgs();

        private async void NewItem(object sender, RoutedEventArgs e)
        {
            Args.CourseId = -1;
            Args.StudentId = null;
            await CourseRecordViewModel.LoadAsync(Args);
        }

        private async void Load(object sender, RoutedEventArgs e)
        {
            Args.CourseId = 1;
            Args.StudentId = "221701339";
            await CourseRecordViewModel.LoadAsync(Args);
        }
    }
}
