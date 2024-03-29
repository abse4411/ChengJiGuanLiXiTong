﻿using System;
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
    class CourseRecordService:DataServiceBase,ICourseRecordService
    {
        public CourseRecordService(IDataServiceFactory dataServiceFactory):base(dataServiceFactory)
        {
        }


        public async Task<CourseRecordModel> GetCourseRecordAsync(string sid, int cid)
        {
            CourseRecord record;
            using (var dataService = DataServiceFactory.CreateDataService())
            {
                record = await dataService.GetCourseRecordAsync(cid, sid);
            }
            if (record != null)
                return CreateCourseRecordModel(record);
            return null;
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

        public async Task<int> AddOrUpdateCourseRecordAsync(CourseRecordModel model)
        {
            using (var dataService = DataServiceFactory.CreateDataService())
            {
                CourseRecord record = new CourseRecord();
                UpdateCourseRecordFromModel(record, model);
                var result = await dataService.AddOrUpdateCourseRecordAsync(record);
                var newEvaluation = await GetCourseRecordAsync(record.StudentId, record.CourseId);
                model.Merge(newEvaluation);
                return result;
            }
        }

        private static void UpdateCourseRecordFromModel(CourseRecord target, CourseRecordModel source)
        {
            target.StudentId = source.StudentId;
            target.CourseId = source.CourseId;
            target.Score = source.Score;
        }

        public async Task<int> DeleteCourseRecordAsync(CourseRecordModel model)
        {
            var record = new CourseRecord { StudentId = model.StudentId, CourseId = model.CourseId };
            using (var dataService = DataServiceFactory.CreateDataService())
            {
                return await dataService.DeleteCourseRecordAsync(record);
            }
        }

        public async Task<IList<CourseRecordModel>> GetCourseRecordsAsync()
        {
            IList<CourseRecordModel> result = new List<CourseRecordModel>();
            using (var dataService = DataServiceFactory.CreateDataService())
            {
                var records = await dataService.GetCourseRecordsAsync();
                foreach (var record in records)
                {
                    result.Add(CreateCourseRecordModel(record));
                }
            }
            return result;
        }
    }
}
