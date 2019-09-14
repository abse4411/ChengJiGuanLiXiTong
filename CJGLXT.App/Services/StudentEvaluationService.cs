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
    class StudentEvaluationService: DataServiceBase,IStudentEvaluationService
    {
        public StudentEvaluationService(IDataServiceFactory dataServiceFactory) : base(dataServiceFactory)
        {
        }

        public async Task<StudentEvaluationModel> GetStudentEvaluationAsync(string tid, string sid)
        {
            StudentEvaluation evaluation;
            using (var dataService=DataServiceFactory.CreateDataService())
            {
                evaluation =await dataService.GetStudentEvaluationAsync(tid, sid);
            }
            if (evaluation != null)
                return CreateStudentEvaluationModel(evaluation);
            return null;
        }

        private static StudentEvaluationModel CreateStudentEvaluationModel(StudentEvaluation evaluation)
        {
            return new StudentEvaluationModel
            {
                StudentId = evaluation.StudentId,
                TeacherId = evaluation.TeacherId,
                Content = evaluation.Content,
                IsNew = false
            };
        }

        public async Task<int> AddOrUpdateStudentEvaluationAsync(StudentEvaluationModel model)
        {
            using (var dataService = DataServiceFactory.CreateDataService())
            {
                StudentEvaluation evaluation=new StudentEvaluation();
                UpdateStudentFromModel(evaluation,model);
                var result=await dataService.AddOrUpdateStudentEvaluationAsync(evaluation);
                var newEvaluation =await GetStudentEvaluationAsync(evaluation.TeacherId, evaluation.StudentId);
                newEvaluation.IsNew = false;
                model.Merge(newEvaluation);
                return result;
            }
        }

        private static void UpdateStudentFromModel(StudentEvaluation target, StudentEvaluationModel source)
        {
            target.StudentId = source.StudentId;
            target.TeacherId = source.TeacherId;
            target.Content = source.Content;
        }

        public async Task<int> DeleteStudentEvaluationAsync(StudentEvaluationModel model)
        {
            var evaluation = new StudentEvaluation { StudentId = model.StudentId,TeacherId = model.TeacherId};
            using (var dataService = DataServiceFactory.CreateDataService())
            {
                return await dataService.DeleteStudentEvaluationAsync(evaluation);
            }
        }
    }
}
