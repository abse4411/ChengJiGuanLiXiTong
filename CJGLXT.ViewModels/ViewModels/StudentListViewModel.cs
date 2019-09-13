using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using CJGLXT.ViewModels.Models;
using CJGLXT.ViewModels.Services;
using CJGLXT.ViewModels.ViewModels.Common;

namespace CJGLXT.ViewModels.ViewModels
{
    public class StudentListViewModel:GenericListViewModel<StudentModel>
    {
        public StudentListViewModel(IDialogService dialogService,IStudentService studentService) : base(dialogService)
        {
            StudentService = studentService;
            StudentDetailsViewModel = new StudentDetailsViewModel(studentService,dialogService);
            Args=new StudentDetailsArgs();
            Refresh();
        }

        public IStudentService StudentService { get; }
        public StudentDetailsViewModel StudentDetailsViewModel { get; set; }
        public StudentDetailsArgs Args { get; set; }

        protected override void OnNew()
        {
            throw new NotImplementedException();
        }

        protected override void OnRefresh()
        {
             Refresh();
        }

        public async void Refresh()
        {
            if (!await RefreshAsync())
            {
                await DialogService.ShowAsync("加载失败", "请重试");
            }
        }

        public async void OnSelected()
        {
            await StudentDetailsViewModel.LoadAsync(Args);
        }

        private async Task<bool> RefreshAsync()
        {
            Items = null;
            Args.StudentId = null;
            await StudentDetailsViewModel.LoadAsync(Args);

            try
            {
                Items=await StudentService.GetStudentsAsync();
            }
            catch (Exception e)
            {
                Items = new List<StudentModel>();
                return false;
            }
            return true;
        }

        protected override void OnDeleteSelection()
        {
            throw new NotImplementedException();
        }
    }
}
