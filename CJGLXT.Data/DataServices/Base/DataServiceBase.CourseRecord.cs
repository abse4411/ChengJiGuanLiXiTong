using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CJGLXT.Data.Data;
using Microsoft.EntityFrameworkCore;

namespace CJGLXT.Data.DataServices.Base
{
    partial class DataServiceBase
    {
        public async Task<CourseRecord> GetCourseRecordAsync(int cid, string sid)
        {
            return await _dataSource.CourseRecords.Where(x => x.StudentId.Equals(sid) && x.CourseId == cid)
                .Include(x=>x.Student)
                .Include(x=>x.Course)
                .AsNoTracking().FirstOrDefaultAsync();
        }
        public async Task<IList<CourseRecord>> GetStudentCourseRecordsAsync(string sid)
        {
            return await _dataSource.CourseRecords.Where(x => x.StudentId.Equals(sid))
                .Include(x => x.Course)
                .AsNoTracking().ToListAsync();
        }

        public async Task<IList<CourseRecord>> GetCourseRecordsAsync(int cid)
        {
            return await _dataSource.CourseRecords.Where(x => x.CourseId == cid)
                .Include(x => x.Student)
                .AsNoTracking().ToListAsync();
        }

        public async Task<IList<CourseRecord>> GetCourseRecordsAsync()
        {
            return await _dataSource.CourseRecords
                .Include(x => x.Student)
                .Include(x => x.Course)
                .AsNoTracking().ToListAsync();
        }

        public async Task<int> AddOrUpdateCourseRecordAsync(CourseRecord record)
        {
            if (_dataSource.CourseRecords.Find(record.StudentId, record.CourseId) != null)
                _dataSource.CourseRecords.Update(record);
            else
                await _dataSource.CourseRecords.AddAsync(record);

            return await _dataSource.SaveChangesAsync();
        }


        public async Task<int> DeleteCourseRecordAsync(CourseRecord record)
        {
            _dataSource.CourseRecords.Remove(record);

            return await _dataSource.SaveChangesAsync();
        }
    }
}
