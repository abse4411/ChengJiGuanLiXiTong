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
        public StudentListViewModel(IDialogService dialogService,IStudentService studentService,IStudentEvaluationService studentEvaluationService) : base(dialogService)
        {
            StudentService = studentService;
            StudentDetailsViewModel = new StudentDetailsViewModel(studentService,dialogService);
            StudentEvaluationViewModel = new StudentEvaluationViewModel(studentEvaluationService, dialogService);
            SArgs = new StudentDetailsArgs();
            EArgs = new StudentEvaluationArgs();
        }

        public IStudentService StudentService { get; }
        public StudentDetailsViewModel StudentDetailsViewModel { get; }
        public StudentEvaluationViewModel StudentEvaluationViewModel { get; }
        public StudentDetailsArgs SArgs { get; set; }
        public StudentEvaluationArgs EArgs { get; set; }


        protected override async void OnNew()
        {
            SArgs.StudentId = null;
            EArgs.StudentId = null;
            await StudentDetailsViewModel.LoadAsync(SArgs);
            await StudentEvaluationViewModel.LoadAsync(EArgs);
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
            if (SelectedItem != null)
            {
                SArgs.StudentId = SelectedItem.StudentId;
                EArgs.StudentId = SelectedItem.StudentId;
                await StudentDetailsViewModel.LoadAsync(SArgs);
                await StudentEvaluationViewModel.LoadAsync(EArgs);
            }
        }

        private async Task<bool> RefreshAsync()
        {
            Items = null;
            OnNew();
            try
            {
                Items =await StudentService.GetStudentsAsync();
            }
            catch (Exception e)
            {
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
