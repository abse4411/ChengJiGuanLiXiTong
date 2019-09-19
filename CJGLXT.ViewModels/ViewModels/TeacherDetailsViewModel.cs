using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using CJGLXT.ViewModels.Models;
using CJGLXT.ViewModels.Services;
using CJGLXT.ViewModels.ViewModels.Common;

namespace CJGLXT.ViewModels.ViewModels
{
    public class TeacherDetailsArgs
    {
        static public TeacherDetailsArgs CreateDefault() => new TeacherDetailsArgs();

        public string TeacherId { get; set; }

        public bool IsNew => string.IsNullOrWhiteSpace(TeacherId);
    }

    public class TeacherDetailsViewModel:GenericDetailsViewModel<TeacherModel>
    {
        public ITeacherService TeacherService { get; }
        public TeacherDetailsArgs ViewModelArgs { get; private set; }

        public TeacherDetailsViewModel(IDialogService dialogService,ITeacherService teacherService) : base(dialogService)
        {
            TeacherService = teacherService;
        }

        public override bool ItemIsNew => Item?.IsNew ?? true;

        protected override Task<bool> SaveItemAsync(TeacherModel model)
        {
            throw new NotImplementedException();
        }

        protected override Task<bool> DeleteItemAsync(TeacherModel model)
        {
            throw new NotImplementedException();
        }

        protected override Task<bool> ConfirmDeleteAsync()
        {
            throw new NotImplementedException();
        }

        public async Task LoadAsync(TeacherDetailsArgs args)
        {
            ViewModelArgs = args ?? TeacherDetailsArgs.CreateDefault();

            if (ViewModelArgs.IsNew)
            {
                Item = new TeacherModel();
            }
            else
            {
                try
                {
                    var item = await TeacherService.GetTeacherAsync(ViewModelArgs.TeacherId);
                    Item = item ?? new TeacherModel { TeacherId = ViewModelArgs.TeacherId, IsEmpty = true };
                }
                catch (Exception e)
                {
                    await DialogService.ShowAsync("载入失败", e.InnerException?.Message ?? e.Message);
                }
            }
        }
    }
}
