using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
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
using CJGLXT.App.Views.Score;
using CJGLXT.App.Views.Student;
using CJGLXT.Data;
using CJGLXT.ViewModels.ViewModels;
using CJGLXT.ViewModels.ViewModels.Common;
using Microsoft.Extensions.DependencyInjection;

namespace CJGLXT.App
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            Frame = this.frame;
        }

        public static Frame Frame { get; private set; }

        public static void CloseCurrent()
        {
            Frame = null;
            try
            {
                var current = Application.Current.MainWindow;
                var login = new LoginWindow();
                Application.Current.MainWindow = login;
                current?.Close();
                login.Show();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, "意外错误,即将关闭程序");
                Application.Current.Shutdown();
            }
        }

        private void Exit(object sender, RoutedEventArgs e)
        {
            ServiceLocator.DisposeCurrent();
            Application.Current.Shutdown();
        }

        private void About(object sender, RoutedEventArgs e)
        {
            var an = "该软件使用了以下开源的技术/软件,我们一直遵守各项使用协议。" + Environment.NewLine;
            var mdt = "Name: MaterialDesignThemes" + Environment.NewLine
                + "SourceCode: https://github.com/MaterialDesignInXAML/MaterialDesignInXamlToolkit" + Environment.NewLine
                + "Version: 2.6.0" + Environment.NewLine
                + "License: MIT" + Environment.NewLine
                + "Copyright 2015 James Willock/Mulholland Software Ltd" + Environment.NewLine + Environment.NewLine;
            var efc = "Name: Microsoft.EntityFrameworkCore" + Environment.NewLine
                                                   + "SourceCode: https://github.com/aspnet/EntityFrameworkCore" + Environment.NewLine
                                                   + "Version: 2.2.6" + Environment.NewLine
                                                   + "License: Apache-2.0" + Environment.NewLine
                                                   + "© Microsoft Corporation. All rights reserved." + Environment.NewLine + Environment.NewLine;
            var efcss = "Name: Microsoft.EntityFrameworkCore.SqlServer" + Environment.NewLine
                                                            + "SourceCode: https://github.com/aspnet/EntityFrameworkCore" + Environment.NewLine
                                                            + "Version: 2.2.6" + Environment.NewLine
                                                            + "License: Apache-2.0" + Environment.NewLine
                                                            + "© Microsoft Corporation. All rights reserved." + Environment.NewLine + Environment.NewLine;
            var dj = "Name: Microsoft.Extensions.DependencyInjection" + Environment.NewLine
                                                                        + "SourceCode: https://github.com/aspnet/Extensions" + Environment.NewLine
                                                                        + "Version: 2.2.0" + Environment.NewLine
                                                                        + "License: Apache-2.0" + Environment.NewLine
                                                                        + "© Microsoft Corporation. All rights reserved." + Environment.NewLine+ Environment.NewLine;
            var va = "Name: XAML VanArsdel Inventory Sample" + Environment.NewLine
                                                                      + "SourceCode: https://github.com/Microsoft/InventorySample" + Environment.NewLine
                                                                      + "Version: 1.2.7.0" + Environment.NewLine
                                                                      + "License: MIT" + Environment.NewLine
                                                                      + "Copyright (c) Microsoft Corporation. All rights reserved." + Environment.NewLine + Environment.NewLine;
            MessageBox.Show(an+mdt + efc + efcss + dj+va, "技术致谢");
        }
    }

}
