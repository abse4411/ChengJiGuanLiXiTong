using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CJGLXT.App.Services.DataServiceFactory;
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
            using (var dataService=DataServiceFactory.CreateDataService())
            {
                var students = await dataService.GetStudentsAsync();
                foreach (var student in students)
                {
                    student.CourseRecords = await dataService.GetStudentCourseRecordsAsync(student.StudentId);
                }
            }
            return await WorkOutRank(list);
        }

        private static Task<IList<RankModel>> WorkOutRank(IList<RankModel> list)
        {
            return Task.Run(() =>
            {
                foreach (var student in list)
                {
                    student.AverageScore = 0.0d;
                    student.MinScore = 0;
                    student.MaxScore = 0;
                    var hasScoreCourses = student.CourseRecords.Where(c => c.Score.HasValue).ToList();
                    if (hasScoreCourses.Any())
                    {
                        int count = hasScoreCourses.Count;
                        hasScoreCourses.ForEach(c =>
                        {
                            student.AverageScore += (c.Score.Value / count);
                        });
                        student.MinScore = hasScoreCourses.Max(c => c.Score.Value);
                        student.MaxScore = hasScoreCourses.Min(c => c.Score.Value);
                    }
                }
                list = list.OrderByDescending(s => s.AverageScore).ToList();
                int rank = 0;
                double lastScore = -1.0d;
                foreach (var s in list)
                {
                    if (Math.Abs(lastScore-s.AverageScore) < 0.001d)
                        s.Rank = rank++;
                    else
                        s.Rank = ++rank;
                    lastScore = s.AverageScore;
                }
                return list;
            });
        }
    }
}
