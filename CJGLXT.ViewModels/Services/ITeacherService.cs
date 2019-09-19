using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using CJGLXT.ViewModels.Models;

namespace CJGLXT.ViewModels.Services
{
    public interface ITeacherService
    {
        Task<TeacherModel> GetTeacherAsync(string id);
        Task<IList<TeacherModel>> GetTeachersAsync();
        Task<TeacherEvaluationModel> GetTeacherEvaluationAsync(string tid, string sid);
    }
}
