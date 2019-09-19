using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using CJGLXT.ViewModels.Models;
using CJGLXT.ViewModels.Services;
using CJGLXT.ViewModels.ViewModels.Common;

namespace CJGLXT.ViewModels.ViewModels
{
    public class TeacherListViewModel:GenericListViewModel<TeacherModel>
    {
        public ITeacherService TeacherService { get; }
        public TeacherEvaluationViewModel TeacherEvaluationViewModel { get; }
        public TeacherDetailsViewModel TeacherDetailsViewModel { get; }
        public TeacherEvaluationArgs EArgs { get; set; }
        public TeacherDetailsArgs TArgs { get; set; }


        public TeacherListViewModel(IDialogService dialogService,ITeacherService teacherService) : base(dialogService)
        {
            TeacherService = teacherService;
            TeacherEvaluationViewModel = new TeacherEvaluationViewModel(dialogService, teacherService);
            TeacherDetailsViewModel = new TeacherDetailsViewModel(dialogService, teacherService);
            TArgs = new TeacherDetailsArgs();
            EArgs=new TeacherEvaluationArgs();
        }


        protected override async void OnNew()
        {
            TArgs.TeacherId = null;
            EArgs.TeacherId = null;
            await TeacherDetailsViewModel.LoadAsync(TArgs);
            await TeacherEvaluationViewModel.LoadAsync(EArgs);
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
                TArgs.TeacherId = SelectedItem.TeacherId;
                EArgs.TeacherId = SelectedItem.TeacherId;
                await TeacherEvaluationViewModel.LoadAsync(EArgs);
                await TeacherDetailsViewModel.LoadAsync(TArgs);
            }
        }

        private async Task<bool> RefreshAsync()
        {
            Items = null;
            OnNew();
            try
            {
                Items = await TeacherService.GetTeachersAsync();
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
