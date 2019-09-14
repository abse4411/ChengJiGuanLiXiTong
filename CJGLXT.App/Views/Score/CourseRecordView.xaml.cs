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

namespace CJGLXT.App.Views.Score
{
    /// <summary>
    /// Interaction logic for CourseRecordView.xaml
    /// </summary>
    public partial class CourseRecordView : Page
    {
        public CourseRecordView()
        {
            ViewModel = ServiceLocator.Current().GetService<CourseRecordListViewModel>();
            CourseRecordViewModel = ViewModel.CourseRecordViewModel;
            this.DataContext = this;
            InitializeComponent();
            CourseRecordViewModel = null;
        }

        public CourseRecordListViewModel ViewModel { get; }
        public static CourseRecordViewModel CourseRecordViewModel { get; private set; }

        private void Selector_OnSelected(object sender, SelectionChangedEventArgs e)
        {
            ViewModel.OnSelected();
        }

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
