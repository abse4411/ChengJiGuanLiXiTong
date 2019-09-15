using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CJGLXT.App.Services.DataServiceFactory;
using CJGLXT.Data.Data;
using CJGLXT.ViewModels.Models;
using CJGLXT.ViewModels.Services;

namespace CJGLXT.App.Services
{
    class LoginService: DataServiceBase,ILoginService
    {

        public LoginService(IDataServiceFactory dataServiceFactory) : base(dataServiceFactory)
        {
        }

        public async Task<bool> LoginAsync(UserModel model)
        {
            if (string.IsNullOrWhiteSpace(model.UserId))
                return false;
            using (var dataService=DataServiceFactory.CreateDataService())
            {
                if (model.UserType == UserType.Student)
                {
                    var student = await dataService.GetStudentAsync(model.UserId);
                    if (student != null)
                    {
                        UpdateUserModelFromStudent(model, student);
                        return true;
                    }
                }
                else
                {
                    var teacher = await dataService.GetTeacherAsync(model.UserId);
                    if (teacher != null)
                    {
                        UpdateUserModelFromTeacher(model, teacher);
                        return true;
                    }
                    return true;
                }
            }
            return false;
        }

        private static void UpdateUserModelFromStudent(UserModel target,Student source)
        {
            target.UserName = source.Name;
            target.UserId = source.StudentId;
        }
        private static void UpdateUserModelFromTeacher(UserModel target, Teacher source)
        {
            target.UserName = source.Name;
            target.UserId = source.TeacherId;
        }
    }
}
