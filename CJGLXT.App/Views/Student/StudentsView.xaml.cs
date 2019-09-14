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
using CJGLXT.ViewModels.Models;
using CJGLXT.ViewModels.ViewModels;

namespace CJGLXT.App.Views.Student
{
    /// <summary>
    /// Interaction logic for StudentView.xaml
    /// </summary>
    public partial class StudentsView : Page
    {
        public StudentsView()
        {
            ViewModel = ServiceLocator.Current().GetService<StudentListViewModel>();
            StudentDetailsViewModel = ViewModel.StudentDetailsViewModel;
            StudentEvaluationViewModel = ViewModel.StudentEvaluationViewModel;
            this.DataContext = this;
            InitializeComponent();
            StudentDetailsViewModel = null;
            StudentEvaluationViewModel = null;
        }

        public StudentListViewModel ViewModel { get; }

        public static StudentDetailsViewModel StudentDetailsViewModel { get; private set; }
        public static StudentEvaluationViewModel StudentEvaluationViewModel { get; private set; }

        private async void ButtonBase_OnClick(object sender, RoutedEventArgs e)
        {
            await Details.ViewModel.LoadAsync(new StudentDetailsArgs());
        }

        private void Selector_OnSelected(object sender, RoutedEventArgs e)
        {
            if (this.list.SelectedItem is StudentModel model)
            {
                ViewModel.SArgs.StudentId = model.StudentId;
                ViewModel.EArgs.StudentId = model.StudentId;
                ViewModel.EArgs.TeacherId = MainWindow.User.UserId;
                ViewModel.OnSelected();
            }
        }

    }
}
