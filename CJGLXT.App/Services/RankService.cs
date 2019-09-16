using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CJGLXT.App.Services.DataServiceFactory;
using CJGLXT.Data.Data;
using CJGLXT.ViewModels.Models;
using CJGLXT.ViewModels.Services;

namespace CJGLXT.App.Services
{
    class RankService:DataServiceBase,IRankService
    {
        public RankService(IDataServiceFactory dataServiceFactory) : base(dataServiceFactory)
        {
        }

        public async Task<IList<RankModel>> GetStudentRankListAsync()
        {
            IList<RankModel> list = new List<RankModel>();
            IList<Student> students;
            using (var dataService=DataServiceFactory.CreateDataService())
            {
                students = await dataService.GetStudentsAsync();
                foreach (var student in students)
                {
                    student.CourseRecords = await dataService.GetStudentCourseRecordsAsync(student.StudentId);
                }
            }
            return await WorkOutRank(list, students);
        }

        private static Task<IList<RankModel>> WorkOutRank(IList<RankModel> list, IList<Student> students)
        {
            return Task.Run(() =>
            {
                AddItemsToList(list, students);
                foreach (var student in list)
                {
                    student.AverageScore = 0.0d;
                    student.MinScore = 0;
                    student.MaxScore = 0;
                    var hasScoreCourses = student.CourseRecords.Where(c => c.Score.HasValue).ToList();
                    if (hasScoreCourses.Any())
                    {
                        double count = hasScoreCourses.Count;
                        hasScoreCourses.ForEach(c =>
                        {
                            student.AverageScore += (c.Score.Value / count);
                        });
                        student.MaxScore = hasScoreCourses.Max(c => c.Score.Value);
                        student.MinScore = hasScoreCourses.Min(c => c.Score.Value);
                    }
                }
                list = list.OrderByDescending(s => s.AverageScore).ToList();
                int rank = 0;
                double lastScore = -1.0d;
                foreach (var s in list)
                {
                    if (Math.Abs(lastScore-s.AverageScore) < 0.001d)
                        s.Rank = rank;
                    else
                        s.Rank = ++rank;
                    lastScore = s.AverageScore;
                }
                return list;
            });
        }

        private static void AddItemsToList(IList<RankModel> list, IList<Student> students)
        {
            foreach (var s in students)
            {
                var model = new RankModel
                {
                    StudentId = s.StudentId,
                    Name = s.Name,
                    CourseRecords = new List<CourseRecordModel>()
                };
                foreach (var course in s.CourseRecords)
                {
                    model.CourseRecords.Add(new CourseRecordModel
                    {
                        CourseId = course.CourseId,
                        Course = course.Course,
                        Score = course.Score
                    });
                }
                list.Add(model);
            }
        }
    }
}
