using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using CJGLXT.ViewModels.Models;
using CJGLXT.ViewModels.Services;
using CJGLXT.ViewModels.ViewModels.Common;

namespace CJGLXT.ViewModels.ViewModels
{
    public class TeacherEvaluationArgs
    {
        static public TeacherEvaluationArgs CreateDefault() => new TeacherEvaluationArgs();

        public string StudentId { get; set; }   

        public string TeacherId { get; set; }
    }

    public class TeacherEvaluationViewModel:GenericDetailsViewModel<TeacherEvaluationModel>
    {
        public ITeacherService TeacherService { get; }

        public TeacherEvaluationArgs ViewModelArgs { get; private set; }

        public override string Title => IsDataUnavailable ? "选中老师来查看老师寄语" : "老师寄语";

        public override bool ItemIsNew => Item?.IsNew ?? true;

        protected override Task<bool> SaveItemAsync(TeacherEvaluationModel model)
        {
            throw new NotImplementedException();
        }

        protected override Task<bool> DeleteItemAsync(TeacherEvaluationModel model)
        {
            throw new NotImplementedException();
        }

        protected override Task<bool> ConfirmDeleteAsync()
        {
            throw new NotImplementedException();
        }

        public TeacherEvaluationViewModel(IDialogService dialogService,ITeacherService teacherService) : base(dialogService)
        {
            TeacherService = teacherService;
        }

        public async Task LoadAsync(TeacherEvaluationArgs args)
        {
            ViewModelArgs = args ?? TeacherEvaluationArgs.CreateDefault();
            try
            {
                if (String.IsNullOrWhiteSpace(ViewModelArgs.StudentId) || String.IsNullOrWhiteSpace(ViewModelArgs.TeacherId))
                {
                    Item = null;
                }
                else
                {
                    var item = await TeacherService.GetTeacherEvaluationAsync(ViewModelArgs.TeacherId, ViewModelArgs.StudentId);
                    Item = item ?? new TeacherEvaluationModel { StudentId = ViewModelArgs.StudentId, TeacherId = ViewModelArgs.TeacherId, IsEmpty = true };
                }
            }
            catch (Exception ex)
            {
                await DialogService.ShowAsync("载入失败", ex.Message);
            }
        }
    }
}
