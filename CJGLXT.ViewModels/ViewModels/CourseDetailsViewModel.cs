using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using CJGLXT.ViewModels.Models;
using CJGLXT.ViewModels.Services;
using CJGLXT.ViewModels.ViewModels.Common;

namespace CJGLXT.ViewModels.ViewModels
{
    public class CourseArgs
    {
        static public CourseArgs CreateDefault() => new CourseArgs();

        public int CourseId { get; set; }

        public bool IsNew => CourseId <= 0;
    }
    public class CourseDetailsViewModel:GenericDetailsViewModel<CourseModel>
    {
        public CourseArgs ViewModelArgs { get;private set; }
        public IStudentScoreService StudentScoreService { get; }

        public CourseDetailsViewModel(IDialogService dialogService,IStudentScoreService studentScoreService) : base(dialogService)
        {
            StudentScoreService = studentScoreService;
        }

        public override bool ItemIsNew=> Item?.IsNew ?? true;

        public async Task LoadAsync(CourseArgs args)
        {
            ViewModelArgs = args ?? CourseArgs.CreateDefault();

            if (ViewModelArgs.IsNew)
            {
                Item = null;
            }
            else
            {
                try
                {
                    Item = await StudentScoreService.GetCourseAsync(ViewModelArgs.CourseId);
                }
                catch (Exception e)
                {
                    await DialogService.ShowAsync("载入失败", e.InnerException?.Message ?? e.Message);
                }
            }
        }



        protected override Task<bool> SaveItemAsync(CourseModel model)
        {
            throw new NotImplementedException();
        }

        protected override Task<bool> DeleteItemAsync(CourseModel model)
        {
            throw new NotImplementedException();
        }

        protected override Task<bool> ConfirmDeleteAsync()
        {
            throw new NotImplementedException();
        }
    }
}
