using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using CJGLXT.ViewModels.Models;

namespace CJGLXT.ViewModels.Services
{
    public interface IStudentEvaluationService
    {
        Task<StudentEvaluationModel> GetStudentEvaluationAsync(string tid,string sid);
        Task<int> AddOrUpdateStudentEvaluationAsync(StudentEvaluationModel model);
        Task<int> DeleteStudentEvaluationAsync(StudentEvaluationModel model);
    }
}
