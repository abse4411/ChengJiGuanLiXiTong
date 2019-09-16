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
using CJGLXT.App.Views.Rank;
using CJGLXT.App.Views.Score;
using CJGLXT.App.Views.Student;
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
        }

        public static UserInfo User { get; set; }

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
                case "ECard":
                    User = null;
                    MainWindow.CloseCurrent();
                    break;
                default:
                    break;
            }
        }
    }
}
