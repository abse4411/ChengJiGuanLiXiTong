using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using CJGLXT.ViewModels.Services;

namespace CJGLXT.App.Services
{
    class DialogService:IDialogService
    {
        public async Task ShowAsync(string title, Exception ex)
        {
            await ShowAsync(title,ex.Message);
        }

        public async Task<bool> ShowAsync(string title, string content)
        {
            var result =await Task.Run(() =>
                MessageBox.Show(content, title, MessageBoxButton.YesNo, MessageBoxImage.Question));

            return result == MessageBoxResult.Yes;
        }
    }
}
