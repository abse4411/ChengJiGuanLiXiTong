﻿using System;
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

namespace CJGLXT.App.Views.Teacher
{
    /// <summary>
    /// Interaction logic for TeacherView.xaml
    /// </summary>
    public partial class TeachersView : Page
    {
        public TeachersView()
        {
            ViewModel = ServiceLocator.Current().GetService<TeacherListViewModel>();
            TeacherDetailsViewModel = ViewModel.TeacherDetailsViewModel;
            TeacherEvaluationViewModel = ViewModel.TeacherEvaluationViewModel;
            this.DataContext = this;
            InitializeComponent();
            TeacherDetailsViewModel = null;
            TeacherEvaluationViewModel = null;
            ViewModel.Refresh();
        }

        public TeacherListViewModel ViewModel { get; }

        public static TeacherDetailsViewModel TeacherDetailsViewModel { get; private set; }
        public static TeacherEvaluationViewModel TeacherEvaluationViewModel { get; private set; }

        private void Selector_OnSelected(object sender, RoutedEventArgs e)
        {
            ViewModel.EArgs.StudentId = MainPage.User.UserId;
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
