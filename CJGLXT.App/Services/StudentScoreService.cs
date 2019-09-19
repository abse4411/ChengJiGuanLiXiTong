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
    class StudentScoreService:DataServiceBase,IStudentScoreService
    {
        public StudentScoreService(IDataServiceFactory dataServiceFactory) : base(dataServiceFactory)
        {
        }

        public async Task<IList<CourseRecordModel>> GetCourseRecordsAsync(string sid)
        {
            IList<CourseRecordModel> result = new List<CourseRecordModel>();
            using (var dataService = DataServiceFactory.CreateDataService())
            {
                var records = await dataService.GetStudentCourseRecordsAsync(sid);
                foreach (var record in records)
                {
                    result.Add(CreateCourseRecordModel(record));
                }
            }
            return result;
        }

        private static CourseRecordModel CreateCourseRecordModel(CourseRecord record)
        {
            return new CourseRecordModel()
            {
                CourseId = record.CourseId,
                Course = record.Course,
                Student = record.Student,
                StudentId = record.StudentId,
                Score = record.Score,
            };
        }

        public async Task<CourseModel> GetCourseAsync(int id)
        {
            Course course;
            using (var dataService = DataServiceFactory.CreateDataService())
            {
                course = await dataService.GetCourseAsync(id);
            }
            if (course != null)
                return CreateCourseModel(course);
            return null;
        }

        private static CourseModel CreateCourseModel(Course course)
        {
            return new CourseModel()
            {
                CourseId = course.CourseId,
                Name = course.Name,
                Description = course.Description,
            };
        }
    }
}
