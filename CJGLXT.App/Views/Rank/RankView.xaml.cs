using System.ComponentModel;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using CJGLXT.App.Configuration;
using CJGLXT.ViewModels.ViewModels;

namespace CJGLXT.App.Views.Rank
{
    /// <summary>
    /// Interaction logic for RankView.xaml
    /// </summary>
    public partial class RankView : Page
    {
        public RankView()
        {
            ViewModel = ServiceLocator.Current().GetService<StudentRankListViewModel>();
            StudentCourseListViewModel = ViewModel.StudentCourseListViewModel;
            this.DataContext = this;
            InitializeComponent();
            StudentCourseListViewModel = null;
            ViewModel.Refresh();
        }

        public StudentRankListViewModel ViewModel { get;}
        public static StudentCourseListViewModel StudentCourseListViewModel { get; private set; }

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
