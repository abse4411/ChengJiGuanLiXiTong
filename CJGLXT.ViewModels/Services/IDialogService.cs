using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CJGLXT.ViewModels.Services
{
    public interface IDialogService
    {
        Task ShowAsync(string title, Exception ex);
        Task<bool> ShowAsync(string title, string content);
    }
}
