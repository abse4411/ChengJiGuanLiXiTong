using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using CJGLXT.ViewModels.Models;
using CJGLXT.ViewModels.Services;
using CJGLXT.ViewModels.ViewModels.Common;

namespace CJGLXT.ViewModels.ViewModels
{
    public class StudentDetailsArgs
    {
        static public StudentDetailsArgs CreateDefault() => new StudentDetailsArgs();

        public string StudentId { get; set; }

        public bool IsNew => string.IsNullOrWhiteSpace(StudentId);
    }

    public class StudentDetailsViewModel : GenericDetailsViewModel<StudentModel>
    {
        public IStudentService StudentService { get; }

        public StudentDetailsViewModel(IStudentService studentService,IDialogService dialogService) : base(dialogService)
        {
            StudentService = studentService;
        }

        public override string Title => (Item?.IsNew ?? true) ? "新建学生" : TitleEdit;
        public string TitleEdit => Item == null ? "编辑学生" : $"{Item.Name}的个人信息";

        public override bool ItemIsNew => Item?.IsNew ?? true;

        public StudentDetailsArgs ViewModelArgs { get; private set; }

        public async Task LoadAsync(StudentDetailsArgs args)
        {
            ViewModelArgs = args ?? StudentDetailsArgs.CreateDefault();

            if (ViewModelArgs.IsNew)
            {
                Item = new StudentModel();
                IsEditMode = true;
            }
            else
            {
                try
                {
                    var item = await StudentService.GetStudentAsync(ViewModelArgs.StudentId);
                    Item = item ?? new StudentModel { StudentId = ViewModelArgs.StudentId, IsEmpty = true };
                    if (item == null)
                        IsEditMode = true;
                    else
                        IsEditMode = false;
                }
                catch (Exception ex)
                {
                    await DialogService.ShowAsync("载入失败", ex.Message);
                }
            }
        }
        public void Unload()
        {
            ViewModelArgs.StudentId = Item?.StudentId ?? string.Empty;
        }

        protected override async Task<bool> SaveItemAsync(StudentModel model)
        {
            try
            {
                return await StudentService.AddOrUpdateStudentAsync(model)>0;
            }
            catch (Exception e)
            {
                await DialogService.ShowAsync("保存失败", e.Message);
            }

            return false;
        }

        protected override async Task<bool> DeleteItemAsync(StudentModel model)
        {
            try
            {
                return await StudentService.DeleteStudentAsync(model) > 0;
            }
            catch (Exception e)
            {
                await DialogService.ShowAsync("删除失败", e.Message);
            }

            return false;
        }

        protected override async Task<bool> ConfirmDeleteAsync()
        {
            return await DialogService.ShowAsync("确认删除", $"你确定要删除该{Item.Name}的信息吗？");
        }

        protected override IEnumerable<IValidationConstraint<StudentModel>> GetValidationConstraints(StudentModel model)
        {
            yield return new RequiredConstraint<StudentModel>("姓名", m => m.Name);
            yield return new RequiredConstraint<StudentModel>("年龄", m => m.Age);
            yield return new RequiredConstraint<StudentModel>("性别", m => m.Sex);
            yield return new RequiredGreaterThanZeroConstraint<StudentModel>("年龄", m => m.Age);
            yield return new OneOfConstraint<StudentModel>("性别", m => m.Sex,new string[]{"男","女"});
        }
    }


}
