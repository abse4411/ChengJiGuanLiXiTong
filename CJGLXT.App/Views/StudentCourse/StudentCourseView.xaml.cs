using System;
using System.Collections.Generic;
using System.ComponentModel;
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

namespace CJGLXT.App.Views.StudentCourse
{
    /// <summary>
    /// Interaction logic for StudentCourseView.xaml
    /// </summary>
    public partial class StudentCourseView : Page
    {
        public StudentCourseView()
        {
            ViewModel = ServiceLocator.Current().GetService<StudentCourseRecordListViewModel>();
            ViewModel.StudentId = MainPage.User.UserId;
            CourseDetailsViewModel = ViewModel.CourseDetailsViewModel;
            this.DataContext = this;
            InitializeComponent();
            CourseDetailsViewModel = null;
            ViewModel.Refresh();
        }
        public StudentCourseRecordListViewModel ViewModel { get; }

        public static CourseDetailsViewModel CourseDetailsViewModel { get; private set; }

        private void Selector_OnSelected(object sender, RoutedEventArgs e)
        {
            ViewModel.OnSelected();
        }


        //Sort
        private void List_OnClick(object sender, RoutedEventArgs e)
        {
            if (e.OriginalSource is GridViewColumnHeader)
            {
                GridViewColumn clickedColumn = (e.OriginalSource as GridViewColumnHeader).Column;
                if (clickedColumn != null)
                {
                    string bindingProperty = (clickedColumn.DisplayMemberBinding as Binding).Path.Path;
                    SortDescriptionCollection sdc = this.list.Items.SortDescriptions;
                    ListSortDirection sortDirection = ListSortDirection.Ascending;
                    if (sdc.Count > 0)
                    {
                        SortDescription sd = sdc[0];
                        sortDirection = (ListSortDirection)((((int)sd.Direction) + 1) % 2);
                        sdc.Clear();
                    }
                    sdc.Add(new SortDescription(bindingProperty, sortDirection));
                }
            }
        }
    }
}
