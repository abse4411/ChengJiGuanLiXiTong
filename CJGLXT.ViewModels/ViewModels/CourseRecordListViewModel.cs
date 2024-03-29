﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using CJGLXT.ViewModels.Models;
using CJGLXT.ViewModels.Services;
using CJGLXT.ViewModels.ViewModels.Common;

namespace CJGLXT.ViewModels.ViewModels
{
     public class CourseRecordListViewModel:GenericListViewModel<CourseRecordModel>
    {
        public ICourseRecordService CourseRecordService { get; }
        public CourseRecordArgs Args { get;}
        public CourseRecordViewModel CourseRecordViewModel { get; }

        public CourseRecordListViewModel(ICourseRecordService courseRecordService,IDialogService dialogService) : base(dialogService)
        {
            CourseRecordService = courseRecordService;
            CourseRecordViewModel=new CourseRecordViewModel(dialogService, courseRecordService);
            Args=new CourseRecordArgs();
        }

        protected override async void OnNew()
        {
            Args.StudentId = null;
            Args.CourseId = 0;
            await CourseRecordViewModel.LoadAsync(Args);
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
                Args.StudentId = SelectedItem.StudentId;
                Args.CourseId = SelectedItem.CourseId;
                await CourseRecordViewModel.LoadAsync(Args);
            }
        }

        private async Task<bool> RefreshAsync()
        {
            Items = null;
            OnNew();
            try
            {
                Items = await CourseRecordService.GetCourseRecordsAsync();
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
