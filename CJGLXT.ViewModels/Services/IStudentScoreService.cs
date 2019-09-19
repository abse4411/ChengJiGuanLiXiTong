using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using CJGLXT.Data.Data;
using CJGLXT.ViewModels.Models;

namespace CJGLXT.ViewModels.Services
{
    public interface IStudentScoreService
    {
        Task<IList<CourseRecordModel>> GetCourseRecordsAsync(string sid);
        Task<CourseModel> GetCourseAsync(int id);
    }
}
