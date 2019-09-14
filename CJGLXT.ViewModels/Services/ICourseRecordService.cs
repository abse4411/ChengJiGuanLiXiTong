using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using CJGLXT.ViewModels.Models;

namespace CJGLXT.ViewModels.Services
{
    public interface ICourseRecordService
    {
        Task<CourseRecordModel> GetCourseRecordAsync(string sid, int cid);
        Task<int> AddOrUpdateCourseRecordAsync(CourseRecordModel model);
        Task<int> DeleteCourseRecordAsync(CourseRecordModel model);
    }
}
