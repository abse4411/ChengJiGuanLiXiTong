using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using CJGLXT.ViewModels.Models;
using CJGLXT.ViewModels.Services;
using CJGLXT.ViewModels.ViewModels.Common;

namespace CJGLXT.ViewModels.ViewModels
{
    public class StudentCourseRecordListViewModel:GenericListViewModel<CourseRecordModel>
    {
        public IStudentScoreService StudentScoreService { get; }
        public CourseDetailsViewModel CourseDetailsViewModel { get; }
        public CourseArgs Args { get;private set; }
        public string StudentId { get; set; }

        public StudentCourseRecordListViewModel(IDialogService dialogService,IStudentScoreService studentScoreService) : base(dialogService)
        {
            StudentScoreService = studentScoreService;
            CourseDetailsViewModel = new CourseDetailsViewModel(dialogService,studentScoreService);
            Args =new CourseArgs();
        }

        protected override async void OnNew()
        {
            Args.CourseId = -1;
            await CourseDetailsViewModel.LoadAsync(Args);
        }

        protected override void OnRefresh()
        {
            Refresh();
        }

        public async void Refresh()
        {
            if (!await RefreshAsync())
            {
                //await DialogService.ShowAsync("加载失败", "请重试");
            }
        }

        public async void OnSelected()
        {
            if (SelectedItem != null)
            {
                Args.CourseId = SelectedItem.CourseId;
                await CourseDetailsViewModel.LoadAsync(Args);
            }
        }

        private async Task<bool> RefreshAsync()
        {
            Items = null;
            OnNew();
            try
            {
                Items = await StudentScoreService.GetCourseRecordsAsync(StudentId);
            }
            catch (Exception e)
            {
                await DialogService.ShowAsync("载入失败", e.InnerException?.Message ?? e.Message);
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
