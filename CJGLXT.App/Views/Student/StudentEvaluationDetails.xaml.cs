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

namespace CJGLXT.App.Views.Student
{
    /// <summary>
    /// Interaction logic for StudentEvaluationDetails.xaml
    /// </summary>
    public partial class StudentEvaluationDetails : UserControl
    {
        public StudentEvaluationDetails()
        {
            this.ViewModel = StudentsView.StudentEvaluationViewModel;
            this.DataContext = this;
            InitializeComponent();
        }

        public StudentEvaluationViewModel ViewModel
        {
            get { return (StudentEvaluationViewModel)GetValue(ViewModelProperty); }
            set { SetValue(ViewModelProperty, value); }
        }

        // Using a DependencyProperty as the backing store for ViewModel.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty ViewModelProperty =
            DependencyProperty.Register("ViewModel", typeof(StudentEvaluationViewModel), typeof(StudentEvaluationDetails), new PropertyMetadata(null));


    }
}