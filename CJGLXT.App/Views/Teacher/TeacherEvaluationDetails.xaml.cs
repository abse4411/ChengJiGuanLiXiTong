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
using CJGLXT.App.Views.Teacher;
using CJGLXT.ViewModels.ViewModels;

namespace CJGLXT.App.Views.Teacher
{
    /// <summary>
    /// Interaction logic for TeacherEvaluationDetails.xaml
    /// </summary>
    public partial class TeacherEvaluationDetails : UserControl
    {
        public TeacherEvaluationDetails()
        {
            this.ViewModel = TeachersView.TeacherEvaluationViewModel;
            this.DataContext = this;
            InitializeComponent();
        }

        public TeacherEvaluationViewModel ViewModel { get; }
    }
}
