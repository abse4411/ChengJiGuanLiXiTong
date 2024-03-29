﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
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
using CJGLXT.App.Views.Rank;
using CJGLXT.App.Views.Score;
using CJGLXT.App.Views.Student;
using CJGLXT.App.Views.StudentCourse;
using CJGLXT.App.Views.Teacher;
using CJGLXT.ViewModels.Models;

namespace CJGLXT.App
{
    /// <summary>
    /// Interaction logic for MainPage.xaml
    /// </summary>
    public partial class MainPage : Page
    {
        public MainPage()
        {
            this.DataContext = this;
            InitializeComponent();
            if (IsStudent)
                this.MainGrid.Children.Remove(tGrid);
            else
                this.MainGrid.Children.Remove(sGrid);
        }

        public static UserInfo User { get; set; }

        public bool IsStudent => User.UserType == UserType.Student;
        public bool IsTeacher => !IsStudent;

        private void UIElement_OnMouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            if (sender is MaterialDesignThemes.Wpf.Card card)
            {
                var senderName = card.Name;

                if (User.UserType == UserType.Teacher)
                {
                    TeacherPageNavigate(senderName);
                }
                else
                {
                    StudentPageNavigate(senderName);
                }
            }

        }

        private void StudentPageNavigate(string pageName)
        {
            switch (pageName)
            {
                case "LCard":
                    MainWindow.Frame.NavigationService.Navigate(new TeachersView());
                    break;
                case "CCard":
                    MainWindow.Frame.NavigationService.Navigate(new StudentCourseView());
                    break;
                default:
                    break;
            }
        }

        private void TeacherPageNavigate(string pageName)
        {
            switch (pageName)
            {
                case "ICard":
                    MainWindow.Frame.NavigationService.Navigate(new StudentsView());
                    break;
                case "SCard":
                    MainWindow.Frame.NavigationService.Navigate(new CourseRecordView());
                    break;
                case "TCard":
                    MainWindow.Frame.NavigationService.Navigate(new RankView());
                    break;
                default:
                    break;
            }
        }

        private void Exit(object sender, MouseButtonEventArgs e)
        {
            User = null;
            MainWindow.CloseCurrent();
        }
    }
}
