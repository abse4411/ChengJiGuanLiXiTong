using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using CJGLXT.ViewModels.Models;
using CJGLXT.ViewModels.Services;
using CJGLXT.ViewModels.ViewModels.Common;

namespace CJGLXT.ViewModels.ViewModels
{
    public class StudentRankListViewModel:GenericListViewModel<RankModel>
    {
        public IRankService RankService { get; }
        public StudentCourseListViewModel StudentCourseListViewModel { get;}

        public StudentRankListViewModel(IDialogService dialogService,IRankService rankService) : base(dialogService)
        {
            RankService = rankService;
            StudentCourseListViewModel=new StudentCourseListViewModel(dialogService);
        }

        protected override void OnNew()
        {
            StudentCourseListViewModel.Items = null;
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

        public void OnSelected()
        {
            if (SelectedItem != null)
            {
                StudentCourseListViewModel.Load(SelectedItem.CourseRecords);
            }
        }

        private async Task<bool> RefreshAsync()
        {
            Items = null;
            OnNew();
            try
            {
                Items = await RankService.GetStudentRankListAsync();
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
