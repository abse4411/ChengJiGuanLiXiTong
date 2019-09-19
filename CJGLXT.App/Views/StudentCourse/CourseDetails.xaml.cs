﻿using System;
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

namespace CJGLXT.App.Views.StudentCourse
{
    /// <summary>
    /// Interaction logic for CourseDetails.xaml
    /// </summary>
    public partial class CourseDetails : UserControl
    {
        public CourseDetails()
        {
            ViewModel = StudentCourseView.CourseDetailsViewModel;
            this.DataContext = this;
            InitializeComponent();
        }

        public CourseDetailsViewModel ViewModel { get; }
    }
}
