using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using CJGLXT.ViewModels.Models;
using CJGLXT.ViewModels.Services;
using CJGLXT.ViewModels.ViewModels.Common;

namespace CJGLXT.ViewModels.ViewModels
{
    public class StudentEvaluationArgs
    {
        static public StudentEvaluationArgs CreateDefault() => new StudentEvaluationArgs();

        public string StudentId { get; set; }

        public string TeacherId { get; set; }
    }
    public class StudentEvaluationViewModel : GenericDetailsViewModel<StudentEvaluationModel>
    {
        public IStudentEvaluationService StudentEvaluationService { get; }

        public StudentEvaluationViewModel(IStudentEvaluationService studentEvaluationService, IDialogService dialogService) : base(dialogService)
        {
            StudentEvaluationService = studentEvaluationService;
        }
        public override string Title => IsDataUnavailable ? "选中学生来进行评价" : TitleEdit;
        public string TitleEdit => Item == null ? "编辑评价" : "评价";

        public override bool ItemIsNew => Item?.IsNew ?? true;

        public StudentEvaluationArgs ViewModelArgs { get; private set; }

        public async Task LoadAsync(StudentEvaluationArgs args)
        {
            ViewModelArgs = args ?? StudentEvaluationArgs.CreateDefault();

            try
            {
                if (String.IsNullOrWhiteSpace(args.StudentId) || String.IsNullOrWhiteSpace(args.TeacherId))
                {
                    Item = null;
                    IsEditMode = true;
                }
                else
                {
                    var item = await StudentEvaluationService.GetStudentEvaluationAsync(ViewModelArgs.TeacherId, ViewModelArgs.StudentId);
                    Item = item ?? new StudentEvaluationModel { StudentId = ViewModelArgs.StudentId, TeacherId = ViewModelArgs.TeacherId, IsEmpty = true };
                    if (item == null)
                        IsEditMode = true;
                    else
                        IsEditMode = false;
                }
            }
            catch (Exception ex)
            {
                await DialogService.ShowAsync("载入失败", ex.Message);
            }
        }

        protected override async Task<bool> SaveItemAsync(StudentEvaluationModel model)
        {
            try
            {
                return await StudentEvaluationService.AddOrUpdateStudentEvaluationAsync(model) > 0;
            }
            catch (Exception e)
            {
                await DialogService.ShowAsync("保存失败", e.InnerException?.Message??e.Message);
            }

            return false;
        }

        protected async override Task<bool> DeleteItemAsync(StudentEvaluationModel model)
        {
            try
            {
                return await StudentEvaluationService.DeleteStudentEvaluationAsync(model) > 0;
            }
            catch (Exception e)
            {
                await DialogService.ShowAsync("删除失败", e.InnerException?.Message ?? e.Message);
            }

            return false;
        }

        protected override async Task<bool> ConfirmDeleteAsync()
        {
            return await DialogService.ShowAsync("确认删除", $"你确定要删除该评价吗？");
        }

        protected override IEnumerable<IValidationConstraint<StudentEvaluationModel>> GetValidationConstraints(StudentEvaluationModel model)
        {
            yield return new RequiredConstraint<StudentEvaluationModel>("评价内容", m => m.Content);

        }
    }
}
