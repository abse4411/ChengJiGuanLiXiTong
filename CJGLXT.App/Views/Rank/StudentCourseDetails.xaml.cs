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

namespace CJGLXT.App.Views.Rank
{
    /// <summary>
    /// Interaction logic for StudentCourseDetails.xaml
    /// </summary>
    public partial class StudentCourseDetails : UserControl
    {
        public StudentCourseDetails()
        {
            
            ViewModel = RankView.StudentCourseListViewModel;
            this.DataContext = this;
            InitializeComponent();
        }

        public StudentCourseListViewModel ViewModel
        {
            get { return (StudentCourseListViewModel)GetValue(ViewModelProperty); }
            set { SetValue(ViewModelProperty, value); }
        }

        // Using a DependencyProperty as the backing store for ViewModel.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty ViewModelProperty =
            DependencyProperty.Register("ViewModel", typeof(StudentCourseListViewModel), typeof(StudentCourseDetails), new PropertyMetadata(null));

    }
}
