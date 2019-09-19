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
    class TeacherService: DataServiceBase,ITeacherService
    {
        public TeacherService(IDataServiceFactory dataServiceFactory) : base(dataServiceFactory)
        {
        }

        public async Task<TeacherModel> GetTeacherAsync(string id)
        {
            Teacher teacher;
            using (var dataService = DataServiceFactory.CreateDataService())
            {
                teacher = await dataService.GetTeacherAsync(id);
            }
            if (teacher != null)
                return CreateTeacherModel(teacher);
            return null;
        }

        private static TeacherModel CreateTeacherModel(Teacher teacher)
        {
            return new TeacherModel
            {
                TeacherId = teacher.TeacherId,
                Name = teacher.Name,
                Age = teacher.Age,
                Sex = teacher.Sex
            };
        }

        public async Task<IList<TeacherModel>> GetTeachersAsync()
        {
            IList<TeacherModel> result = new List<TeacherModel>();
            using (var dataService = DataServiceFactory.CreateDataService())
            {
                var teachers = await dataService.GetTeachersAsync();
                foreach (var teacher in teachers)
                {
                    result.Add(CreateTeacherModel(teacher));
                }
            }
            return result;
        }

        public async Task<TeacherEvaluationModel> GetTeacherEvaluationAsync(string tid, string sid)
        {
            Evaluation evaluation;
            using (var dataService = DataServiceFactory.CreateDataService())
            {
                evaluation = await dataService.GetStudentEvaluationAsync(tid, sid);
            }
            if (evaluation != null)
                return CreateTeacherEvaluationModel(evaluation);
            return null;
        }

        private static TeacherEvaluationModel CreateTeacherEvaluationModel(Evaluation evaluation)
        {
            return new TeacherEvaluationModel
            {
                StudentId = evaluation.StudentId,
                TeacherId = evaluation.TeacherId,
                Content = evaluation.Content,
                IsNew = false
            };
        }
    }
}
