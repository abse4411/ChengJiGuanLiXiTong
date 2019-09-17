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
using CJGLXT.ViewModels.ViewModels;

namespace CJGLXT.App.Views.Score
{
    /// <summary>
    /// Interaction logic for CourseRecordDetails.xaml
    /// </summary>
    public partial class CourseRecordDetails : UserControl
    {
        public CourseRecordDetails()
        {
            ViewModel = CourseRecordView.CourseRecordViewModel;
            this.DataContext = this;
            InitializeComponent();
        }

        public CourseRecordViewModel ViewModel { get;}
    }
}
