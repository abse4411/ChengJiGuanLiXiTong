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

        public override string Title => (Item?.IsNew ?? true) ? "新建学生" : $"{Item.Name}的个人信息";

        public override bool ItemIsNew => Item?.IsNew ?? true;

        public StudentDetailsArgs ViewModelArgs { get; private set; }

        public async Task LoadAsync(StudentDetailsArgs args)
        {
            ViewModelArgs = args ?? StudentDetailsArgs.CreateDefault();

            if (ViewModelArgs.IsNew)
            {
                Item = new StudentModel();
                EditableItem=new StudentModel();
                IsEditMode = true;
            }
            else
            {
                try
                {
                    Item = await StudentService.GetStudentAsync(ViewModelArgs.StudentId);
                    //Item = item ?? new StudentModel { StudentId = ViewModelArgs.StudentId, IsEmpty = true };
                    IsEditMode = false;
                }
                catch (Exception e)
                {
                    await DialogService.ShowAsync("载入失败", e.InnerException?.Message ?? e.Message);
                }
            }
        }

        protected override async Task<bool> SaveItemAsync(StudentModel model)
        {
            try
            {
                if(ItemIsNew)
                    return await StudentService.AddStudentAsync(model)>0;
                return await StudentService.UpdateStudentAsync(model) > 0;
            }
            catch (Exception e)
            {
                await DialogService.ShowAsync("保存失败", e.InnerException?.Message ?? e.Message);
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
            return await DialogService.ShowAsync("警告", $"你确定要删除该{Item.Name}的信息吗？该学生的所有信息包括成绩，评价都将一并删除！");
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
