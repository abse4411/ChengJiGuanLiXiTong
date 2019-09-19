using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using CJGLXT.ViewModels.Models;
using CJGLXT.ViewModels.Services;
using CJGLXT.ViewModels.ViewModels.Common;

namespace CJGLXT.ViewModels.ViewModels
{
    public class CourseRecordArgs
    {
        static public CourseRecordArgs CreateDefault() => new CourseRecordArgs();

        public string StudentId { get; set; }

        public int CourseId { get; set; }

        public bool IsNew => string.IsNullOrWhiteSpace(StudentId) || CourseId<=0;
    }
    public class CourseRecordViewModel: GenericDetailsViewModel<CourseRecordModel>
    {
        public ICourseRecordService RecordService { get; }

        public CourseRecordViewModel(IDialogService dialogService, ICourseRecordService recordService) : base(dialogService)
        {
            RecordService = recordService;
        }

        public override string Title => (Item?.IsNew ?? true) ? "录入成绩" : TitleEdit;
        public string TitleEdit => Item == null ? "编辑成绩" : "学生成绩";

        public override bool ItemIsNew => Item?.IsNew ?? true;

        public CourseRecordArgs ViewModelArgs { get; private set; }

        public async Task LoadAsync(CourseRecordArgs args)
        {
            ViewModelArgs = args ?? CourseRecordArgs.CreateDefault();

            if (ViewModelArgs.IsNew)
            {
                Item = new CourseRecordModel();
                EditableItem = new CourseRecordModel();
                IsEditMode = true;
            }
            else
            {
                try
                {
                    Item = await RecordService.GetCourseRecordAsync(ViewModelArgs.StudentId, ViewModelArgs.CourseId);
                    //Item = item ?? new CourseRecordModel { StudentId = ViewModelArgs.StudentId,CourseId = ViewModelArgs.CourseId, IsEmpty = true };
                    IsEditMode = false;
                }
                catch (Exception e)
                {
                    await DialogService.ShowAsync("载入失败", e.InnerException?.Message ?? e.Message);
                }
            }
        }

        protected override async Task<bool> SaveItemAsync(CourseRecordModel model)
        {
            try
            {
                return await RecordService.AddOrUpdateCourseRecordAsync(model) > 0;
            }
            catch (Exception e)
            {
                await DialogService.ShowAsync("保存失败", e.InnerException?.Message ?? e.Message);
            }

            return false;
        }

        protected override async Task<bool> DeleteItemAsync(CourseRecordModel model)
        {
            try
            {
                return await RecordService.DeleteCourseRecordAsync(model) > 0;
            }
            catch (Exception e)
            {
                await DialogService.ShowAsync("删除失败", e.InnerException?.Message ?? e.Message);
            }

            return false;
        }

        protected override async Task<bool> ConfirmDeleteAsync()
        {
            return await DialogService.ShowAsync("警告", $"你确定要删除该成绩信息吗？该学生可能会生气！");
        }

        protected override IEnumerable<IValidationConstraint<CourseRecordModel>> GetValidationConstraints(CourseRecordModel model)
        {
            yield return new RequiredConstraint<CourseRecordModel>("姓名", m => m.StudentId);
            yield return new RequiredConstraint<CourseRecordModel>("年龄", m => m.CourseId);
            yield return new NullableOrOtherConstraint<CourseRecordModel>("成绩",m=>m.Score,new IValidationConstraint<CourseRecordModel>[]
            {
                new NonGreaterThanConstraint<CourseRecordModel>("成绩",m=>m.Score,100,"100"),
                new GreaterThanConstraint<CourseRecordModel>("成绩",m=>m.Score,-1), 
            });
        }
    }
}
